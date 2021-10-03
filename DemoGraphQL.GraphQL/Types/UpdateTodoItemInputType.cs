using System;
using DemoGraphQL.Domain.Models;
using GraphQL.Types;

namespace DemoGraphQL.GraphQL.Types
{
    public class UpdateTodoItemInputType : InputObjectGraphType<TodoItemViewModel>
    {
        public UpdateTodoItemInputType()
        {
            Name = "UpdateTodoItemInput";
            Field(x => x.Title);
            Field(x => x.Id);
            Field(x => x.IsCompleted);
        }
    }
}
