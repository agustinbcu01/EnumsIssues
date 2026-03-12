using EnumsIssues.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnumsIssues.EntityConfigurations
{

  class ProductConfiguration : IEntityTypeConfiguration<User>
  {
    protected static readonly User[] InternalUser = [
               new User {Id=1, Name = "admin",Email = "admin@local.t", PasswordHash="##########", Status = StatusEnum.Active },
               new User {Id=2, Name = "guest",Email = "guest@local.t", PasswordHash="##########", Status = StatusEnum.Inactive }
           ];
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.ToTable("users", "public");
      builder.HasKey(x => x.Id);

      builder.Property(e => e.Name)
        .IsRequired()
        .HasMaxLength(100);

      builder.Property(e => e.PasswordHash)
        .IsRequired()
        .HasMaxLength(100);

      builder.Property(e => e.Email)
        .IsRequired()
        .HasMaxLength(255);

      builder.Property(e => e.Status)
        .IsRequired()
        .HasColumnType("public.StatusEnum");

      builder.HasData(InternalUser);
    }
  }

}
