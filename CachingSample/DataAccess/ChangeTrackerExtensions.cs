using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CachingSample.DataAccess
{
    public static class ChangeTrackerExtensions
    {
        public static bool IsAddedOrModifiedOrDeleted(this EntityEntry entry) =>
            entry.State == EntityState.Deleted ||
            entry.State == EntityState.Added ||
            entry.State == EntityState.Modified ||
            entry.References.Any(r => r.TargetEntry != null &&
                                        r.TargetEntry.Metadata.IsOwned() &&
                                        (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));
    }
}
