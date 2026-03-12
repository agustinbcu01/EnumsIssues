using EnumsIssues.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using Npgsql;

namespace EnumsIssues.Infraestructute
{
  public static class DBExtentesions
  {
      public static IServiceCollection AddDBSettings(this IServiceCollection services, IConfiguration configuration)
      {
      var connectionStr = configuration["EnumIssues:ConnectionString"];

      services.AddSingleton(provider =>
      {
        var builder = new NpgsqlDataSourceBuilder(connectionStr);
        builder.MapEnum<StatusEnum>("public.status_enum");
        return builder.Build();
      });

      services.AddDbContext<Entities.UnumsContext>((serviceProvider, options) =>
        {
          var dataSource = serviceProvider.GetRequiredService<NpgsqlDataSource>();

          options.UseNpgsql(dataSource, npgsqlOptions =>
          {
            npgsqlOptions.EnableRetryOnFailure();
          });
        });
      return services;
    } 
    
  }
}

