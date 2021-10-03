using System;
namespace DemoGraphQL.EntityFramework.Entities.BaseEntities
{
    public class AuditedEntity<TPrimaryKey> : CreationAuditedEntity<TPrimaryKey>
    {
        public virtual DateTime? LastModificationTime { get; set; }
        public virtual long? LastModifierUserId { get; set; }
    }
}
