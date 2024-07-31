using BlogTestOpen.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogTestOpen.Api.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //table\
            builder.ToTable("User");

            //primarykey
            builder.HasKey(x => x.Id);

            //identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            //Properties
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR");


            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(160)
                .HasColumnName("Email")
                .HasColumnType("VARCHAR");

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Password")
                .HasColumnType("VARCHAR");

            builder.Property(x => x.Image)
                .IsRequired(false);

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("Slug")
                .HasColumnType("VARCHAR");

            //indice
            builder.HasIndex(x => x.Slug, "IX_User_Slug")
                .IsUnique();

            //Relationships

            //roles
            builder
                .HasMany(x => x.Roles)
                .WithMany(x => x.Users)
                .UsingEntity<Dictionary<string, object>>(
                "UserRole",
                role => role
                .HasOne<Role>()
                .WithMany()
                .HasForeignKey("RoleId")
                .HasConstraintName("FK_UserRole_RoleId")
                .OnDelete(DeleteBehavior.Cascade),
                user => user
                .HasOne<User>()
                .WithMany()
                .HasForeignKey("UserId")
                .HasForeignKey("FK_UserRole_UserId")
                .OnDelete(DeleteBehavior.Cascade));

            //Posts
            


        }
    }
}
