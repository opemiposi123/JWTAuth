using JWTAuth.DataModel;
using Microsoft.AspNetCore.Identity;

namespace JWTAuth.Context
{
	public static class DbInitializerExtension
	{
		public static async Task<IApplicationBuilder> SeedDefaultUserToMySql(this IApplicationBuilder app)
		{
			ArgumentNullException.ThrowIfNull(app, nameof(app));

			using var scope = app.ApplicationServices.CreateScope();
			var services = scope.ServiceProvider;
			var loggerFactory = services.GetRequiredService<ILoggerFactory>();
		
			
			try
			{

				var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
				var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
				await ApplicationDbContextSeed.SeedEssentialsAsync(userManager, roleManager);
			}
			catch (Exception ex)
			{
				var logger = loggerFactory.CreateLogger<Program>();
				logger.LogError(ex, "An error occurred seeding the DB.");
			}

			return app;
		}
	}
}
