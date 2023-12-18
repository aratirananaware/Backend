using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JPW.Models
{
    public partial class JPWContext : DbContext
    {
        public JPWContext()
        {
        }

        public JPWContext(DbContextOptions<JPWContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<ApplyforJob> ApplyforJobs { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<JobMatch> JobMatches { get; set; } = null!;
        public virtual DbSet<JobPosting> JobPostings { get; set; } = null!;
        public virtual DbSet<JobSeeker> JobSeekers { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
         public DbSet<Interview> Interviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-B5DHM03O\\SQLEXPRESS;Database=JPW;Trusted_Connection=True;TrustServerCertificate=yes");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.HasIndex(e => e.Email, "UQ__Admin__A9D105346811502C")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ApplyforJob>(entity =>
            {
                entity.HasKey(e => e.AppliedJobId)
                    .HasName("PK__Applyfor__AF19BB4BF50E342A");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.ApplyforJobs)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_ApplyforJobs_JobPosting");

                entity.HasOne(d => d.JobSeeker)
                    .WithMany(p => p.ApplyforJobs)
                    .HasForeignKey(d => d.JobSeekerId)
                    .HasConstraintName("FK_ApplyforJobs_JobSeeker");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.HasIndex(e => e.CompanyEmail, "UQ__Company__A1DB68DBF04BE8FE")
                    .IsUnique();

                entity.Property(e => e.CompanyAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JobMatch>(entity =>
            {
                entity.ToTable("JobMatch");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobMatches)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_JobMatch_JobPosting");

                entity.HasOne(d => d.JobSeeker)
                    .WithMany(p => p.JobMatches)
                    .HasForeignKey(d => d.JobSeekerId)
                    .HasConstraintName("FK_JobMatch_JobSeeker");
            });

            modelBuilder.Entity<JobPosting>(entity =>
            {
                entity.HasKey(e => e.JobId)
                    .HasName("PK__JobPosti__056690C2FFF0EF52");

                entity.ToTable("JobPosting");

                // entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.JobDescription)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.JobExperienceLevel)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.JobLocation)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.JobPayScale)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.JobSkillSet)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                // entity.Property(e => e.StartDate)
                //     .HasColumnType("date")
                //     .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.JobPostings)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_JobPosting_Company");
            });

            modelBuilder.Entity<JobSeeker>(entity =>
            {
                entity.ToTable("JobSeeker");

                entity.HasIndex(e => e.Email, "UQ__JobSeeke__A9D10534B78294B6")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.JobSeekerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Skills)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.MessageText).IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_Message_Company");

                entity.HasOne(d => d.JobSeeker)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.JobSeekerId)
                    .HasConstraintName("FK_Message_JobSeeker");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
