using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UserService.Models.Dto.Enum;

namespace UserService.Models.Db;

public class DbUserWorker
{
    public const string TableName = "UserWorkers";

    [Key]
    public Guid Id { get; set; }

    [ForeignKey("FK_UserId")]
    public Guid UserId { get; set; }
    public Guid TeamId { get; set; }
    public Grade Grade { get; set; }

    public DbUser? User { get; set; }
}

public class DbUserWorkerConfiguration : IEntityTypeConfiguration<DbUserWorker>
{
    public void Configure(EntityTypeBuilder<DbUserWorker> builder)
    {
        builder.ToTable(DbUserWorker.TableName);

        builder.HasOne(w => w.User)
            .WithOne(u => u.Worker)
            .HasForeignKey<DbUserWorker>(ua => ua.UserId);
    }
}