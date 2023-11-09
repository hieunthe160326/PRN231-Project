﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class Prn231projectContext : DbContext
{
    public Prn231projectContext()
    {
    }

    public Prn231projectContext(DbContextOptions<Prn231projectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblChiTietHd> TblChiTietHds { get; set; }

    public virtual DbSet<TblHoadon> TblHoadons { get; set; }

    public virtual DbSet<TblKhachHang> TblKhachHangs { get; set; }

    public virtual DbSet<TblMatHang> TblMatHangs { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server = ADMIN; database = PRN231PROJECT;uid=sa;pwd=123;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblChiTietHd>(entity =>
        {
            entity.HasKey(e => e.MaChiTietHd).HasName("PK__tblChiTi__651E49EBDAAEFCFA");

            entity.ToTable("tblChiTietHD");

            entity.Property(e => e.MaChiTietHd)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("MaChiTietHD");
            entity.Property(e => e.MaHang)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaHd)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("MaHD");

            entity.HasOne(d => d.MaHangNavigation).WithMany(p => p.TblChiTietHds)
                .HasForeignKey(d => d.MaHang)
                .HasConstraintName("FK__tblChiTie__MaHan__2C3393D0");

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.TblChiTietHds)
                .HasForeignKey(d => d.MaHd)
                .HasConstraintName("FK__tblChiTiet__MaHD__2B3F6F97");
        });

        modelBuilder.Entity<TblHoadon>(entity =>
        {
            entity.HasKey(e => e.MaHd).HasName("PK__tblHoado__2725A6E01991ED02");

            entity.ToTable("tblHoadon");

            entity.Property(e => e.MaHd)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("MaHD");
            entity.Property(e => e.MaKh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaKH");
            entity.Property(e => e.NgayHd)
                .HasColumnType("smalldatetime")
                .HasColumnName("NgayHD");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.TblHoadons)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("FK__tblHoadon__MaKH__267ABA7A");
        });

        modelBuilder.Entity<TblKhachHang>(entity =>
        {
            entity.HasKey(e => e.MakH).HasName("PK__tblKhach__2724C376839B3070");

            entity.ToTable("tblKhachHang");

            entity.Property(e => e.MakH)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Diachi).HasMaxLength(50);
            entity.Property(e => e.Gt).HasColumnName("GT");
            entity.Property(e => e.NgaySinh).HasColumnType("smalldatetime");
            entity.Property(e => e.TenKh)
                .HasMaxLength(50)
                .HasColumnName("TenKH");
        });

        modelBuilder.Entity<TblMatHang>(entity =>
        {
            entity.HasKey(e => e.MaHang).HasName("PK__tblMatHa__19C0DB1D03E19617");

            entity.ToTable("tblMatHang");

            entity.Property(e => e.MaHang)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Dvt)
                .HasMaxLength(50)
                .HasColumnName("DVT");
            entity.Property(e => e.TenHang).HasMaxLength(50);
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblUser");

            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
