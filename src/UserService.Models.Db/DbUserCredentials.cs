using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace UserService.Models.Db;

public class DbUserCredentials
{
    public const string TableName = "UserCredentials";

    [Key]
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public required string Login { get; set; }
    public required string PasswordHash { get; set; }
    public required string Salt { get; set; }

    public DbUser? User { get; set; }
}

public class DbUserCredentialsConfiguration : IEntityTypeConfiguration<DbUserCredentials>
{
    public void Configure(EntityTypeBuilder<DbUserCredentials> builder)
    {
        builder.ToTable(DbUserCredentials.TableName);

        builder.HasOne(uc => uc.User)
            .WithOne(u => u.Credentials);
    }
}