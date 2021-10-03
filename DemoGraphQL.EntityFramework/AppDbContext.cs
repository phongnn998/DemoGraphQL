using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DemoGraphQL.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoGraphQL.EntityFramework
{
    public class AppDbContext : DbContext, IDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public virtual DbSet<TodoItem> TodoItems { get; set; }

        #region Override Method
        public override int SaveChanges()
        {
            ValidateSaveChangeError();
            return base.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            ValidateSaveChangeError();
            return base.SaveChangesAsync();
        }
        #endregion

        #region Private Methods
        private void ValidateSaveChangeError()
        {
            var validationErrors = ChangeTracker
                .Entries<IValidatableObject>()
                .SelectMany(e => e.Entity.Validate(null))
                .Where(r => r != ValidationResult.Success)
                .ToList();

            if (validationErrors.Any())
            {
                var exceptionMessage = string.Join(
                        Environment.NewLine,
                        validationErrors.Select(error =>
                            string.Format("Properties {0} Error: {1}", error.MemberNames, error.ErrorMessage))
                    );

                throw new Exception(exceptionMessage);
            }
        }
        #endregion
    }
}
