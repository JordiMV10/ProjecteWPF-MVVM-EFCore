using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Project.Lib.DAL.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjecteMVVMWPFNou
{
    class TestConnection : IDisposable
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


        }

        public void Dispose()
        {
            _connection.Close();
        }

        

    }
}
