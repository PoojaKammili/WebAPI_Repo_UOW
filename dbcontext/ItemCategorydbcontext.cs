using Microsoft.EntityFrameworkCore;
using WebAPI_Repo__UOW_.Models;

namespace WebAPI_Repo__UOW_.dbcontext
{
    public class ItemCategorydbcontext : DbContext
    {
        public ItemCategorydbcontext(DbContextOptions<ItemCategorydbcontext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Items)
                .WithOne(i => i.Category)
                .HasForeignKey(i => i.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
