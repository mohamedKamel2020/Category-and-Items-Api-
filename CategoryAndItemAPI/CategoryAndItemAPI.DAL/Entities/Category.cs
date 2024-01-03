using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryAndItemAPI.DAL.Entities
{
    public class Category :BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
