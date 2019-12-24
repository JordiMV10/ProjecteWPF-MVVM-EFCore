using Common.Lib.Core;
using Common.Lib.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Project.Lib.DAL.EFCore.Context;
using ProjecteMVVMWPFNou.Boot;
using System;
using System.Configuration;
using System.Windows;

namespace ProjecteMVVMWPFNou
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var bootstrapper = new Bootstrapper();

            
            //var dbConnection = ConfigurationManager.ConnectionStrings["ProjecteMVVMDb"].ConnectionString;
            var dbConnection = ConfigurationManager.ConnectionStrings["ProjecteMVVMDb"].ConnectionString;

            Entity.DepCon = new SimpleDependencyContainer();
            bootstrapper.Init(Entity.DepCon, GetDbConstructor(dbConnection));


            InitializeComponent();
        }

        private static Func<ProjectDbContext> GetDbConstructor(string dbConnection)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProjectDbContext>();
            
            optionsBuilder.UseSqlite("Data Source=ProjecteFinalMVVM.db");
            var dbContextConst = new Func<ProjectDbContext>(() =>
            {
                return new ProjectDbContext(optionsBuilder.Options);
                // return new ProjectDbContext();
            });
            return dbContextConst;




            //using (var dbContext = new ProjectDbContext(optionsBuilder.Options))
            //{
            //    dbContext.Database.Migrate();
            //}



        }



        // info de  : https://docs.microsoft.com/es-es/ef/core/miscellaneous/configuring-dbcontext
        //var optionsBuilder = new DbContextOptionsBuilder<BloggingContext>();
        //optionsBuilder.UseSqlite("Data Source=blog.db");

        //using (var context = new BloggingContext(optionsBuilder.Options))
        //{
        //  // do stuff
        //}

    }
}
