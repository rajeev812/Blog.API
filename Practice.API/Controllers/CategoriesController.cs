using Microsoft.AspNetCore.Mvc;
using Practice.API.Models.Domain;
using Practice.API.Models.DTO;
using Practice.API.Repositories.Interface;

namespace Practice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }


        [HttpPost]
        public async Task<IActionResult> Createcategory(CreateCategoryRequestDTOs request)
        {
            //Map DTO to DomainModel
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle,
            };
            await categoryRepository.CreateAsync(category);
            var response = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,
            };
            return Ok(response);
        }

        // GET: https://localhost:7118/api/Categories
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await categoryRepository.GetAllAsync();
            var response = new List<CategoryDTO>();
            foreach (var category in categories)
            {
                response.Add(new CategoryDTO
                {
                    Id = category.Id,
                    Name = category.Name,
                    UrlHandle = category.UrlHandle
                });
            }
            return Ok(response);
        }

        // GET: https://localhost:7118/api/Categories
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetcategoryById([FromRoute] Guid id)
        {
            var exixtingcategory = await categoryRepository.GetAllAsyncById(id);
            if (exixtingcategory is null)
            {
                return NotFound();
            }
            var response = new CategoryDTO
            {
                Id = exixtingcategory.Id,
                Name = exixtingcategory.Name,
                UrlHandle = exixtingcategory.UrlHandle
            };
            return Ok(response);
        }

        // PUT: https://localhost:7118/api/Categories
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Updatecategory([FromRoute] Guid id, UpdatecategoryRequestdto request)
        {
            var category = new Category
            {
                Id = id,
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };
            category = await categoryRepository.UpdateCategory(category);
            if (category is null)
            {
                return NotFound();
            }
            var response = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };
            return Ok(response);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeletedById([FromRoute] Guid id)
        {
            var category = await categoryRepository.DeleteCategoryById(id);
            if (category is null)
                return NotFound();
            var response = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };
            return Ok(response);
        }
    }
}
