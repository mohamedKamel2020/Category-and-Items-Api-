using AutoMapper;
using CategoryAndItemAPI.BLL.Interfaces;
using CategoryAndItemAPI.BLL.Repository;
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
    public class CategoriesController : ControllerBase
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly CategoryItemApiContext _dbContext;
        private readonly IMapper _mapper;

        public CategoriesController(IGenericRepository<Category> categoryRepository, CategoryItemApiContext dbContext,IMapper mapper)
        {

            _categoryRepository = categoryRepository;
            _dbContext = dbContext;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _categoryRepository.GetAllAsync(); 
            return Ok(categories);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return Ok(category);
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<CategoryToReturnDto>> AddCategory(CategoryToReturnDto categoryDto)
        {
            var mappedCategory = _mapper.Map<CategoryToReturnDto, Category>(categoryDto);
            _dbContext.Categories.Add(mappedCategory);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryToReturnDtoWithId>> UpdateCategory(int id, CategoryToReturnDtoWithId categoryDto)
        {
            if (id != categoryDto.Id)
            {
                return BadRequest();
            }
            var mappedCategory = _mapper.Map<CategoryToReturnDtoWithId, Category>(categoryDto);
            _dbContext.Entry(mappedCategory).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (id != categoryDto.Id)
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
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
