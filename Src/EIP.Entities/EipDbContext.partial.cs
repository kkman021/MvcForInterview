using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIP.Entities
{
    public partial class EipDbContext
    {
        public int SaveChanges(int operatorId)
        {
            SetOperationColumn(operatorId);
            return base.SaveChanges();
        }

        public override int SaveChanges()
        {
            return SaveChanges(0);
        }

         public Task<int> SaveChangesAsync(int operatorId)
        {
            SetOperationColumn(operatorId);
            return base.SaveChangesAsync();
        }

        public override Task<int> SaveChangesAsync()
        {
            return SaveChangesAsync(0);
        }
        
        private void SetOperationColumn(int operatorId)
        {
            var entities = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            foreach (var entry in entities)
            {
                Type entityType = entry.Entity.GetType();
                var properties = entityType.GetProperties().Where(x => new List<string>() { "CreateBy", "CreateOnUtc", "ModifyBy", "ModifyOnUtc" }.Contains(x.Name));

                foreach (var property in properties)
                {
                    if (entry.State == EntityState.Added)
                    {
                        if (property.Name == "CreateBy" && operatorId != 0)
                            entry.CurrentValues.SetValues(new { CreateBy = operatorId });

                        if (property.Name == "CreateOnUtc")
                            entry.CurrentValues.SetValues(new { CreateOnUtc = DateTime.UtcNow });
                    }
                    else {
                        if (property.Name == "CreateBy" && operatorId != 0)
                            entry.CurrentValues.SetValues(new { CreateBy = entry.OriginalValues.GetValue<int>("CreateBy") });

                        if (property.Name == "CreateOnUtc")
                            entry.CurrentValues.SetValues(new { CreateOnUtc = entry.OriginalValues.GetValue<DateTime>("CreateOnUtc") });
                    }

                    if (property.Name == "ModifyBy" && operatorId != 0)
                        entry.CurrentValues.SetValues(new { ModifyBy = operatorId });

                    if (property.Name == "ModifyOnUtc")
                        entry.CurrentValues.SetValues(new { ModifyOnUtc = DateTime.UtcNow });
                }
            }
        }
    }
}
