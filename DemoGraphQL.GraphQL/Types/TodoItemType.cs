using DemoGraphQL.Domain.Models;
using GraphQL.Types;

namespace DemoGraphQL.GraphQL.Types
{
    public class TodoItemType: ObjectGraphType<TodoItemViewModel>
    {
        public TodoItemType()
        {
            Name = "todoitem";

            Field(d => d.Id);
            Field(t => t.Title);
            Field(t => t.IsCompleted);
        }
    }
}
