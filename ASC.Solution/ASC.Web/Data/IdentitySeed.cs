﻿using ASC.Model.BaseTypes;
using ASC.Solution.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace ASC.Web.Data
{
    public class IdentitySeed : IIdentitySeed
    {
        public async Task Seed(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<ApplicationSettings> options)
        {
            // Get All comma separated roles
            var roles = options.Value.Roles.Split(new char[] { ',' });

            // Create roles if they don't exist
            foreach (var role in roles)
            {
                try
                {
                    if(!await roleManager.RoleExistsAsync(role))

                    {
                        IdentityRole storageRole = new IdentityRole
                        {
                            Name = role
                        };
                        IdentityResult roleResult = await roleManager.CreateAsync(storageRole);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            // Create admin if he doesn't exist
            var admin = await userManager.FindByEmailAsync(options.Value.AdminEmail);
            if (admin == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = options.Value.AdminName,
                    Email = options.Value.AdminEmail,
                    EmailConfirmed = true
                };
                IdentityResult result = await userManager.CreateAsync(user, options.Value.AdminPassword);
                
                // Add Admin to admin role
                if (result.Succeeded)
                {
                    await userManager.AddClaimAsync(user, new System.Security.Claims.Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", options.Value.AdminEmail));
                    await userManager.AddClaimAsync(user, new System.Security.Claims.Claim("IsActive", "True"));
                    await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
                }
            }

            // Create service engineer if he doesn't exist
            var engineer = await userManager.FindByEmailAsync(options.Value.EngineerEmail);
            if (engineer == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = options.Value.EngineerName,
                    Email = options.Value.EngineerEmail,
                    EmailConfirmed = true,
                    LockoutEnabled = false
                };
                IdentityResult result = await userManager.CreateAsync(user, options.Value.EngineerPassword);
                
                // Add Service Engineer to Engineer role
                if (result.Succeeded)
                {
                    await userManager.AddClaimAsync(user, new System.Security.Claims.Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", options.Value.EngineerEmail));
                    await userManager.AddClaimAsync(user, new System.Security.Claims.Claim("IsActive", "True"));
                    await userManager.AddToRoleAsync(user, Roles.Engineer.ToString());
                }
            }
        }
    }
}