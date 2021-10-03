using System;
using DemoGraphQL.EntityFramework.Entities.BaseEntities;

namespace DemoGraphQL.EntityFramework.Entities
{
    public class TodoItem : Entity<int>
    {
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
