using Microsoft.EntityFrameworkCore;
using Practice.API.Data;
using Practice.API.Models.Domain;
using Practice.API.Repositories.Interface;

namespace Practice.API.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext dbContext;

        public CategoryRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> DeleteCategoryById(Guid id)
        {
            var existtingCategory= await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (existtingCategory != null)
            {
                dbContext.Categories.Remove(existtingCategory);
               await dbContext.SaveChangesAsync();
                return existtingCategory;
            }
            return null;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
           return await dbContext.Categories.ToListAsync();
        }
        public async Task<Category?> GetAllAsyncById(Guid id)
        {
            return await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Category?> UpdateCategory(Category category)
        {
            var existingcategory= await dbContext.Categories.FirstOrDefaultAsync(x=>x.Id == category.Id);
            if (existingcategory != null)
            {
                 dbContext.Entry(existingcategory).CurrentValues.SetValues(category);
                await dbContext.SaveChangesAsync();
                return category;
            }
            return null;
        }
    }
}
