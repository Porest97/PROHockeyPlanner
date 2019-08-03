using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PROHockeyPlanner.Models.DataModels;

namespace PROHockeyPlanner.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PROHockeyPlanner.Models.DataModels.Club> Club { get; set; }
        public DbSet<PROHockeyPlanner.Models.DataModels.Company> Company { get; set; }
        public DbSet<PROHockeyPlanner.Models.DataModels.Country> Country { get; set; }
        public DbSet<PROHockeyPlanner.Models.DataModels.District> District { get; set; }
        public DbSet<PROHockeyPlanner.Models.DataModels.Person> Person { get; set; }
        public DbSet<PROHockeyPlanner.Models.DataModels.PersonType> PersonType { get; set; }
        public DbSet<PROHockeyPlanner.Models.DataModels.RefCategory> RefCategory { get; set; }
        public DbSet<PROHockeyPlanner.Models.DataModels.Referee> Referee { get; set; }
        public DbSet<PROHockeyPlanner.Models.DataModels.RefType> RefType { get; set; }
    }
}
