using Common.Lib.Core.Context.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Project.Lib.DAL.EFCore.Context;
using Project.Lib.Models;
using ProjecteMVVMWPFNou.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                var studentVM = new StudentsViewModel();
                studentVM.GetStudents();
            }

            var connState= _connection.State;
            var currDb = _connection.Database;

            _connection.Close();
        }

        public void Dispose()
        {
            _connection.Close();
        }

       

    }
}
