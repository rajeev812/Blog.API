using Microsoft.AspNetCore.Http; using Microsoft.AspNetCore.Mvc; using Practice.API.Models.Domain; using Practice.API.Models.DTO; using Practice.API.Repositories.Interface;  namespace Practice.API.Controllers {     [Route("api/[controller]")]     [ApiController]     public class BlogPostController : ControllerBase     {         private readonly IblogpostRepository blogpostRepository;          public BlogPostController(IblogpostRepository blogpostRepository)         {             this.blogpostRepository = blogpostRepository;         }         [HttpPost]         public async Task<IActionResult> CreateBlogPost([FromBody] CreateBlogPostRequestDTO request)         {             var blogpost = new BlogPost             {                 Title = request.Title,                 Author = request.Author,                 Content = request.Content,                 FeatureImageUrl = request.FeatureImageUrl,                 IsVisible = request.IsVisible,                 PublishedDate = request.PublishedDate,                 ShortDescription = request.ShortDescription,                 UrlHandle = request.UrlHandle             };             blogpost = await blogpostRepository.CreateAsync(blogpost);             var response = new BlogPostDTO             {                 Id = blogpost.Id,                 Title = blogpost.Title,                 Author = blogpost.Author,                 Content = blogpost.Content,                 FeatureImageUrl = blogpost.FeatureImageUrl,                 IsVisible = blogpost.IsVisible,                 PublishedDate = blogpost.PublishedDate,                 ShortDescription = blogpost.ShortDescription,                 UrlHandle = blogpost.UrlHandle              };             return Ok(response);          }          [HttpGet]         public async Task<IActionResult> GetResultAsync()
        {
           var blogPosts= await blogpostRepository.GetAllAsync();
            var response = new List<BlogPostDTO>();
            foreach (var blogpost in blogPosts)
            {
                response.Add(new BlogPostDTO { Title = blogpost.Title, 
                    Author = blogpost.Author,
                    Content = blogpost.Content, 
                    FeatureImageUrl = blogpost.FeatureImageUrl, 
                    IsVisible = blogpost.IsVisible, 
                    PublishedDate = blogpost.PublishedDate, 
                    ShortDescription = blogpost.ShortDescription,
                    UrlHandle = blogpost.UrlHandle 
                });
            }
            return Ok(response);
        }     } } 