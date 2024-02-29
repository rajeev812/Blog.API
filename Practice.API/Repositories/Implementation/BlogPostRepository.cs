using Microsoft.EntityFrameworkCore;
using Practice.API.Data;
using Practice.API.Models.Domain;
using Practice.API.Repositories.Interface;

namespace Practice.API.Repositories.Implementation
{
    public class BlogPostRepository : IblogpostRepository
    {
        private readonly AppDbContext dbContext;

        public BlogPostRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<BlogPost> CreateAsync(BlogPost blogPost)
        {
           await dbContext.BlogPosts.AddAsync(blogPost);
            await dbContext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
           return await dbContext.BlogPosts.ToListAsync();
        }
    }
}
