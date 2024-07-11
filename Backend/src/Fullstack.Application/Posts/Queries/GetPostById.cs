using Fullstack.Domain.Entities;
using MediatR;

namespace Fullstack.Application.Posts.Queries;

public class GetPostById : IRequest<Post>
{
    public int PostId { get; set; }
}
