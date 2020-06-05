using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiLibrary.Core.Entity
{
    public class BaseDbContext : DbContext
    {

        public override int SaveChanges(bool acceptAllChangeOnSuccess)
        {
            AddTracking();
            return base.SaveChanges(acceptAllChangeOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            AddTracking();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void AddTracking()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added));
            foreach (var item in entries)
            {
                if (item.State == EntityState.Added)
                {
                    ((BaseEntity)item.Entity).CreatedAt = DateTime.Now;
                }
            }
        }
    }
}
