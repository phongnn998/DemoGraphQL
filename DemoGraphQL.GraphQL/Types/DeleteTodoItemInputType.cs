using System;
using DemoGraphQL.Domain.Models;
using GraphQL.Types;

namespace DemoGraphQL.GraphQL.Types
{
    public class DeleteTodoItemInputType : InputObjectGraphType<TodoItemViewModel>
    {
        public DeleteTodoItemInputType()
        {
            Name = "DeleteTodoItemInput";
            Field(x => x.Id);
        }
    }
}
