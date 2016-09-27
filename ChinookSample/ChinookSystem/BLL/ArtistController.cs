using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel; //ODS
using CHinookSystem.Data.Entities;
using CHinookSystem.Data.Pocos;
using ChinookSystem.DAL;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class ArtistController
    {
        //dump the entire artis entity
        //this will use EntityFramework access
        //Entity classes will be used to define the data
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Artist> Artist_ListAll()
        {
            using (var context = new ChinookContext())
            {
                return context.Artists.ToList();
            }
        }

        //report a dataset containing data from 
        //multiple entities
        //this will use LInq entity access
        //POCO classes will be used to define the data
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ArtistAlbums> ArtistAlbums_Get()
        {
            using (var context = new ChinookContext())
            {
                //when you bring your query from linqpad to youer program you must change the reference(s) to the dataSource

                //you may also nee to change your navigation referencing to the navagation properties you have stated in the entity class defenitions

                var results = from x in context.Albums
                              where x.ReleaseYear == 2008
                              orderby x.Artists.Name, x.Title
                              select new ArtistAlbums
                              {
                                  //Name and Title are poco class property names
                                  Name = x.Artists.Name,
                                  Title =  x.Title
                              };
                //the following requires the query in data memory
                //.ToList()
                //At this point the query wil actually execute

                return results.ToList();
            }
           
        }

    }
}
