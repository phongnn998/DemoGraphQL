using System;
namespace DemoGraphQL.EntityFramework.Entities.BaseEntities
{
    public class FullAuditedEntity<TPrimaryKey> : AuditedEntity<TPrimaryKey>
    {
        public virtual bool IsDeleted { get; set; }
        public virtual long? DeleterUserId { get; set; }
        public virtual DateTime? DeletionTime { get; set; }
    }
}
