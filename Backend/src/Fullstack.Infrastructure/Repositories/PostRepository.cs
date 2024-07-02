using Fullstack.Application.Abstractions;
using Fullstack.Domain.Entities;
using Fullstack.Infrastructure.Data;

namespace Fullstack.Infrastructure.Repositories
{
    public class PostRepository: IPostRepository
    {
        private readonly SocialDbContext _context;

        public PostRepository(SocialDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Post>> GetAllPosts()
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPostById(int postId)
        {
            throw new NotImplementedException();
        }

        public async Task<Post> CreatePost(Post toCreate)
        {
            toCreate.CreatedAt = DateTime.Now;
            toCreate.ModifiedAt = DateTime.Now;
            _context.Posts.Add(toCreate);
            await _context.SaveChangesAsync();
            return toCreate;
        }

        public Task<Post> UpdatePost(Post updatedContent, int postId)
        {
            throw new NotImplementedException();
        }

        public Task DeletePost(int postId)
        {
            throw new NotImplementedException();
        }
    }
};

