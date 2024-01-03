using AutoMapper;
using CategoryAndItemAPI.BLL.Interfaces;
using CategoryAndItemAPI.DAL.Context;
using CategoryAndItemAPI.DAL.Entities;
using CategoryAndItemAPI.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CategoryAndItemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IGenericRepository<Item> _itemsRepository;
        private readonly CategoryItemApiContext _dbContext;
        private readonly IMapper _mapper;

        public ItemsController(IGenericRepository<Item> itemsRepository,CategoryItemApiContext dbContext,IMapper mapper )
        {

            _itemsRepository = itemsRepository;
            _dbContext = dbContext;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemToReturnDtoWithCategory>>> GetItems()
        {
            var items = await _itemsRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<Item>,IEnumerable<ItemToReturnDtoWithCategory>>(items));

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemToReturnDtoWithCategory>> GetItemById(int id)
        {
            var item = await _itemsRepository.GetByIdAsync(id);
            return Ok(_mapper.Map<Item,ItemToReturnDtoWithCategory>(item));
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<ItemToReturnDto>> AddItem(ItemToReturnDto itemDto)
        {
            var mappedItem = _mapper.Map<ItemToReturnDto, Item>(itemDto);
            _dbContext.Items.Add(mappedItem);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ItemToReturnDtoWithId>> UpdateCategory(int id, ItemToReturnDtoWithId itemDto)
        {
            if (id != itemDto.Id)
            {
                return BadRequest();
            }
            var mappedItem = _mapper.Map<ItemToReturnDtoWithId, Item>(itemDto);
            _dbContext.Entry(mappedItem).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (id != itemDto.Id)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _dbContext.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _dbContext.Items.Remove(item);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

    }
}
