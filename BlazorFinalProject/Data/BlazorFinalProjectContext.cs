using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteProgram.Models;

namespace BlazorFinalProject.Data
{
    public class BlazorFinalProjectContext : DbContext
    {
        public BlazorFinalProjectContext (DbContextOptions<BlazorFinalProjectContext> options)
            : base(options)
        {
        }

        public DbSet<TesteProgram.Models.Recipe> Recipe { get; set; } = default!;
    }
}
