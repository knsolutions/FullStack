using Fullstack.Application.Abstractions;
using Fullstack.Application.Posts.Commands;
using Fullstack.Domain.Entities;
using MediatR;
    
namespace Fullstack.Application.Posts.CommandHandlers;


public class UpdatePostHandler : IRequestHandler<UpdatePost, Post>
{
    private readonly IPostRepository _postRepository;
    public UpdatePostHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<Post> Handle(UpdatePost request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.UpdatePost(request.PostContent, request.PostId);

        return post;
    }
}
