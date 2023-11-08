using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIs.Models;

public partial class Prn231projectContext : DbContext
{
    public Prn231projectContext()
    {
    }

    public Prn231projectContext(DbContextOptions<Prn231projectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    public virtual DbSet<Show> Shows { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server = ADMIN; database = PRN231PROJECT;uid=sa;pwd=123;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("PK__Bills__11F2FC6A94BF66DF");

            entity.HasOne(d => d.Seat).WithMany(p => p.Bills)
                .HasForeignKey(d => d.SeatId)
                .HasConstraintName("FK__Bills__SeatId__33D4B598");

            entity.HasOne(d => d.Show).WithMany(p => p.Bills)
                .HasForeignKey(d => d.ShowId)
                .HasConstraintName("FK__Bills__ShowId__35BCFE0A");

            entity.HasOne(d => d.User).WithMany(p => p.Bills)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Bills__UserId__34C8D9D1");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.MovieId).HasName("PK__Movies__4BD2941AEC817DDE");

            entity.Property(e => e.IsReleased).HasColumnName("isReleased");
            entity.Property(e => e.Title).HasMaxLength(100);
            entity.Property(e => e.Urlimages)
                .HasMaxLength(100)
                .HasColumnName("URLImages");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1AA145FE30");

            entity.Property(e => e.RoleName).HasMaxLength(100);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__Rooms__32863939C3F2DB25");

            entity.Property(e => e.RoomName).HasMaxLength(100);
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.HasKey(e => e.SeatId).HasName("PK__Seats__311713F3783A0103");

            entity.Property(e => e.SeatName).HasMaxLength(50);
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Room).WithMany(p => p.Seats)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__Seats__RoomId__2B3F6F97");
        });

        modelBuilder.Entity<Show>(entity =>
        {
            entity.HasKey(e => e.ShowId).HasName("PK__Shows__6DE3E0B21AE72DB5");

            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.Prices).HasColumnType("money");
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.Movie).WithMany(p => p.Shows)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("FK__Shows__MovieId__300424B4");

            entity.HasOne(d => d.Room).WithMany(p => p.Shows)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__Shows__RoomId__30F848ED");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C91D2E553");

            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(100);
            entity.Property(e => e.Username).HasMaxLength(100);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__RoleId__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
