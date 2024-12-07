using Demo.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Demo.EF
{
    public class DemoContext:DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options):base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
