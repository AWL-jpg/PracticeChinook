using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endregion

namespace CHinookSystem.Data.Entities
{

    //point to the sql table that this file maps
    [Table("Tracks")]
    public class Track
    {
        //Key notation is optional if the sql pkey ends in ID or Id
        //Required if default of entity is not entity
        //required if pkey is compound

        //properties can be fully implemented or auto implemented 
        //property names should use sql attibute name
        //properties should be listed in the same order as sql table attributes for ease of maintenence
        //
        [Key]
        public int TrackId { get; set; }

        public string Name { get; set; }

        public int? AlbumId { get; set; }

        public int MediaTypeId { get; set; }

        public int? GenereId { get; set; }

        public string Composer { get; set; }

        public int Milliseconds { get; set; }

        public int? Bytes { get; set; }

        public decimal UnitPrice { get; set; }
        //navagation properties for use by linq
        //these properties will be of type virtual
        //there are two types of navagation properties,
        //properties that point to "children" use ICollection<>

        //properties that point to "Parent" use ParentName(in this case the "Artist") as the dataType

        //public virtual ICollection<PaylistTracks> Tracks { get; set; }

        public virtual Album Albums { get; set; }

        public virtual MediaType MediaTypes { get; set; }

    }
}
