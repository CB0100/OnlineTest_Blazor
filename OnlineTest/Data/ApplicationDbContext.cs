using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OnlineTest.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<TblAnswer> TblAnswers { get; set; }

    public virtual DbSet<TblAttemptExam> TblAttemptExams { get; set; }

    public virtual DbSet<TblAttemptExamPaper> TblAttemptExamPapers { get; set; }

    public virtual DbSet<TblAttemptExamPaperAnswer> TblAttemptExamPaperAnswers { get; set; }

    public virtual DbSet<TblCandidate> TblCandidates { get; set; }

    public virtual DbSet<TblCandidateReadPassage> TblCandidateReadPassages { get; set; }

    public virtual DbSet<TblExam> TblExams { get; set; }

    public virtual DbSet<TblExamPrepration> TblExamPreprations { get; set; }

    public virtual DbSet<TblOption> TblOptions { get; set; }

    public virtual DbSet<TblPassage> TblPassages { get; set; }

    public virtual DbSet<TblPassageBlock> TblPassageBlocks { get; set; }

    public virtual DbSet<TblPassageVideo> TblPassageVideos { get; set; }

    public virtual DbSet<TblQuestion> TblQuestions { get; set; }

    public virtual DbSet<TblQuestionType> TblQuestionTypes { get; set; }

    public virtual DbSet<TblReadPassage> TblReadPassages { get; set; }

    public virtual DbSet<TblResult> TblResults { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=CBPC-BATHAM\\SQLEXPRESS;Initial Catalog=DbDLS;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.Property(e => e.RoleId).HasMaxLength(450);

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<TblAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Answ__3214EC07C8D4B77B");

            entity.ToTable("tbl_Answers");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.Modified)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Option).WithMany(p => p.TblAnswers)
                .HasForeignKey(d => d.OptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_OptionalAnswers_OptionId");

            entity.HasOne(d => d.Question).WithMany(p => p.TblAnswers)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_OptionalAnswers_QuestionId");
        });

        modelBuilder.Entity<TblAttemptExam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Atte__3214EC0799A1C2EB");

            entity.ToTable("tbl_AttemptExam");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Duration).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsCompleted).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.Marks).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Modified)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Candidate).WithMany(p => p.TblAttemptExams)
                .HasForeignKey(d => d.CandidateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_AttemptExam_CandidateId");

            entity.HasOne(d => d.Exam).WithMany(p => p.TblAttemptExams)
                .HasForeignKey(d => d.ExamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_AttemptExam_ExamId");
        });

        modelBuilder.Entity<TblAttemptExamPaper>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Atte__3214EC078AE0A451");

            entity.ToTable("tbl_AttemptExamPaper");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsCompleted).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.Modified)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.AttemptExam).WithMany(p => p.TblAttemptExamPapers)
                .HasForeignKey(d => d.AttemptExamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_AttemptExamPaper_AttemptExamId");

            entity.HasOne(d => d.Question).WithMany(p => p.TblAttemptExamPapers)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_AttemptExamPaper_QuestionId");
        });

        modelBuilder.Entity<TblAttemptExamPaperAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Atte__3214EC074422038C");

            entity.ToTable("tbl_AttemptExamPaperAnswers");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.Modified)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.AttemptExamPaper).WithMany(p => p.TblAttemptExamPaperAnswers)
                .HasForeignKey(d => d.AttemptExamPaperId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_AttemptExamPaperAnswers_AttemptExamPaperId");

            entity.HasOne(d => d.Option).WithMany(p => p.TblAttemptExamPaperAnswers)
                .HasForeignKey(d => d.OptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_AttemptExamPaperAnswers_OptionId");

            entity.HasOne(d => d.Question).WithMany(p => p.TblAttemptExamPaperAnswers)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_AttemptExamPaperAnswers_QuestionId");
        });

        modelBuilder.Entity<TblCandidate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Cand__3214EC07BE1E2760");

            entity.ToTable("tbl_Candidate");

            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CandidateId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsAnswer).HasDefaultValueSql("((0))");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.LastName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.MobileNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Modified)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Zip)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblCandidateReadPassage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Cand__3214EC072B9D2285");

            entity.ToTable("tbl_CandidateReadPassage");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsCompleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.Modified)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Candidate).WithMany(p => p.TblCandidateReadPassages)
                .HasForeignKey(d => d.CandidateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_CandidateReadPassage_CandidateId");
        });

        modelBuilder.Entity<TblExam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Exam__3214EC07003A3A04");

            entity.ToTable("tbl_Exam");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Duration).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FullMarks).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.Modified)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(1000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblExamPrepration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Exam__3214EC07A09DA60E");

            entity.ToTable("tbl_ExamPrepration");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Duration).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.Modified)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Exam).WithMany(p => p.TblExamPreprations)
                .HasForeignKey(d => d.ExamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_ExamPrepration_ExamId");

            entity.HasOne(d => d.QuestionType).WithMany(p => p.TblExamPreprations)
                .HasForeignKey(d => d.QuestionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_ExamPrepration_QuestionTypeId");
        });

        modelBuilder.Entity<TblOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Opti__3214EC07F0174F8E");

            entity.ToTable("tbl_Options");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsAnswer).HasDefaultValueSql("((0))");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.Modified)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Question).WithMany(p => p.TblOptions)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_Options_QuestionId");
        });

        modelBuilder.Entity<TblPassage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Pass__3214EC07699BABAB");

            entity.ToTable("tbl_Passage");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.Modified)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblPassageBlock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Pass__3214EC07B69476B1");

            entity.ToTable("tbl_PassageBlocks");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.Modified)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Passage).WithMany(p => p.TblPassageBlocks)
                .HasForeignKey(d => d.PassageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_PassageBlocks_PassageId");
        });

        modelBuilder.Entity<TblPassageVideo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Pass__3214EC076789B703");

            entity.ToTable("tbl_PassageVideos");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.Modified)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Passage).WithMany(p => p.TblPassageVideos)
                .HasForeignKey(d => d.PassageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_PassageVideos_PassageId");
        });

        modelBuilder.Entity<TblQuestion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Ques__3214EC07DD2C474C");

            entity.ToTable("tbl_Questions");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.Modified)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Passage).WithMany(p => p.TblQuestions)
                .HasForeignKey(d => d.PassageId)
                .HasConstraintName("tbl_Questions_PassageId");

            entity.HasOne(d => d.QuestionType).WithMany(p => p.TblQuestions)
                .HasForeignKey(d => d.QuestionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_Questions_QuestionTypeId");
        });

        modelBuilder.Entity<TblQuestionType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Ques__3214EC07EA75FFFD");

            entity.ToTable("tbl_QuestionType");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.Marks).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Modified)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblReadPassage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Read__3214EC0735D0BC41");

            entity.ToTable("tbl_ReadPassage");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsCompleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.Modified)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.CandidateReadPassage).WithMany(p => p.TblReadPassages)
                .HasForeignKey(d => d.CandidateReadPassageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_ReadPassage_CandidateReadPassageId");

            entity.HasOne(d => d.Passage).WithMany(p => p.TblReadPassages)
                .HasForeignKey(d => d.PassageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_ReadPassage_PassageId");
        });

        modelBuilder.Entity<TblResult>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Resu__3214EC079957857A");

            entity.ToTable("tbl_Result");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.Modified)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Candidate).WithMany(p => p.TblResults)
                .HasForeignKey(d => d.CandidateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_Result_CandidateId");

            entity.HasOne(d => d.Exam).WithMany(p => p.TblResults)
                .HasForeignKey(d => d.ExamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_Result_ExamId");

            entity.HasOne(d => d.Option).WithMany(p => p.TblResultOptions)
                .HasForeignKey(d => d.OptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_Result_OptionId");

            entity.HasOne(d => d.Question).WithMany(p => p.TblResults)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_Result_QuestionId");

            entity.HasOne(d => d.SelectedOption).WithMany(p => p.TblResultSelectedOptions)
                .HasForeignKey(d => d.SelectedOptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_Result_SelectedOptionId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}