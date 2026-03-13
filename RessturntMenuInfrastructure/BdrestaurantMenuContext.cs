using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using RestaurantMenuDomain.Model;

namespace RestaurantMenuInfrastructure;

public partial class BdrestaurantMenuContext : DbContext
{
    public BdrestaurantMenuContext()
    {
    }

    public BdrestaurantMenuContext(DbContextOptions<BdrestaurantMenuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Category { get; set; }

    public virtual DbSet<Discount> Discount { get; set; }

    public virtual DbSet<Product> Product { get; set; }

    public virtual DbSet<ProductDiscount> ProductDiscount { get; set; }

    public virtual DbSet<Review> Review { get; set; }

    public virtual DbSet<User> User { get; set; }

    public virtual DbSet<UserProduct> UserProducts{ get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-9MD6D8G\\SQLEXPRESS; Database=BDRestaurantMenu; Trusted_Connection=True; TrustServerCertificate=True; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("CATEGORIES");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.ToTable("DISCOUNTS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("description");
            entity.Property(e => e.Period)
                .HasColumnType("datetime")
                .HasColumnName("period");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("PRODUCTS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.Categories).WithMany(p => p.Products)
                .HasForeignKey(d => d.Categoriesid)
                .HasConstraintName("FK_PRODUCTS_CATEGORIES");
        });

        modelBuilder.Entity<ProductDiscount>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PRODUCT DISCOUNTS");

            entity.HasOne(d => d.Discounts).WithMany()
                .HasForeignKey(d => d.Discountsid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRODUCT DISCOUNTS_DISCOUNTS");

            entity.HasOne(d => d.Products).WithMany()
                .HasForeignKey(d => d.Productsid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRODUCT DISCOUNTS_PRODUCTS");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.ToTable("REVIEWS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment)
                .HasMaxLength(150)
                .HasColumnName("comment");
            entity.Property(e => e.Data)
                .HasColumnType("datetime")
                .HasColumnName("data");
            entity.Property(e => e.Mark)
                .HasColumnType("numeric(2, 1)")
                .HasColumnName("mark");

            entity.HasOne(d => d.Products).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.Productsid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_REVIEWS_PRODUCTS");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("USERS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Number)
                .HasMaxLength(50)
                .HasColumnName("number");
        });

        modelBuilder.Entity<UserProduct>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("USER PRODUCTS");

            entity.HasOne(d => d.Products).WithMany()
                .HasForeignKey(d => d.Productsid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USER PRODUCTS_PRODUCTS1");

            entity.HasOne(d => d.Users).WithMany()
                .HasForeignKey(d => d.Usersid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USER PRODUCTS_USERS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
