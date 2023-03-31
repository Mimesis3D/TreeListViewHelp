using System;
using System.Threading.Tasks;
using EntityFramework.DTOs;
using EntityFramework.Utilities.Generators.Base;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Utilities.Generators
{
    public class SessionsTableSeedGtr : TableSeedGtrBase
    {
        public SessionsTableSeedGtr(DbContext dbContext) : base(dbContext)
        {

        }
        public override async ValueTask InitializeDataTable()
        {
            if (_dbContext == null)
                return;
            var _icon = await _dbContext.Set<IconDTO>().FirstOrDefaultAsync(x => x.FileName == "icons8-document.svg");
            if ((await _dbContext.Set<SessionDTO>().ToListAsync()).Count < 1)
            {
                int i = 1;
                while (i < 26)
                {
                    var newSession = new SessionDTO()
                    {
                        Id = Guid.NewGuid(),
                        SessionName = $"Session-{i}",
                        DisplayName = $"Session-{i}",
                        Comments = "System Generated",
                        Description = $"Session-{i} Description",
                        IconId = _icon.Id,
                        Icon = _icon.Data,
                        CreationDate = DateTime.UtcNow,
                        ModifiedDate = DateTime.UtcNow
                    };
                    await _dbContext.Set<SessionDTO>().AddAsync(newSession);
                    await _dbContext.SaveChangesAsync();
                    i++;
                }
            }
        }
    }
}
