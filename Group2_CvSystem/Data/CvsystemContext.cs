using System;
using System.Collections.Generic;
using Group2_CvSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace Group2_CvSystem.Data;

public partial class CvsystemContext : DbContext
{
    public CvsystemContext()
    {
    }

    public CvsystemContext(DbContextOptions<CvsystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Competence> Competences { get; set; }

    public virtual DbSet<Cv> Cvs { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=CVSystem;Integrated Security=SSPI");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AdressId).HasName("PK__Address__F05DDE033F840D9E");

            entity.ToTable("Address");

            entity.Property(e => e.AddressCity).HasMaxLength(50);
            entity.Property(e => e.AddressNumber).HasMaxLength(50);
            entity.Property(e => e.AddressPostcode).HasMaxLength(50);
            entity.Property(e => e.AdressName).HasMaxLength(50);
            entity.Property(e => e.UserId).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Address__UserId__412EB0B6");
        });

        modelBuilder.Entity<Competence>(entity =>
        {
            entity.HasKey(e => e.CompetenceId).HasName("PK__Competen__75544D96FB152CD3");

            entity.ToTable("Competence");

            entity.Property(e => e.CompetenceName).HasMaxLength(50);
        });

        modelBuilder.Entity<Cv>(entity =>
        {
            entity.HasKey(e => e.CvId).HasName("PK__CV__4FB517799BB35D30");

            entity.ToTable("CV");

            entity.Property(e => e.UserId).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.Cvs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__CV__UserId__38996AB5");

            entity.HasMany(d => d.Competences).WithMany(p => p.Cvs)
                .UsingEntity<Dictionary<string, object>>(
                    "CvCompetence",
                    r => r.HasOne<Competence>().WithMany()
                        .HasForeignKey("CompetenceId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CV_Compet__Compe__4E88ABD4"),
                    l => l.HasOne<Cv>().WithMany()
                        .HasForeignKey("CvId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CV_Compete__CvId__4D94879B"),
                    j =>
                    {
                        j.HasKey("CvId", "CompetenceId").HasName("PK__CV_Compe__38E053A0E85337C8");
                        j.ToTable("CV_Competence");
                    });

            entity.HasMany(d => d.Educations).WithMany(p => p.Cvs)
                .UsingEntity<Dictionary<string, object>>(
                    "CvEducation",
                    r => r.HasOne<Education>().WithMany()
                        .HasForeignKey("EducationId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CV_Educat__Educa__52593CB8"),
                    l => l.HasOne<Cv>().WithMany()
                        .HasForeignKey("CvId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CV_Educati__CvId__5165187F"),
                    j =>
                    {
                        j.HasKey("CvId", "EducationId").HasName("PK__CV_Educa__0B0EF4F9CA020362");
                        j.ToTable("CV_Education");
                    });

            entity.HasMany(d => d.Experiences).WithMany(p => p.Cvs)
                .UsingEntity<Dictionary<string, object>>(
                    "CvExperience",
                    r => r.HasOne<Experience>().WithMany()
                        .HasForeignKey("ExperienceId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CV_Experi__Exper__5629CD9C"),
                    l => l.HasOne<Cv>().WithMany()
                        .HasForeignKey("CvId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CV_Experie__CvId__5535A963"),
                    j =>
                    {
                        j.HasKey("CvId", "ExperienceId").HasName("PK__CV_Exper__CD41F43D26AE5A9C");
                        j.ToTable("CV_Experience");
                    });
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.EducationId).HasName("PK__Educatio__4BBE38052E39C9E9");

            entity.ToTable("Education");

            entity.Property(e => e.EducationName).HasMaxLength(50);
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.HasKey(e => e.ExperienceId).HasName("PK__Experien__2F4E344904268559");

            entity.ToTable("Experience");

            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.ExperienceName).HasMaxLength(50);
            entity.Property(e => e.StartTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__Message__C87C0C9CDB405194");

            entity.ToTable("Message");

            entity.Property(e => e.Content).HasMaxLength(50);
            entity.Property(e => e.Receiver).HasMaxLength(50);
            entity.Property(e => e.Sender).HasMaxLength(50);
            entity.Property(e => e.SentTime).HasColumnType("datetime");

            entity.HasOne(d => d.ReceiverNavigation).WithMany(p => p.MessageReceiverNavigations)
                .HasForeignKey(d => d.Receiver)
                .HasConstraintName("FK__Message__Receive__4AB81AF0");

            entity.HasOne(d => d.SenderNavigation).WithMany(p => p.MessageSenderNavigations)
                .HasForeignKey(d => d.Sender)
                .HasConstraintName("FK__Message__Sender__49C3F6B7");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Project__3214EC07BC184315");

            entity.ToTable("Project");

            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4CC3B07EBF");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);

            entity.HasMany(d => d.Projects).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserProject",
                    r => r.HasOne<Project>().WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__User_Proj__Proje__3E52440B"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__User_Proj__UserI__3D5E1FD2"),
                    j =>
                    {
                        j.HasKey("UserId", "ProjectId").HasName("PK__User_Pro__00E967A35CD7248C");
                        j.ToTable("User_Project");
                        j.IndexerProperty<string>("UserId").HasMaxLength(50);
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
