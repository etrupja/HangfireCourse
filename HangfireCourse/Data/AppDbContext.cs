using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HangfireCourse.Models;
using Microsoft.EntityFrameworkCore;

namespace HangfireCourse.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }

        public DbSet<User> Users { get; set; }

    }
}
