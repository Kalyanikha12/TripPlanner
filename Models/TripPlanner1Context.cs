using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TripPlanner_1.Models;

public partial class TripPlanner1Context : DbContext
{
    public TripPlanner1Context()
    {
    }

    public TripPlanner1Context(DbContextOptions<TripPlanner1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Holidaydestination> Holidaydestinations { get; set; }

    public virtual DbSet<Holidaydestinationtransport> Holidaydestinationtransports { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Transport> Transports { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userhotelbooking> Userhotelbookings { get; set; }

    public virtual DbSet<Usertransport> Usertransports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=Trip-Planner1;Username=postgres;Password=Kalyani@12;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Holidaydestination>(entity =>
        {
            entity.HasKey(e => e.Destinationid).HasName("holidaydestination_pkey");

            entity.ToTable("holidaydestination");

            entity.Property(e => e.Destinationid).HasColumnName("destinationid");
            entity.Property(e => e.DestinationName)
                .HasMaxLength(255)
                .HasColumnName("destination_name");
            entity.Property(e => e.Discription).HasColumnName("discription");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
        });

        modelBuilder.Entity<Holidaydestinationtransport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("holidaydestinationtransport_pkey");

            entity.ToTable("holidaydestinationtransport");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Destinationid).HasColumnName("destinationid");
            entity.Property(e => e.Transportid).HasColumnName("transportid");

            entity.HasOne(d => d.Destination).WithMany(p => p.Holidaydestinationtransports)
                .HasForeignKey(d => d.Destinationid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("holidaydestinationtransport_destinationid_fkey");

            entity.HasOne(d => d.Transport).WithMany(p => p.Holidaydestinationtransports)
                .HasForeignKey(d => d.Transportid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("holidaydestinationtransport_transportid_fkey");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.Hotelid).HasName("hotel_pkey");

            entity.ToTable("hotel");

            entity.Property(e => e.Hotelid).HasColumnName("hotelid");
            entity.Property(e => e.Destinationid).HasColumnName("destinationid");
            entity.Property(e => e.Discription).HasColumnName("discription");
            entity.Property(e => e.Hotelimage).HasColumnName("hotelimage");
            entity.Property(e => e.Hotelname)
                .HasMaxLength(255)
                .HasColumnName("hotelname");
            entity.Property(e => e.Pricepernight)
                .HasPrecision(10, 2)
                .HasColumnName("pricepernight");

            entity.HasOne(d => d.Destination).WithMany(p => p.Hotels)
                .HasForeignKey(d => d.Destinationid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hotel_destinationid_fkey");
        });

        modelBuilder.Entity<Transport>(entity =>
        {
            entity.HasKey(e => e.Transportid).HasName("transport_pkey");

            entity.ToTable("transport");

            entity.Property(e => e.Transportid).HasColumnName("transportid");
            entity.Property(e => e.Cost)
                .HasPrecision(10, 2)
                .HasColumnName("cost");
            entity.Property(e => e.Modeoftransport)
                .HasMaxLength(255)
                .HasColumnName("modeoftransport");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("User_pkey");

            entity.ToTable("User");

            entity.HasIndex(e => e.Useremail, "User_useremail_key").IsUnique();

            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Mobileno)
                .HasMaxLength(15)
                .HasColumnName("mobileno");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Useremail)
                .HasMaxLength(255)
                .HasColumnName("useremail");
        });

        modelBuilder.Entity<Userhotelbooking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("userhotelbooking_pkey");

            entity.ToTable("userhotelbooking");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CheckInDate).HasColumnName("check_in_date");
            entity.Property(e => e.CheckOutDate).HasColumnName("check_out_date");
            entity.Property(e => e.Hotelid).HasColumnName("hotelid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Userhotelbookings)
                .HasForeignKey(d => d.Hotelid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userhotelbooking_hotelid_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Userhotelbookings)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userhotelbooking_userid_fkey");
        });

        modelBuilder.Entity<Usertransport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usertransport_pkey");

            entity.ToTable("usertransport");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Transportid).HasColumnName("transportid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Transport).WithMany(p => p.Usertransports)
                .HasForeignKey(d => d.Transportid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usertransport_transportid_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Usertransports)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usertransport_userid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
