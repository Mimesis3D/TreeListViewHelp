using EntityFramework.DTOs;
using System.Threading.Tasks;
using System;
using EntityFramework.Utilities.Generators.Base;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Utilities.Generators
{
    public class ObjectCollectionTableSeedGtr : TableSeedGtrBase
    {
        public ObjectCollectionTableSeedGtr(DbContext dbContext) : base(dbContext)
        {
        }
        public override async ValueTask InitializeDataTable()
        {
            if (_dbContext == null) return;

            if ((await _dbContext.Set<ObjectCollectionDTO>().ToListAsync()).Count < 1)
            {
                int i = 0;
                while (i < 1)
                {
                    var objectCollection = new ObjectCollectionDTO()
                    {
                        Id = Guid.NewGuid(),
                        DisplayName = $"Objects",
                        Comments = "System Generated",
                        Description = $"ObjectCollection-{i} Description",
                        CreationDate = DateTime.UtcNow,
                        ModifiedDate = DateTime.UtcNow
                    };

                    await _dbContext.Set<ObjectCollectionDTO>().AddAsync(objectCollection);
                    await _dbContext.SaveChangesAsync();
                    i++;
                }
            }
        }

    }
}
