using Fullstack.Application.Posts.Commands;
using MediatR;
using Fullstack.Application.Posts.Queries;
using Fullstack.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Fullstack.Api.Extensions;


var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices();
  
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

/*
app.UseAuthentication();
app.UseAuthorization();
*/

app.MapGet("/", () => "Hello World!");

app.MapGet("/api/posts", async (IMediator mediator) =>
{
    var getPosts = new GetAllPosts();
    var posts = await mediator.Send(getPosts);

    return Results.Ok(posts);
})
    .WithName("GetPosts");

app.MapGet("/api/posts/{id}", async (IMediator mediator, int id) =>
{
   var getPost = new GetPostById { PostId = id };
   var post = await mediator.Send(getPost);

   return TypedResults.Ok(post);
})
    .WithName("GetPostById");

app.MapPost("/api/posts", async (IMediator mediator, [FromBody]Post post) =>
{
    var createPost = new CreatePost { PostContent = post.Content };

    var createdPost = await mediator.Send(createPost);

    //return Results.Created($"/api/posts/{createdPost.Id}", createdPost);

    return Results.CreatedAtRoute("GetPostById", new { id = createdPost.Id }, createdPost);
})
    .WithName("CreatePost");

app.MapPut("/api/posts/{id}", async (IMediator mediator, Post post, int id) =>
{
    var updatePost = new UpdatePost { PostId = id, PostContent = post.Content };
    var updatedPost = await mediator.Send(updatePost);
    return Results.Ok(post);
})
    .WithName("UpdatePost");

app.MapDelete("/api/posts/{id}", async (IMediator mediator, int id) =>
{
    var deletePost = new DeletePost { PostId = id };
    await mediator.Send(deletePost);
    return Results.NoContent();
})
    .WithName("DeletePost");

//app.MapControllers();

app.Run();
