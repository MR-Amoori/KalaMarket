using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalaMarket.DataLayer.Entities;
using KalaMarket.DataLayer.Entities.Product;
using KalaMarket.DataLayer.Entities.Product.FaQ;
using Microsoft.EntityFrameworkCore;

namespace KalaMarket.DataLayer.Context
{
    public class KalaMarketContext : DbContext
    {
        public KalaMarketContext(DbContextOptions<KalaMarketContext> options) : base(options)
        {

        }

        public DbSet<MainSlider> MainSliders { get; set; }

        #region FaQ

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Question> Questions { get; set; }

        #endregion

        #region Product

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductGallery> ProductGalleries { get; set; }
        public DbSet<ProductGarranty> ProductGarranties { get; set; }
        public DbSet<PropertyName> PropertyNames { get; set; }
        public DbSet<PropertyNameToCategory> PropertyNameToCategories { get; set; }
        public DbSet<PropertyValue> PropertyValues { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }

        #endregion

        #region User
        public DbSet<User> Users { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var forieng = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in forieng)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}