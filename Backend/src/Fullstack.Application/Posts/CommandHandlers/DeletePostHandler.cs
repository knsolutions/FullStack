using Fullstack.Application.Abstractions;
using Fullstack.Application.Posts.Commands;
using MediatR;

namespace Fullstack.Application.Posts.CommandHandlers;

public class DeletePostHandler : IRequestHandler<DeletePost, Unit>
{
    private readonly IPostRepository _postRepository;
    public DeletePostHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }
    
    public async Task<Unit> Handle(DeletePost request, CancellationToken cancellationToken)
    {
        await _postRepository.DeletePost(request.PostId);

        return Unit.Value;
    }
}
