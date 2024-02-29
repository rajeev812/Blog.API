using Practice.API.Models.Domain;

namespace Practice.API.Repositories.Interface
{
    public interface IblogpostRepository
    {
       Task<BlogPost> CreateAsync(BlogPost blogPost);
        Task<IEnumerable< BlogPost>> GetAllAsync();
    }
}
