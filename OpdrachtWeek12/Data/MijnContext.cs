using Microsoft.EntityFrameworkCore;
using OpdrachtWeek12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpdrachtWeek12.Data
{
    public class MijnContext : DbContext
    {

        public MijnContext(DbContextOptions options) : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder b) =>
        //b.UseSqlite("Data Source=database.db");
        b.UseInMemoryDatabase("Studenten");
        public DbSet<Student> Studenten { get; set; }
    }
}
