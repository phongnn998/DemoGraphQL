using System;
using DemoGraphQL.Domain.Models;
using GraphQL.Types;

namespace DemoGraphQL.GraphQL.Types
{
    public class CreateTodoItemInputType : InputObjectGraphType<TodoItemViewModel>
    {
        public CreateTodoItemInputType()
        {
            Name = "CreateTodoItemInput";
            Field(x => x.Title);
            Field(x => x.IsCompleted);
        }
    }
}
