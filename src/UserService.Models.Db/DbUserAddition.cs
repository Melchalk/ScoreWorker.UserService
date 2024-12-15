using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using UserService.Models.Dto.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Models.Db;

public class DbUserAddition
{
    public const string TableName = "UserAdditions";

    [Key]
    public Guid Id { get; set; }

    [ForeignKey("FK_UserId")]
    public Guid UserId { get; set; }
    public GenderType GenderId { get; set; }
    public required string About { get; set; }
    public DateTime? DateOfBirth { get; set; }

    public DbUser? User { get; set; }
}

public class DbUserAdditionConfiguration : IEntityTypeConfiguration<DbUserAddition>
{
    public void Configure(EntityTypeBuilder<DbUserAddition> builder)
    {
        builder.ToTable(DbUserAddition.TableName);

        builder.HasOne(ua => ua.User)
            .WithOne(u => u.Addition)
            .HasForeignKey<DbUserAddition>(ua => ua.UserId);
    }
}