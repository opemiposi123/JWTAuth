﻿using JWTAuth.Constants;
using JWTAuth.DataModel;
using Microsoft.AspNetCore.Identity;

namespace JWTAuth.Context
{
	public class ApplicationDbContextSeed
	{
		public static async Task SeedEssentialsAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			//Seed Roles
			await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.Administrator.ToString()));
			await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.Moderator.ToString()));
			await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.User.ToString()));

			//Seed Default User
			var defaultUser = new ApplicationUser { UserName = Authorization.default_username, Email = Authorization.default_email, EmailConfirmed = true, PhoneNumberConfirmed = true, FirstName = "Mahmood", LastName = "Abd.Waheed" };

			if (userManager.Users.All(u => u.Id != defaultUser.Id))
			{
				await userManager.CreateAsync(defaultUser, Authorization.default_password);
				await userManager.AddToRoleAsync(defaultUser, Authorization.default_role.ToString());
			}
		}
	}
}
