using System.IO;
using System;
using System.Windows;
using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Docking;
using DevExpress.Xpf.Prism;
using DryIoc;
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using TreeListViewControlExample.Views;
using Microsoft.EntityFrameworkCore.Internal;
using EntityFramework.Utilities.Generators;

namespace TreeListViewControlExample
{
    public partial class App
    {
        private readonly MainDbContextFactory _mainDbContextFactory;
        private readonly string? _connectionString;
        public App()
        {
            var splashScreenViewModel = new DXSplashScreenViewModel() { Title = "Example" };
            SplashScreenManager.Create(() => new SplashScreen(), splashScreenViewModel).ShowOnStartup();
            var dbDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                @"\DevExpressHelpMe\db\";

            if (!Directory.Exists(dbDirectory))
            {
                Directory.CreateDirectory(dbDirectory);
            }

            _connectionString = "Data Source=" + dbDirectory + "Example.db";
            _mainDbContextFactory = new MainDbContextFactory(
                new DbContextOptionsBuilder().EnableSensitiveDataLogging(true).UseSqlite(_connectionString).Options);
        }
        protected override Window CreateShell()
        {
            return Container.Resolve<ShellWindowView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<DbContext, MainDbContext>();

            containerRegistry.RegisterSingleton<DbContextOptions>(() => new DbContextOptionsBuilder().UseSqlite(_connectionString).Options);
            containerRegistry.RegisterSingleton<MainDbContextFactory>();
            containerRegistry.RegisterSingleton<IDbContextFactory<MainDbContext>, DbContextFactory<MainDbContext>>();
        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<MainModule>();
        }
        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            var factory = Container.Resolve<IRegionBehaviorFactory>();
            regionAdapterMappings.RegisterMapping(typeof(LayoutPanel), AdapterFactory.Make<RegionAdapterBase<LayoutPanel>>(factory));
            regionAdapterMappings.RegisterMapping(typeof(LayoutGroup), AdapterFactory.Make<RegionAdapterBase<LayoutGroup>>(factory));
            regionAdapterMappings.RegisterMapping(typeof(TabbedGroup), AdapterFactory.Make<RegionAdapterBase<TabbedGroup>>(factory));
            regionAdapterMappings.RegisterMapping(typeof(DocumentGroup), AdapterFactory.Make<RegionAdapterBase<DocumentGroup>>(factory));
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            using (MainDbContext context = _mainDbContextFactory.Create())
            {
                context.Database.Migrate();
                new InitializeTableData(context).InitializeDataBaseCommand.Execute();
            }
            base.OnStartup(e);
        }
    }
}
