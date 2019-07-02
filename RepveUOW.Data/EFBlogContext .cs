using RepveUOW.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepveUOW.Data
{
    public class EFBlogContext : DbContext
    {
        public EFBlogContext()
        : base("data source=MEHMET-PC;initial catalog=BlogContext;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // İlişkileri kuruyoruz one-to-many olarak.
            modelBuilder.Entity<Article>()
            .HasRequired<Category>(x => x.Category)
            .WithMany(x => x.Articles)
            .HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<Article>()
            .HasRequired<User>(x => x.User)
            .WithMany(x => x.Articles)
            .HasForeignKey(x => x.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
