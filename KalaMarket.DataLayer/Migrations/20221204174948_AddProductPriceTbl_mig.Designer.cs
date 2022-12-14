// <auto-generated />
using System;
using KalaMarket.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KalaMarket.DataLayer.Migrations
{
    [DbContext(typeof(KalaMarketContext))]
    [Migration("20221204174948_AddProductPriceTbl_mig")]
    partial class AddProductPriceTbl_mig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.MainSlider", b =>
                {
                    b.Property<int>("SliderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("SliderAlt")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SliderImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SliderLink")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("SliderSort")
                        .HasColumnType("int");

                    b.Property<string>("SliderTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SliderId");

                    b.ToTable("MainSliders");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("SubCategory")
                        .HasColumnType("int");

                    b.Property<string>("categoriEnTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("categoriFaTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CategoryId");

                    b.HasIndex("SubCategory");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.FaQ.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AnswerDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AnswerDescription")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("AnswerId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.FaQ.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommentDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("CommentDislike")
                        .HasColumnType("int");

                    b.Property<int>("CommentLike")
                        .HasColumnType("int");

                    b.Property<string>("CommentTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<byte>("ReComment")
                        .HasColumnType("tinyint");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.FaQ.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("QuestionDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("QuestionId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOriginal")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ProductCreatDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductFaTitle")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ProductImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductSell")
                        .HasColumnType("int");

                    b.Property<byte>("ProductStar")
                        .HasColumnType("tinyint");

                    b.Property<int>("ProductWith")
                        .HasColumnType("int");

                    b.Property<string>("ProductWnTitle")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("ProductId");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.ProductColor", b =>
                {
                    b.Property<int>("ProductColorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProductColorCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ProductColorName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ProductColorId");

                    b.ToTable("ProductColors");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.ProductGallery", b =>
                {
                    b.Property<int>("ProductGalleryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageAlt")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("ProductGalleryId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductGalleries");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.ProductGarranty", b =>
                {
                    b.Property<int>("ProductGarrantyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProductGarrantyName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ProductGarrantyId");

                    b.ToTable("ProductGarranties");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.ProductPrice", b =>
                {
                    b.Property<int>("ProductPriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDateDiscount")
                        .HasColumnType("datetime2");

                    b.Property<int>("MainPrice")
                        .HasColumnType("int");

                    b.Property<int>("MaxOrderCount")
                        .HasColumnType("int");

                    b.Property<int>("ProductGarrantyId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("SpacialPrice")
                        .HasColumnType("int");

                    b.Property<int>("productColorId")
                        .HasColumnType("int");

                    b.HasKey("ProductPriceId");

                    b.HasIndex("ProductGarrantyId");

                    b.HasIndex("ProductId");

                    b.HasIndex("productColorId");

                    b.ToTable("ProductPrices");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.PropertyName", b =>
                {
                    b.Property<int>("PropertyNameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PropertyNameTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PropertyNameId");

                    b.ToTable("PropertyNames");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.PropertyNameToCategory", b =>
                {
                    b.Property<int>("PcId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("PropertyNameId")
                        .HasColumnType("int");

                    b.HasKey("PcId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PropertyNameId");

                    b.ToTable("PropertyNameToCategories");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.PropertyValue", b =>
                {
                    b.Property<int>("PropertyValueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("PropertyValueText")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PropertyValueId");

                    b.HasIndex("ProductId");

                    b.ToTable("PropertyValues");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArticleDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArticleTitle")
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ReviewDescription")
                        .HasMaxLength(15000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReviewMegative")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ReviewPositive")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("ReviewId");

                    b.HasIndex("ProductId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserFamily")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.Category", b =>
                {
                    b.HasOne("KalaMarket.DataLayer.Entities.Product.Category", "Category1")
                        .WithMany()
                        .HasForeignKey("SubCategory")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category1");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.FaQ.Answer", b =>
                {
                    b.HasOne("KalaMarket.DataLayer.Entities.Product.FaQ.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.FaQ.Comment", b =>
                {
                    b.HasOne("KalaMarket.DataLayer.Entities.Product.Product", "Product")
                        .WithMany("Comments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("KalaMarket.DataLayer.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.FaQ.Question", b =>
                {
                    b.HasOne("KalaMarket.DataLayer.Entities.Product.Product", "Product")
                        .WithMany("Questions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("KalaMarket.DataLayer.Entities.User", "User")
                        .WithMany("Questions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.Product", b =>
                {
                    b.HasOne("KalaMarket.DataLayer.Entities.Product.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("KalaMarket.DataLayer.Entities.Product.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.ProductGallery", b =>
                {
                    b.HasOne("KalaMarket.DataLayer.Entities.Product.Product", "Product")
                        .WithMany("ProductGalleries")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.ProductPrice", b =>
                {
                    b.HasOne("KalaMarket.DataLayer.Entities.Product.ProductGarranty", "ProductGarranty")
                        .WithMany("ProductPrices")
                        .HasForeignKey("ProductGarrantyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("KalaMarket.DataLayer.Entities.Product.Product", "Product")
                        .WithMany("ProductPrices")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("KalaMarket.DataLayer.Entities.Product.ProductColor", "ProductColor")
                        .WithMany("ProductPrices")
                        .HasForeignKey("productColorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ProductColor");

                    b.Navigation("ProductGarranty");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.PropertyNameToCategory", b =>
                {
                    b.HasOne("KalaMarket.DataLayer.Entities.Product.Category", "Category")
                        .WithMany("PropertyNameToCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("KalaMarket.DataLayer.Entities.Product.PropertyName", "PropertyName")
                        .WithMany("PropertyNameToCategories")
                        .HasForeignKey("PropertyNameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("PropertyName");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.PropertyValue", b =>
                {
                    b.HasOne("KalaMarket.DataLayer.Entities.Product.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.Review", b =>
                {
                    b.HasOne("KalaMarket.DataLayer.Entities.Product.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.Category", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("PropertyNameToCategories");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.FaQ.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.Product", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("ProductGalleries");

                    b.Navigation("ProductPrices");

                    b.Navigation("Questions");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.ProductColor", b =>
                {
                    b.Navigation("ProductPrices");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.ProductGarranty", b =>
                {
                    b.Navigation("ProductPrices");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.Product.PropertyName", b =>
                {
                    b.Navigation("PropertyNameToCategories");
                });

            modelBuilder.Entity("KalaMarket.DataLayer.Entities.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
