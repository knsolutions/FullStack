﻿using Fullstack.Domain.Entities;

namespace Fullstack.Application.Abstractions
{
    public interface IPostRepository
    {
        Task<ICollection<Post>> GetAllPosts();

        Task<Post> GetPostById(int postId);

        Task<Post> CreatePost(Post toCreate);

        Task<Post> UpdatePost(Post updatedContent, int postId);

        Task DeletePost(int postId);
    }
};
