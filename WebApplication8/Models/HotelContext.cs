using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication8.Models;

public partial class HotelContext : DbContext
{
    public HotelContext()
    {
    }

    public HotelContext(DbContextOptions<HotelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Emploee> Emploees { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Registration> Registrations { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Сustomer> Сustomers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=WIN-OLRQJ0R85GJ; Initial Catalog=Hotel;Integrated Security=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Emploee>(entity =>
        {
            entity.ToTable("Emploee");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("position");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.ToTable("Position");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Position1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("position");
            entity.Property(e => e.Salary)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("salary");
        });

        modelBuilder.Entity<Registration>(entity =>
        {
            entity.ToTable("Registration");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CheckIn)
                .HasColumnType("datetime")
                .HasColumnName("check_in");
            entity.Property(e => e.CheckOut)
                .HasColumnType("datetime")
                .HasColumnName("check_out");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.RoomNumber).HasColumnName("room_number");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("surname");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Registration)
                .HasForeignKey<Registration>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Registration_Rooms");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.RoomNumber).HasColumnName("room_number");
            entity.Property(e => e.Sleeps).HasColumnName("sleeps");
        });

        modelBuilder.Entity<Сustomer>(entity =>
        {
            entity.ToTable("Сustomer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("gender");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.RoomNumber).HasColumnName("room_number");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("surname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
