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

        public ProjectDbContext(DbContextOptions _options) //Nuevo para probar Test MEU : OK
           // : base(_options) 
        {
                
        }
        
        public ProjectDbContext()     //Meu para probar bbdd : OK
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Entity>()
                .Ignore(x => x.CurrentValidation);
        }

        static string DbConnection = "Data Source=C:\\Users\\jordi\\source\\repos\\ProjecteMVVMWPFNou\\ProjecteMVVMWPFNou\\ProjecteFinalMVVM2.db";
        static string AssemblyName = "ProjecteMVVMWPFNou";


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

            => optionsBuilder.UseSqlite(DbConnection, b => b.MigrationsAssembly(AssemblyName));


        //internal bool ContainsKey(Guid id)  //Seguir Aquí !!!!...No utilizado. Existe método DbSetContainsKey en Generic Repository
        //{
        //    throw new NotImplementedException();
        //}

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProjectDbContext>(options => options.UseSqlite("Data Source=ProjecteFinalMVVM2.db"));
        }
    }
}
