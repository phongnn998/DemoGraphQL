using System;
using DemoGraphQL.Domain.Services.Interfaces;
using DemoGraphQL.GraphQL.Types;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace DemoGraphQL.GraphQL
{
    public class MainQuery: ObjectGraphType<object>
    {
        public MainQuery(IServiceProvider provider)
        {
            Field<ListGraphType<TodoItemType>>(
                "todoitems",
                 arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "pageSize", },
                    new QueryArgument<IntGraphType> { Name = "offset" }
                ),
                resolve: context => {
                    var service = provider.GetRequiredService<ITodoItemService>();
                    return service.GetAllAsync(context.GetArgument<int>("pageSize", 10), context.GetArgument<int>("offset", 0));
                });

            Field<TodoItemType>(
                "todoitem",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>>() { Name = "id" }),
                resolve: context =>
                {
                    var service = provider.GetRequiredService<ITodoItemService>();
                    return service.GetByIdAsync(context.GetArgument<int>("id"));
                });
        }
    }
}
