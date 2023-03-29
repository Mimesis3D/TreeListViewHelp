using Microsoft.EntityFrameworkCore;

namespace EntityFramework
{
    public class MainDbContextFactory
    {
        private readonly DbContextOptions _options;

        public MainDbContextFactory(DbContextOptions options)
        {
            _options = options;
        }
        public MainDbContext Create()
        {
            return new MainDbContext(_options);
        }
    }
}
