using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAppVaccineAPI.Models
{
    public partial class VaccineManagementDbContext : DbContext
    {
        public VaccineManagementDbContext()
        {
        }

        public VaccineManagementDbContext(DbContextOptions<VaccineManagementDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<BookForVaccine> BookForVaccines { get; set; } = null!;
        public virtual DbSet<DateTimeSlot> DateTimeSlots { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<StatusOfVaccine> StatusOfVaccines { get; set; } = null!;
        public virtual DbSet<UserDetail> UserDetails { get; set; } = null!;
        public virtual DbSet<VaccineDetail> VaccineDetails { get; set; } = null!;
        public virtual DbSet<VaccineDose> VaccineDoses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=DESKTOP-HA09QBK;Initial Catalog=VaccineManagementDb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<BookForVaccine>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("PK__BookForV__73951AEDC628B4D7");

                entity.ToTable("BookForVaccine");

                entity.Property(e => e.CityName).HasMaxLength(50);

                entity.Property(e => e.DatetimeId).HasColumnName("DatetimeID");

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.NumberOfDose).HasDefaultValueSql("((0))");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Not Done')");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VaccineName).HasMaxLength(100);

                entity.HasOne(d => d.CityNameNavigation)
                    .WithMany(p => p.BookForVaccines)
                    .HasForeignKey(d => d.CityName)
                    .HasConstraintName("FK__BookForVa__CityN__10566F31");

                entity.HasOne(d => d.Datetime)
                    .WithMany(p => p.BookForVaccines)
                    .HasForeignKey(d => d.DatetimeId)
                    .HasConstraintName("FK__BookForVa__Datet__123EB7A3");

                entity.HasOne(d => d.NumberOfDoseNavigation)
                    .WithMany(p => p.BookForVaccines)
                    .HasForeignKey(d => d.NumberOfDose)
                    .HasConstraintName("FK__BookForVa__Numbe__1332DBDC");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.BookForVaccines)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK__BookForVa__Statu__151B244E");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BookForVaccines)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__BookForVa__UserI__114A936A");

                entity.HasOne(d => d.VaccineNameNavigation)
                    .WithMany(p => p.BookForVaccines)
                    .HasForeignKey(d => d.VaccineName)
                    .HasConstraintName("FK__BookForVa__Vacci__0F624AF8");
            });

            modelBuilder.Entity<DateTimeSlot>(entity =>
            {
                entity.HasKey(e => e.DatetimeId)
                    .HasName("PK__DateTime__9211FB56F243E2B2");

                entity.HasIndex(e => e.DateTimings, "UQ__DateTime__BC397B5F2D06B6C4")
                    .IsUnique();

                entity.Property(e => e.DatetimeId).HasColumnName("DatetimeID");

                entity.Property(e => e.DateTimings).HasColumnType("datetime");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.CityName)
                    .HasName("PK__Location__886159E462321F20");

                entity.ToTable("Location");

                entity.Property(e => e.CityName).HasMaxLength(50);

                entity.Property(e => e.CityId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CityID");
            });

            modelBuilder.Entity<StatusOfVaccine>(entity =>
            {
                entity.HasKey(e => e.Status)
                    .HasName("PK__StatusOf__3A15923ED9E64AD9");

                entity.ToTable("StatusOfVaccine");

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserDeta__1788CCACC32F2ED8");

                entity.HasIndex(e => e.Username, "UQ__UserDeta__536C85E4CE0EAE7E")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<VaccineDetail>(entity =>
            {
                entity.HasKey(e => e.VaccineName)
                    .HasName("PK__VaccineD__CAD609D42B9B8716");

                entity.Property(e => e.VaccineName).HasMaxLength(100);

                entity.Property(e => e.Manufacturer).HasMaxLength(100);

                //entity.Property(e => e.VaccineId)
                //    .ValueGeneratedOnAdd()
                //    .HasColumnName("VaccineID");
            });

            modelBuilder.Entity<VaccineDose>(entity =>
            {
                entity.HasKey(e => e.NumberOfDose)
                    .HasName("PK__VaccineD__B0E64115809899E6");

                entity.ToTable("VaccineDose");

                entity.Property(e => e.NumberOfDose).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
