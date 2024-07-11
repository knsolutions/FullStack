using Fullstack.Domain.Entities;
using MediatR;

namespace Fullstack.Application.Posts.Commands;

public class UpdatePost : IRequest<Post>
{
    public int PostId { get; set; }
    public string? PostContent { get; set; }



}
