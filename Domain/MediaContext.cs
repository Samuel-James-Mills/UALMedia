using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MediaContext : DbContext
    {
        public MediaContext()
            : base("name=DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MediaContext, Domain.Migrations.Configuration>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<MediaContext>());
        }
            
        
        public DbSet<News> News { get; set; }
        public DbSet<Media> MediaContent { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
