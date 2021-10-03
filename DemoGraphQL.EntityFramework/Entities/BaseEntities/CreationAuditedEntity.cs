using System;
namespace DemoGraphQL.EntityFramework.Entities.BaseEntities
{
    public abstract class CreationAuditedEntity<TPrimaryKey> : Entity<TPrimaryKey>
    {
        public virtual DateTime CreationTime { get; set; }
        public virtual long? CreatorUserId { get; set; }
    }
}
