using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MVCDemoAppMastek.Models
{
    public partial class TrainingContext : DbContext
    {
        internal readonly object Userdata;

        public TrainingContext()
        {
        }

        public TrainingContext(DbContextOptions<TrainingContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Dept> Depts { get; set; }
        public virtual DbSet<Emp> Emps { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Dept>(entity =>
            {
                entity.HasKey(e => e.Deptno)
                .HasName("DEPT_deptno_pk1");

                entity.ToTable("DEPT");

                entity.HasIndex(e => e.Dname, "DEPT_Dname_UNQ")
                .IsUnique();

                entity.Property(e => e.Deptno)
                .ValueGeneratedNever()
                .HasColumnName("DEPTNO");

                entity.Property(e => e.Dname)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("DNAME");

                entity.Property(e => e.Loc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("LOC");
            });

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.HasKey(e => e.Empno)
                .HasName("EMP_EMPNO_PK");

                entity.ToTable("EMP");

                entity.Property(e => e.Empno)
                .ValueGeneratedNever()
                .HasColumnName("EMPNO");

                entity.Property(e => e.Comm)
                .HasColumnType("numeric(7, 2)")
                .HasColumnName("COMM");

                entity.Property(e => e.Deptno).HasColumnName("DEPTNO");

                entity.Property(e => e.Ename)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ENAME");

                entity.Property(e => e.Hiredate)
                .HasColumnType("datetime")
                .HasColumnName("HIREDATE");

                entity.Property(e => e.Job)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("JOB");

                entity.Property(e => e.Mgr).HasColumnName("MGR");

                entity.Property(e => e.Sal)
                .HasColumnType("numeric(7, 2)")
                .HasColumnName("SAL");

                entity.HasOne(d => d.DeptnoNavigation)
                .WithMany(p => p.Emps)
                .HasForeignKey(d => d.Deptno)
                .HasConstraintName("EMP_DEPTNO_FK");

                entity.HasOne(d => d.MgrNavigation)
                .WithMany(p => p.InverseMgrNavigation)
                .HasForeignKey(d => d.Mgr)
                .HasConstraintName("EMP_MGR_SK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}