﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace JustDoIt.Models
{
    public class AplicationContext : DbContext
    {
        public DbSet<Users> Users { get; set; }

        public DbSet<Notes> Notes { get; set; }

        private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=NotesDB;Trusted_Connection=True;MultipleActiveResultSets=true";
        //public AplicationContext(DbContextOptions<AplicationContext> options)
        //    : base(options)
        //{
           

        //}
        protected readonly IConfiguration Configuration;

        public AplicationContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasData(
            new Users
            {
                Id = 1,
                FirstName = "Mykhailo",
                SecondName = "Shastun",
                Age = 18,
                PasswordHash = new byte[] {1,2, 3, 4, 5, 6 },
                Email = "qwert@gmail.com"
            },
            new Users
            {
                Id = 2,
                FirstName = "Volodymyr",
                SecondName = "Sydorko",
                Age = 18,
                PasswordHash = new byte[] { 1, 2, 3, 4, 5, 6 },
                Email = "qwer@gmail.com"

            },
                new Users
                {
                    Id = 3,
                    FirstName = "Vadym",
                    SecondName = "Pyshniak",
                    Age = 18,
                    PasswordHash = new byte[] { 1, 2, 3, 4, 5, 6 },
                    Email = "qwerty@gmail.com"

                }

            );
            modelBuilder.Entity<Notes>().HasData(

                    new Notes
                    {
                        Id = 1,
                        Date = new DateTime(2012, 01, 02),
                        UserId = 1,
                        Note = "Hy, today I read the book"
                    },
                    new Notes
                    {
                        Id = 2,
                        Date = new DateTime(2018, 01, 02),
                        UserId = 2,
                        Note = "Hy, today I swim"
                    },
                    new Notes
                    {
                        Id = 3,
                        Date = new DateTime(2012, 01, 02),
                        UserId = 3,
                        Note = "Hy, today I read the book and in the evening run"
                    }
                    );
        }
    }
}