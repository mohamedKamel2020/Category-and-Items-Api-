using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CategoryAndItemAPI.DAL.Entities
{
    public class Item:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        //[ForeignKey("Category")]
        public int CategoryId { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; } //Navigational property
    }
}
