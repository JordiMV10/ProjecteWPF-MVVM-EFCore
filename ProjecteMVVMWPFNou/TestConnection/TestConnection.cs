using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Project.Lib.DAL.EFCore.Context;
using Project.Lib.Models;
using System;

namespace ProjecteMVVMWPFNou
{
    public class TestConnection : IDisposable
    {
        private readonly SqliteConnection _connection;
        private readonly DbContextOptions _options;

        public TestConnection()
        {
            _connection = new SqliteConnection("datasource=C:\\Users\\jordi\\source\\repos\\ProjecteMVVMWPFNou\\ProjecteMVVMWPFNou\\ProjecteFinalMVVM.db");
            _connection.Open();

            _options = new DbContextOptionsBuilder()
                .UseSqlite(_connection)
                .Options;

            using (var context = new ProjectDbContext(_options))
                context.Database.EnsureCreated();


            using (var context = new ProjectDbContext(_options))
            {
                var nopuedorr= context.Database.CanConnect();
                var provider = context.Database.ProviderName;

                var student = new Student()
                {
                    Dni = "12345DniTest",
                    Name = "Nombre de Test",
                    ChairNumber = 26,

                };
                context.Set<Student>().Add(student);
                context.SaveChanges();
               
                
                
            }

            
            

            _connection.Close();
        }

        public void Dispose()
        {
            _connection.Close();
        }

       

    }
}
