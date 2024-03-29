﻿using Microsoft.EntityFrameworkCore;

namespace ORMDAL
{
    public partial class DefaultDBContext : DbContext
    {
        public DefaultDBContext()
        {
        }

        public DefaultDBContext(DbContextOptions<DefaultDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-MRUOR9L\\SQLEXPRESS; Initial Catalog = Minesweeper; Integrated Security = True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.GameDate).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Game)
                    .HasForeignKey(d => d.UserID)
                    .HasConstraintName("FK_Games_UserID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.RegisterDate).HasColumnType("datetime");

                entity.Property(e => e.Login).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Password).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
