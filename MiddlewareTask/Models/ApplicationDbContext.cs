﻿using Microsoft.EntityFrameworkCore;

namespace MiddlewareTask.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }

    }
}
