using Fullstack.Application.Abstractions;
using Fullstack.Application.Posts.Queries;
using Fullstack.Domain.Entities;
using MediatR;

namespace Fullstack.Application.Posts.QueryHandlers;

public class GetPostByIdHandler : IRequestHandler<GetPostById, Post>
{

     private readonly IPostRepository _postRepository;

    public GetPostByIdHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }
    
    public async Task<Post> Handle(GetPostById request, CancellationToken cancellationToken)
    {
        return await _postRepository.GetPostById(request.PostId);
    }
}
