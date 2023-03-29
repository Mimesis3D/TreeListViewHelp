﻿using System;
using System.Threading.Tasks;
using EntityFramework.DTOs;
using EntityFramework.Utilities.Generators.Base;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Utilities.Generators
{
    public class ProjectsTableSeedGtr : TableSeedGtrBase
    {
        public ProjectsTableSeedGtr(DbContext dbContext) : base(dbContext)
        {

        }
        public override async ValueTask InitializeDataTable()
        {
            if (_dbContext == null)
                return;

            if ((await _dbContext.Set<ProjectDTO>().ToListAsync()).Count < 1)
            {
                int i = 1;
                while (i < 26)
                {
                    var newProject = new ProjectDTO()
                    {
                        Id = Guid.NewGuid(),
                        ProjectName = $"Project-{i}",
                        DisplayName = $"Project-{i}",
                        Comments = "System Generated",
                        Description = $"Session-{i} Description",
                        CreationDate = DateTime.UtcNow,
                        ModifiedDate = DateTime.UtcNow
                    };

                    await _dbContext.Set<ProjectDTO>().AddAsync(newProject);
                    await _dbContext.SaveChangesAsync();
                    i++;
                }
            }
        }
    }
}
