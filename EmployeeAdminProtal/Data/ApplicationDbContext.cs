﻿using EmployeeAdminProtal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminProtal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
