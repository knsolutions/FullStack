using Fullstack.Application.Abstractions;
using Fullstack.Domain.Entities;
using Fullstack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post> GetPostById(int postId)
        {
            return await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId);
        }

        public async Task<Post> CreatePost(Post toCreate)
        {
            toCreate.CreatedAt = DateTime.Now;
            toCreate.ModifiedAt = DateTime.Now;
            _context.Posts.Add(toCreate);
            await _context.SaveChangesAsync();
            return toCreate;
        }

        public async Task<Post> UpdatePost(Post updatedContent, int postId)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId);

            post.ModifiedAt = DateTime.Now;
            post.Content = updatedContent.Content;

            await _context.SaveChangesAsync();

            return post;


        }

        public async Task DeletePost(int postId)
        {
            var post = await _context.Posts
            .FirstOrDefaultAsync(p => p.Id == postId);

            if (post == null) return;

            _context.Posts.Remove(post);

            await _context.SaveChangesAsync();        
          
        }
    }
};

