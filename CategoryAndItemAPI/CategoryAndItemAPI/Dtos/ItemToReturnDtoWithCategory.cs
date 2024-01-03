using CategoryAndItemAPI.Controllers;
using CategoryAndItemAPI.DAL.Entities;

namespace CategoryAndItemAPI.Dtos
{
    public class ItemToReturnDtoWithCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
    }
}
