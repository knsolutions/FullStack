using Fullstack.Application.Abstractions;
using Fullstack.Application.Posts.Commands;
using Fullstack.Domain.Entities;
using MediatR;

namespace Fullstack.Application.Posts.CommandHandlers;

public class GetAllPostsHandler : IRequestHandler<GetAllPosts, ICollection<Post>>
{

    private readonly IPostRepository _postRepository;
    public GetAllPostsHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }
    
    public async Task<ICollection<Post>> Handle(GetAllPosts request, CancellationToken cancellationToken)
    {
        return await _postRepository.GetAllPosts();
    }
}
