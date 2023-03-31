using EntityFramework.DTOs;
using System.Threading.Tasks;
using System;
using EntityFramework.Utilities.Generators.Base;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Runtime.CompilerServices;

namespace EntityFramework.Utilities.Generators
{
    public class IconTableSeedGtr : TableSeedGtrBase
    {
        public IconTableSeedGtr(DbContext dbContext) : base(dbContext)
        {

        }
        public override async ValueTask InitializeDataTable()
        {
            if (_dbContext == null)
                return;
            if ((await _dbContext.Set<IconDTO>().ToListAsync()).Count < 1)
            {
                string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Icons", "empty-file.svg");
                byte[] imageData = File.ReadAllBytes(imagePath);
                await _dbContext.Set<IconDTO>().AddAsync(new IconDTO()
                {
                    Id = Guid.NewGuid(),
                    Data = imageData,
                    Comments = "Empty File Icon",
                    FileName = "empty-file.svg",
                    FileExtension = "svg",
                    Description = "Empty File Icon",
                    Origin = "Line Icons",
                    CreationDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow
                });
                await _dbContext.SaveChangesAsync();

                imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Icons", "icons8-atom.svg");
                imageData = File.ReadAllBytes(imagePath);
                await _dbContext.Set<IconDTO>().AddAsync(new IconDTO()
                {
                    Id = Guid.NewGuid(),
                    Data = imageData,
                    Comments = "Atom Icon",
                    FileName = "icons8-atom.svg",
                    FileExtension = "svg",
                    Description = "Atom Icon",
                    Origin = "Icons8",
                    CreationDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow
                });
                await _dbContext.SaveChangesAsync();

                imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Icons", "icons8-document.svg");
                imageData = File.ReadAllBytes(imagePath);
                await _dbContext.Set<IconDTO>().AddAsync(new IconDTO()
                {
                    Id = Guid.NewGuid(),
                    Data = imageData,
                    Comments = "Document Icon",
                    FileName = "icons8-document.svg",
                    FileExtension = "svg",
                    Description = "Document Icon",
                    Origin = "Icons8",
                    CreationDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,
                });
                await _dbContext.SaveChangesAsync();

                imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Icons", "icons8-group-of-projects.svg");
                imageData = File.ReadAllBytes(imagePath);
                await _dbContext.Set<IconDTO>().AddAsync(new IconDTO()
                {
                    Id = Guid.NewGuid(),
                    Data = imageData,
                    Comments = "Group of Projects Icon",
                    FileName = "icons8-group-of-projects.svg",
                    FileExtension = "svg",
                    Description = "Group of Projects Icon",
                    Origin = "Icons8",
                    CreationDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,

                });
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
