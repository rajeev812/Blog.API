using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.API.Data;
using Practice.API.Models.Domain;
using Practice.API.Models.DTO;
using Practice.API.Repositories.Implementation;
using Practice.API.Repositories.Interface;

namespace Practice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CateogriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CateogriesController(ICategoryRepository categoryRepository)
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
    }
}
