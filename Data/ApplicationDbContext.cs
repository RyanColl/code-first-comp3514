using System;
using System.Collections.Generic;
using System.Text;
using Code1st.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Code1st.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet <Player> Players { get; set; }
        
        public DbSet <Team> Teams { get; set; }



    }
}
