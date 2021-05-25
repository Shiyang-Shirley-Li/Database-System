using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LMS.Models.LMSModels
{
    public partial class Team2LMSContext : DbContext
    {
        public Team2LMSContext()
        {
        }

        public Team2LMSContext(DbContextOptions<Team2LMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrators> Administrators { get; set; }
        public virtual DbSet<AssignmentCategories> AssignmentCategories { get; set; }
        public virtual DbSet<Assignments> Assignments { get; set; }
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Enroll> Enroll { get; set; }
        public virtual DbSet<Professors> Professors { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Submission> Submission { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=atr.eng.utah.edu;User Id=u1160160;Password=pwd;Database=Team2LMS");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrators>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("varchar(8)");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<AssignmentCategories>(entity =>
            {
                entity.HasKey(e => e.AcId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.ClassId)
                    .HasName("classID");

                entity.HasIndex(e => new { e.Name, e.ClassId })
                    .HasName("Name")
                    .IsUnique();

                entity.Property(e => e.AcId).HasColumnName("acID");

                entity.Property(e => e.ClassId).HasColumnName("classID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.AssignmentCategories)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("AssignmentCategories_ibfk_1");
            });

            modelBuilder.Entity<Assignments>(entity =>
            {
                entity.HasKey(e => e.AsId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.AcId)
                    .HasName("acID");

                entity.HasIndex(e => new { e.Name, e.AcId })
                    .HasName("Name")
                    .IsUnique();

                entity.Property(e => e.AsId).HasColumnName("asID");

                entity.Property(e => e.AcId).HasColumnName("acID");

                entity.Property(e => e.Contents)
                    .IsRequired()
                    .HasColumnType("varchar(8192)");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.MaxPointVal).HasColumnName("maxPointVal");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.Ac)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.AcId)
                    .HasConstraintName("Assignments_ibfk_1");
            });

            modelBuilder.Entity<Classes>(entity =>
            {
                entity.HasKey(e => e.ClassId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.CId)
                    .HasName("cID");

                entity.HasIndex(e => e.Id)
                    .HasName("ID");

                entity.HasIndex(e => new { e.Year, e.Season, e.CId })
                    .HasName("Year")
                    .IsUnique();

                entity.Property(e => e.ClassId).HasColumnName("classID");

                entity.Property(e => e.CId).HasColumnName("cID");

                entity.Property(e => e.EndTime).HasColumnType("time");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasColumnName("ID")
                    .HasColumnType("varchar(8)");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Season)
                    .IsRequired()
                    .HasColumnType("varchar(6)");

                entity.Property(e => e.StartTime).HasColumnType("time");

                entity.HasOne(d => d.C)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.CId)
                    .HasConstraintName("Classes_ibfk_2");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("Classes_ibfk_1");
            });

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.SubjectAbbreviation)
                    .HasName("SubjectAbbreviation");

                entity.HasIndex(e => new { e.Number, e.SubjectAbbreviation })
                    .HasName("Number")
                    .IsUnique();

                entity.Property(e => e.CId).HasColumnName("cID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SubjectAbbreviation)
                    .IsRequired()
                    .HasColumnType("varchar(4)");

                entity.HasOne(d => d.SubjectAbbreviationNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.SubjectAbbreviation)
                    .HasConstraintName("Courses_ibfk_1");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.SubjectAbbreviation)
                    .HasName("PRIMARY");

                entity.Property(e => e.SubjectAbbreviation).HasColumnType("varchar(4)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Enroll>(entity =>
            {
                entity.HasKey(e => e.EnroId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.ClassId)
                    .HasName("classID");

                entity.HasIndex(e => new { e.Id, e.ClassId })
                    .HasName("ID")
                    .IsUnique();

                entity.Property(e => e.EnroId).HasColumnName("enroID");

                entity.Property(e => e.ClassId).HasColumnName("classID");

                entity.Property(e => e.Grade)
                    .IsRequired()
                    .HasColumnType("varchar(2)");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasColumnName("ID")
                    .HasColumnType("varchar(8)");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Enroll)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("Enroll_ibfk_2");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Enroll)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("Enroll_ibfk_1");
            });

            modelBuilder.Entity<Professors>(entity =>
            {
                entity.HasIndex(e => e.SubjectAbbreviation)
                    .HasName("SubjectAbbreviation");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("varchar(8)");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SubjectAbbreviation)
                    .IsRequired()
                    .HasColumnType("varchar(4)");

                entity.HasOne(d => d.SubjectAbbreviationNavigation)
                    .WithMany(p => p.Professors)
                    .HasForeignKey(d => d.SubjectAbbreviation)
                    .HasConstraintName("Professors_ibfk_1");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasIndex(e => e.SubjectAbbreviation)
                    .HasName("SubjectAbbreviation");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("varchar(8)");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SubjectAbbreviation)
                    .IsRequired()
                    .HasColumnType("varchar(4)");

                entity.HasOne(d => d.SubjectAbbreviationNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.SubjectAbbreviation)
                    .HasConstraintName("Students_ibfk_1");
            });

            modelBuilder.Entity<Submission>(entity =>
            {
                entity.HasKey(e => e.SubmissionId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.AsId)
                    .HasName("asID");

                entity.HasIndex(e => new { e.Id, e.AsId })
                    .HasName("ID")
                    .IsUnique();

                entity.Property(e => e.SubmissionId).HasColumnName("submissionID");

                entity.Property(e => e.AsId).HasColumnName("asID");

                entity.Property(e => e.Contents)
                    .IsRequired()
                    .HasColumnType("varchar(8192)");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasColumnName("ID")
                    .HasColumnType("varchar(8)");

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.As)
                    .WithMany(p => p.Submission)
                    .HasForeignKey(d => d.AsId)
                    .HasConstraintName("Submission_ibfk_2");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Submission)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("Submission_ibfk_1");
            });
        }
    }
}
