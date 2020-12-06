using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RecipeApi.Models;

namespace RecipeApi.Data
{
    public partial class RecipeSharingDbContext : DbContext
    {
        public RecipeSharingDbContext()
        {
        }

        public RecipeSharingDbContext(DbContextOptions<RecipeSharingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cultures> Cultures { get; set; }
        public virtual DbSet<DietTypes> DietTypes { get; set; }
        public virtual DbSet<Directions> Directions { get; set; }
        public virtual DbSet<FoodItems> FoodItems { get; set; }
        public virtual DbSet<Ingredients> Ingredients { get; set; }
        public virtual DbSet<MealTypes> MealTypes { get; set; }
        public virtual DbSet<RecipeDietTypes> RecipeDietTypes { get; set; }
        public virtual DbSet<Recipes> Recipes { get; set; }
        public virtual DbSet<RecipeTags> RecipeTags { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //TODO: Add error prompting to add a connection to Configuration
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cultures>(entity =>
            {
                entity.HasKey(e => e.CultureId);

                entity.ToTable("Cultures", "RecipeAPI");

                entity.Property(e => e.CultureId)
                    .HasColumnName("CultureID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Culture)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DietTypes>(entity =>
            {
                entity.HasKey(e => e.DietTypeId);

                entity.ToTable("Diet_Types", "RecipeAPI");

                entity.Property(e => e.DietTypeId)
                    .HasColumnName("DietTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DietType)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Directions>(entity =>
            {
                entity.HasKey(e => new { e.RecipeId, e.RecipeSequenceNmbr });

                entity.ToTable("Directions", "RecipeAPI");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.Property(e => e.Instruction)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FoodItems>(entity =>
            {
                entity.ToTable("Food_Items", "RecipeAPI");

                entity.Property(e => e.FoodItemsId)
                    .HasColumnName("FoodItemsID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FoodItem)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ingredients>(entity =>
            {
                entity.HasKey(e => new { e.RecipeId, e.SeqNo });

                entity.ToTable("Ingredients", "RecipeAPI");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.Property(e => e.FoodItemsId).HasColumnName("FoodItemsID");

                entity.Property(e => e.Measure)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Units)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MealTypes>(entity =>
            {
                entity.HasKey(e => e.MealTypeId);

                entity.ToTable("MealTypes", "RecipeAPI");

                entity.Property(e => e.MealTypeId)
                    .HasColumnName("MealTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.MealType)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RecipeDietTypes>(entity =>
            {
                entity.HasKey(e => new { e.RecipeId, e.DietTypeId });

                entity.ToTable("Recipe_DietTypes", "RecipeAPI");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.Property(e => e.DietTypeId).HasColumnName("DietTypeID");
            });

            modelBuilder.Entity<Recipes>(entity =>
            {
                entity.HasKey(e => e.RecipeId);

                entity.ToTable("Recipes", "RecipeAPI");

                entity.Property(e => e.RecipeId)
                    .HasColumnName("RecipeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DirectionId).HasColumnName("DirectionID");

                entity.Property(e => e.RecipeName)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RecipeTags>(entity =>
            {
                entity.HasKey(e => new { e.RecipeId, e.TagId });

                entity.ToTable("Recipe_Tags", "RecipeAPI");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.Property(e => e.TagId).HasColumnName("TagID");
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.HasKey(e => e.TagId);

                entity.ToTable("Tags", "RecipeAPI");

                entity.Property(e => e.TagId)
                    .HasColumnName("TagID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Tag)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });
        }
    }
}
