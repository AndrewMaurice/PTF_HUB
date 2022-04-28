using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PtfHub.Domain.Entities
{
    public partial class PTFContext : DbContext
    {
        public PTFContext()
        {
        }

        public PTFContext(DbContextOptions<PTFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Meeting> Meetings { get; set; }
        public virtual DbSet<MeetingAttendance> MeetingAttendances { get; set; }
        public virtual DbSet<MeetingType> MeetingTypes { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Speaker> Speakers { get; set; }
        public virtual DbSet<University> Universities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=PTF;User Id=SA;Password=Strong.Pwd-123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Education>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("Education");

                entity.Property(e => e.Guid)
                    .ValueGeneratedNever()
                    .HasColumnName("GUID");

                entity.Property(e => e.UpdatedTime)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.University)
                    .WithMany(p => p.Educations)
                    .HasForeignKey(d => d.UniversityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Education_University");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("Location");

                entity.Property(e => e.Guid)
                    .ValueGeneratedNever()
                    .HasColumnName("GUID");

                entity.Property(e => e.ContactPersonName).HasMaxLength(50);

                entity.Property(e => e.ContactPersonNumber).HasMaxLength(50);

                entity.Property(e => e.GoogleMapsUrl).HasColumnName("GoogleMapsURL");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Meeting>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("Meeting");

                entity.Property(e => e.Guid)
                    .ValueGeneratedNever()
                    .HasColumnName("GUID");

                entity.Property(e => e.CancelationReason).HasMaxLength(50);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Meetings)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meeting_Location");

                entity.HasOne(d => d.Speaker)
                    .WithMany(p => p.Meetings)
                    .HasForeignKey(d => d.SpeakerId)
                    .HasConstraintName("FK_Meeting_Speaker");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Meetings)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meeting_MeetingType");
            });

            modelBuilder.Entity<MeetingAttendance>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("MeetingAttendance");

                entity.Property(e => e.Guid)
                    .ValueGeneratedNever()
                    .HasColumnName("GUID");

                entity.Property(e => e.AttendanceTime).HasColumnType("datetime");

                entity.HasOne(d => d.Meeting)
                    .WithMany(p => p.MeetingAttendances)
                    .HasForeignKey(d => d.MeetingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MeetingAttendance_Meeting");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.MeetingAttendances)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MeetingAttendance_Person");
            });

            modelBuilder.Entity<MeetingType>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("MeetingType");

                entity.Property(e => e.Guid)
                    .ValueGeneratedNever()
                    .HasColumnName("GUID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("Person");

                entity.Property(e => e.Guid)
                    .ValueGeneratedNever()
                    .HasColumnName("GUID");

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.City).IsRequired();

                entity.Property(e => e.Country).IsRequired();

                entity.Property(e => e.FacebookUrl).HasColumnName("FacebookURL");

                entity.Property(e => e.FullName).IsRequired();

                entity.Property(e => e.Gender).IsRequired();

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.MobileNumber1).IsRequired();

                entity.HasOne(d => d.Education)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.EducationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Person_Education");
            });

            modelBuilder.Entity<Speaker>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("Speaker");

                entity.Property(e => e.Guid)
                    .ValueGeneratedNever()
                    .HasColumnName("GUID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<University>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("University");

                entity.Property(e => e.Guid)
                    .ValueGeneratedNever()
                    .HasColumnName("GUID");

                entity.Property(e => e.Faculty)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
