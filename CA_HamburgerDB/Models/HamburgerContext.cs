using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CA_HamburgerDB.Models;

public partial class HamburgerContext : DbContext
{
    public HamburgerContext()
    {
    }

    public HamburgerContext(DbContextOptions<HamburgerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Extra> Extras { get; set; }

    public virtual DbSet<Hamburger> Hamburgers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=Hamburger;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Adress)
                .HasMaxLength(255)
                .IsFixedLength();
            entity.Property(e => e.Firstname)
                .HasMaxLength(120)
                .IsFixedLength();
            entity.Property(e => e.Lastname)
                .HasMaxLength(120)
                .IsFixedLength();
        });

        modelBuilder.Entity<Extra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Extra");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(120)
                .IsFixedLength();
            entity.Property(e => e.Price).HasColumnType("money");
        });

        modelBuilder.Entity<Hamburger>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Hamburger");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(120)
                .IsFixedLength();
            entity.Property(e => e.Price).HasColumnType("money");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.CustomerId, e.HamburgerId, e.ExtraId });

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.HamburgerId).HasColumnName("HamburgerID");
            entity.Property(e => e.ExtraId).HasColumnName("ExtraID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Customers");

            entity.HasOne(d => d.Extra).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ExtraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Extras");

            entity.HasOne(d => d.Hamburger).WithMany(p => p.Orders)
                .HasForeignKey(d => d.HamburgerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Hamburgers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
