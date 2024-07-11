using Fullstack.Domain.Entities;
using MediatR;

namespace Fullstack.Application.Posts.Commands;

public class GetAllPosts : IRequest<ICollection<Post>>
{

}
