using Practice.API.Models.Domain;

namespace Practice.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetAllAsyncById(Guid id);
        Task<Category?> UpdateCategory(Category category);
    }
}
