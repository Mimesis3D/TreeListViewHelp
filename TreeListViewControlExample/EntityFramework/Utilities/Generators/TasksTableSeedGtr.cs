using System;
using System.Threading.Tasks;
using EntityFramework.DTOs;
using EntityFramework.Utilities.Generators.Base;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Utilities.Generators
{
    public class TasksTableSeedGtr : TableSeedGtrBase
    {
        public TasksTableSeedGtr(DbContext dbContext) : base(dbContext)
        {
        }
        public override async ValueTask InitializeDataTable()
        {
            if (_dbContext == null)
                return;
            if ((await _dbContext.Set<TaskDTO>().ToListAsync()).Count < 1)
            {
                int i = 1;
                while (i < 26)
                {
                    var newTask = new TaskDTO()
                    {
                        Id = Guid.NewGuid(),
                        TaskName = $"Task-{i}",
                        DisplayName = $"Task-{i}",
                        Comments = "System Generated",
                        Description = $"Task-{i} Description",
                        CreationDate = DateTime.UtcNow,
                        ModifiedDate = DateTime.UtcNow
                    };
                    await _dbContext.Set<TaskDTO>().AddAsync(newTask);
                    await _dbContext.SaveChangesAsync();
                    i++;
                }
            }
        }
    }
}