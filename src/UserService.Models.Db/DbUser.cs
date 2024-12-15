using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace UserService.Models.Db;

public class DbUser
{
    public const string TableName = "Users";

    [Key]
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsActive { get; set; }

    public DbUserAddition? Addition { get; set; }
    public DbUserCredentials? Credentials { get; set; }
}

public class DbUserConfiguration : IEntityTypeConfiguration<DbUser>
{
    public void Configure(EntityTypeBuilder<DbUser> builder)
    {
        builder.ToTable(DbUser.TableName);

        builder.HasOne(u => u.Addition)
            .WithOne(ua => ua.User)
            .HasForeignKey<DbUserAddition>(ua => ua.UserId)
            .HasPrincipalKey<DbUser>(u => u.Id);

        builder.HasOne(u => u.Credentials)
            .WithOne(uc => uc.User)
            .HasForeignKey<DbUserCredentials>(uc => uc.UserId)
            .HasPrincipalKey<DbUser>(u => u.Id);
    }
}