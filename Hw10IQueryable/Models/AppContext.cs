﻿using Microsoft.EntityFrameworkCore;

namespace Hw10IQueryable.Models
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
        }
        
        public DbSet<ExpressionModel> ExpressionCache { get; set; }
    }
}