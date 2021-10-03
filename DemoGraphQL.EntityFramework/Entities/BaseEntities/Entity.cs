using System;
namespace DemoGraphQL.EntityFramework.Entities.BaseEntities
{
    public abstract class Entity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
    }
}
