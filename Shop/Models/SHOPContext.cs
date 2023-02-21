using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Shop.Models
{
    public partial class SHOPContext : DbContext
    {
        public static string ConnectionString{private get; set; }
        public SHOPContext()
        {
            this.Database.EnsureCreated();
        }

        public SHOPContext(DbContextOptions<SHOPContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public virtual DbSet<TblCart> TblCart { get; set; }
        public virtual DbSet<TblCategory> TblCategory { get; set; }
        public virtual DbSet<TblOrder> TblOrder { get; set; }
        public virtual DbSet<TblOrderProduct> TblOrderProduct { get; set; }
        public virtual DbSet<TblProduct> TblProduct { get; set; }
        public virtual DbSet<TblReviwes> TblReviwes { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //this.Database.EnsureCreated();
            //if (!optionsBuilder.IsConfigured)
            //{
            //   optionsBuilder.UseSqlServer(ConnectionString);
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<TblCart>(entity =>
            {
                entity.HasKey(e => e.CartId);

                entity.ToTable("tblCart");

                entity.Property(e => e.CartId).HasColumnName("cartId");

                entity.Property(e => e.ProductColor)
                    .HasColumnName("productColor")
                    .IsUnicode(false);

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.ProductPrice)
                    .HasColumnName("productPrice")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductQty).HasColumnName("productQty");

                entity.Property(e => e.ProductSize)
                    .HasColumnName("productSize")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SubTotal)
                    .HasColumnName("subTotal")
                    .IsUnicode(false);

                entity.Property(e => e.TotalPrice)
                    .HasColumnName("totalPrice")
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblCart)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_tblCart_tblProduct");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblCart)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_tblCart_tblUser");
            });

            modelBuilder.Entity<TblCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("tblCategory");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("categoryId").HasColumnName("categoryId");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("categoryName")
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("tblOrder");

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.Property(e => e.CustomerAddress).HasColumnName("customerAddress");

                entity.Property(e => e.CustomerEmail)
                    .HasColumnName("customerEmail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .HasColumnName("customerName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerPhoneNo)
                    .HasColumnName("customerPhoneNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerZipCode)
                    .HasColumnName("customerZipCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateTimeStamp)
                    .HasColumnName("dateTImeStamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.DelieveryCharges)
                    .HasColumnName("delieveryCharges")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblOrder)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_tblOrder_tblUser");
            });

            modelBuilder.Entity<TblOrderProduct>(entity =>
            {
                entity.HasKey(e => e.OrderProductId)
                    .HasName("PK_tblorderProduct");

                entity.ToTable("tblOrderProduct");

                entity.Property(e => e.OrderProductId).HasColumnName("orderProductId");

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.Property(e => e.OrderProductColor)
                    .HasColumnName("orderProductColor")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.OrderProductQty)
                    .HasColumnName("orderProductQty")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.OrderProductSize)
                    .HasColumnName("orderProductSize")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.TblOrderProduct)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_tblorderProduct_tblOrder");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblOrderProduct)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_tblorderProduct_tblProduct");
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("tblProduct");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.Image)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IsFeatured).HasColumnName("isFeatured");

                entity.Property(e => e.ProductColor)
                    .HasColumnName("productColor")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasColumnName("productName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductPrice)
                    .HasColumnName("productPrice")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProductQty)
                    .HasColumnName("productQty")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProductSize)
                    .HasColumnName("productSize")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblProduct)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_tblProduct_tblCategory");
            });

            modelBuilder.Entity<TblReviwes>(entity =>
            {
                entity.HasKey(e => e.ReviweId)
                    .HasName("PK_tblreviwes");

                entity.ToTable("tblReviwes");

                entity.Property(e => e.ReviweId).HasColumnName("reviweId");

                entity.Property(e => e.Comments).HasColumnName("comments");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.Stars).HasColumnName("stars");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblReviwes)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_tblreviwes_tblProduct");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblReviwes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_tblreviwes_tblUser");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("tblUser");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fname)
                    .HasColumnName("fname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .HasColumnName("lname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NewsLetter).HasColumnName("newsLetter");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserType).HasColumnName("userType");
            });
        }
    }
}
