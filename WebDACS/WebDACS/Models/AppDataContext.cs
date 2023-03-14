using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebDACS.Models
{
    public class AppDataContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Film_Category> Film_Category { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Role> Roless { get; set; }
        public DbSet<Users> Useries { get; set; }
        public DbSet<CMT> Comment { get; set; }
        public DbSet<EpisodeFilm> EpisodeFilms { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public AppDataContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static AppDataContext Create()
        {
            return new AppDataContext();
        }
    }
}