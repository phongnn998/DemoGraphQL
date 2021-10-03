using System;
using DemoGraphQL.Domain.Models;
using DemoGraphQL.Domain.Services.Interfaces;
using DemoGraphQL.GraphQL.Types;
using GraphQL;
using GraphQL.Types;

namespace DemoGraphQL.GraphQL
{
    public class MainMutation: ObjectGraphType
    {
        public MainMutation(ITodoItemService service)
        {
            Name = "Post";

            Field<TodoItemType>(
                "createTodoItem",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CreateTodoItemInputType>>() { Name = "Input" }
                ),
                resolve: context =>
                {
                    var input = context.GetArgument<TodoItemViewModel>("Input");
                    return service.CreateAsync(input);
                }
            );

            Field<TodoItemType>(
                "updateTodoItem",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UpdateTodoItemInputType>>() { Name = "Input" }
                ),
                resolve: context =>
                {
                    var input = context.GetArgument<TodoItemViewModel>("Input");
                    return service.UpdateAsync(input);
                }
            );


            Field<TodoItemType>(
                "deleteTodoItem",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<DeleteTodoItemInputType>>() { Name = "Input" }
                ),
                resolve: context =>
                {
                    var input = context.GetArgument<TodoItemViewModel>("Input");
                    return service.DeleteAsync(input.Id);
                }
            );
        }
    }
}
