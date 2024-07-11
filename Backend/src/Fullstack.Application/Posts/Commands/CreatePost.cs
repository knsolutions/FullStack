using Fullstack.Domain.Entities;
using MediatR;

namespace Fullstack.Application.Posts.Commands;

public class CreatePost: IRequest<Post>
{
    public string? PostContent { get; set; }
}

