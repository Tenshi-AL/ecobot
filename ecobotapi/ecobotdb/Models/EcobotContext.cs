using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ecobotdb.Models;

public partial class EcobotContext : DbContext
{
    public EcobotContext()
    {
    }

    public EcobotContext(DbContextOptions<EcobotContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Coordinate> Coordinates { get; set; }

    public virtual DbSet<FavoriteStation> FavoriteStations { get; set; }

    public virtual DbSet<Measurment> Measurments { get; set; }

    public virtual DbSet<MeasurmentUnit> MeasurmentUnits { get; set; }

    public virtual DbSet<MqttMessageUnit> MqttMessageUnits { get; set; }

    public virtual DbSet<MqttServer> MqttServers { get; set; }

    public virtual DbSet<OptimalValue> OptimalValues { get; set; }

    public virtual DbSet<Station> Stations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ecobot;Username=postgres;Password=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("category_pkey");

            entity.ToTable("category");

            entity.Property(e => e.IdCategory)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("id_category");
            entity.Property(e => e.Designation)
                .HasMaxLength(50)
                .HasColumnName("designation");
        });

        modelBuilder.Entity<Coordinate>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("coordinates");

            entity.Property(e => e.IdStation)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("id_station");
            entity.Property(e => e.Latitude).HasColumnName("latitude");
            entity.Property(e => e.Longitude).HasColumnName("longitude");

            entity.HasOne(d => d.IdStationNavigation).WithMany()
                .HasForeignKey(d => d.IdStation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_station_foreign_key");
        });

        modelBuilder.Entity<FavoriteStation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("favorite_station");

            entity.Property(e => e.IdStation)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("id_station");
            entity.Property(e => e.IdUser)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("id_user");

            entity.HasOne(d => d.IdStationNavigation).WithMany()
                .HasForeignKey(d => d.IdStation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_station_foreign_key");
        });

        modelBuilder.Entity<Measurment>(entity =>
        {
            entity.HasKey(e => e.IdMeasurment).HasName("measurment_pkey");

            entity.ToTable("measurment");

            entity.Property(e => e.IdMeasurment)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("id_measurment");
            entity.Property(e => e.CompressionLevel)
                .HasMaxLength(10)
                .HasColumnName("compression_level");
            entity.Property(e => e.IdMeasuredUnit)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("id_measured_unit");
            entity.Property(e => e.IdStation)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("id_station");
            entity.Property(e => e.Time)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("time");
            entity.Property(e => e.Value)
                .HasMaxLength(50)
                .HasColumnName("value");

            entity.HasOne(d => d.IdMeasuredUnitNavigation).WithMany(p => p.Measurments)
                .HasForeignKey(d => d.IdMeasuredUnit)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_measurment_unit_foreign_key");

            entity.HasOne(d => d.IdStationNavigation).WithMany(p => p.Measurments)
                .HasForeignKey(d => d.IdStation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_station_foreign_key");
        });

        modelBuilder.Entity<MeasurmentUnit>(entity =>
        {
            entity.HasKey(e => e.IdMeasurmentUnit).HasName("measurment_unit_pkey");

            entity.ToTable("measurment_unit");

            entity.Property(e => e.IdMeasurmentUnit)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("id_measurment_unit");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
            entity.Property(e => e.Unit)
                .HasMaxLength(50)
                .HasColumnName("unit");
        });

        modelBuilder.Entity<MqttMessageUnit>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("mqtt_message_unit");

            entity.Property(e => e.IdMeasuredUnit)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("id_measured_unit");
            entity.Property(e => e.IdStation)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("id_station");
            entity.Property(e => e.Message)
                .HasMaxLength(100)
                .HasColumnName("message");
            entity.Property(e => e.QueueNumber).HasColumnName("queue_number");

            entity.HasOne(d => d.IdMeasuredUnitNavigation).WithMany()
                .HasForeignKey(d => d.IdMeasuredUnit)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_measured_unit_foreign");

            entity.HasOne(d => d.IdStationNavigation).WithMany()
                .HasForeignKey(d => d.IdStation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_station_foreign_key");
        });

        modelBuilder.Entity<MqttServer>(entity =>
        {
            entity.HasKey(e => e.IdServer).HasName("mqtt_server_pkey");

            entity.ToTable("mqtt_server");

            entity.Property(e => e.IdServer)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("id_server");
            entity.Property(e => e.Status)
                .HasMaxLength(200)
                .HasColumnName("status");
            entity.Property(e => e.Url)
                .HasMaxLength(200)
                .HasColumnName("url");
        });

        modelBuilder.Entity<OptimalValue>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("optimal_value");

            entity.Property(e => e.BottomBorder).HasColumnName("bottom_border");
            entity.Property(e => e.IdCategory)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("id_category");
            entity.Property(e => e.IdMeasurmentUnit)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("id_measurment_unit");
            entity.Property(e => e.UpperBorder).HasColumnName("upper_border");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany()
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("id_category_foreign_key");

            entity.HasOne(d => d.IdMeasurmentUnitNavigation).WithMany()
                .HasForeignKey(d => d.IdMeasurmentUnit)
                .HasConstraintName("id_measurment_unit_foreign_key");
        });

        modelBuilder.Entity<Station>(entity =>
        {
            entity.HasKey(e => e.IdStation).HasName("station_pkey");

            entity.ToTable("station");

            entity.Property(e => e.IdStation)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("id_station");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.IdSaveecobot)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("id_saveecobot");
            entity.Property(e => e.IdServer)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("id_server");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasMaxLength(200)
                .HasColumnName("status");

            entity.HasOne(d => d.IdServerNavigation).WithMany(p => p.Stations)
                .HasForeignKey(d => d.IdServer)
                .HasConstraintName("id_server_foreign_key");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
