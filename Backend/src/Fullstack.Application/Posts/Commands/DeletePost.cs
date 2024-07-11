using Fullstack.Domain.Entities;
using MediatR;

namespace Fullstack.Application.Posts.Commands;


public class DeletePost : IRequest<Unit>
{
    public int PostId { get; set; }

}
