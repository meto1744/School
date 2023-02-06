using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebAppDog.Domain;
using WebAppDog.Models;

namespace WebAppDog.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<WebAppDog.Models.DogCreateViewModel> DogCreateViewModel { get; set; }
        public DbSet<WebAppDog.Models.DogDetailsViewModels> DogDetailsViewModels { get; set; }
        public DbSet<WebAppDog.Models.DogDetailsViewModel> DogDetailsViewModel { get; set; }
    }
}
