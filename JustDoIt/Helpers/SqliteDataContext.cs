using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustDoIt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JustDoIt.Helpers
{
    public class SqliteDataContext : AplicationContext
    {
        private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=NotesDB;Trusted_Connection=True;MultipleActiveResultSets=true";
        public SqliteDataContext(IConfiguration configuration) : base(configuration) { }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
        }

    }
}
