using Fullstack.Application.Abstractions;
using Fullstack.Application.Posts.Commands;
using Fullstack.Domain.Entities;
using MediatR;

namespace Fullstack.Application.Posts.CommandHandlers;

public class CreatePostHandler : IRequestHandler<CreatePost, Post>
{

    private readonly IPostRepository _postRepository;
    public CreatePostHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }
    
    public async Task<Post> Handle(CreatePost request, CancellationToken cancellationToken)
    {
        var newPost = new Post
        {
            Content = request.PostContent
        };

        return await _postRepository.CreatePost(newPost);
    }
}


