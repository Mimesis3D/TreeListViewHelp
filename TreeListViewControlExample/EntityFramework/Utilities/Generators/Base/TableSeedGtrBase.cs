using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Prism.Mvvm;

namespace EntityFramework.Utilities.Generators.Base
{
    public class TableSeedGtrBase : BindableBase
    {
        protected readonly DbContext? _dbContext;
        public TableSeedGtrBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async ValueTask InitializeDataTable()
        {
            await ValueTask.CompletedTask;
        }
    }
}
