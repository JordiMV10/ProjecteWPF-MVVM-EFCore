using Common.Lib.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Project.Lib.Models;
using System;


namespace Project.Lib.DAL.EFCore.Context
{
    public class ProjectDbContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options)
        {
        }

        public ProjectDbContext(DbContextOptions _options) //Nuevo para probar Test MEU
           // : base(_options) 
        {
                
        }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Entity>()
                .Ignore(x => x.CurrentValidation);
        }

        static string DbConnection = "Data Source=C:\\Users\\jordi\\source\\repos\\ProjecteMVVMWPFNou\\ProjecteMVVMWPFNou\\ProjecteFinalMVVM.db";
        static string AssemblyName = "ProjecteMVVMWPFNou";


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

            => optionsBuilder.UseSqlite(DbConnection, b => b.MigrationsAssembly(AssemblyName));


        internal bool ContainsKey(Guid id)  //Seguir Aquí !!!!
        {
            throw new NotImplementedException();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProjectDbContext>(options => options.UseSqlite("Data Source=ProjecteFinalMVVM.db"));
        }
    }
}
