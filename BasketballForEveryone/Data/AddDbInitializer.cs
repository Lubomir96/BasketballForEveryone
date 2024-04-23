using BasketballForEveryone.Data.Enums;
using BasketballForEveryone.Data.Static;
using BasketballForEveryone.Models;
using Microsoft.AspNetCore.Identity;

namespace BasketballForEveryone.Data
{
    public class AddDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Team
                if (!context.Teams.Any())
                {
                    context.Teams.AddRange(new List<Team>()
                    {
                        new Team()
                        {
                            Name = "Team 1",
                            Logo = "https://en.wikipedia.org/wiki/Michael_Jordan",
                            Description = "This is the description of the first team"
                        },
                        new Team()
                        {
                            Name = "Team 2",
                            Logo = "https://en.wikipedia.org/wiki/Michael_Jordan",
                            Description = "This is the description of the first team"
                        },
                        new Team()
                        {
                            Name = "Team 3",
                            Logo = "https://en.wikipedia.org/wiki/Michael_Jordan",
                            Description = "This is the description of the first team"
                        },
                        new Team()
                        {
                            Name = "Team 4",
                            Logo = "https://en.wikipedia.org/wiki/Michael_Jordan",
                            Description = "This is the description of the first team"
                        },
                        new Team()
                        {
                            Name = "Team 5",
                            Logo = "https://en.wikipedia.org/wiki/Michael_Jordan",
                            Description = "This is the description of the first team"
                        },
                    });
                    context.SaveChanges();

                }
                //BPlayers
                if (!context.BPlayers.Any())
                {
                    context.BPlayers.AddRange(new List<BPlayer>()
                    {
                        new BPlayer()
                        {
                            FullName = "Player 1",
                            Bio = "This is the Bio of the first Player",
                            ProfilePictureURL = "https://en.wikipedia.org/wiki/Michael_Jordan"

                        },
                        new BPlayer()
                        {
                            FullName = "Player 2",
                            Bio = "This is the Bio of the second Player",
                            ProfilePictureURL = "https://en.wikipedia.org/wiki/Michael_Jordan"
                        },
                        new BPlayer()
                        {
                            FullName = "Player 3",
                            Bio = "This is the Bio of the second Player",
                            ProfilePictureURL = "https://en.wikipedia.org/wiki/Michael_Jordan"
                        },
                        new BPlayer()
                        {
                            FullName = "Player 4",
                            Bio = "This is the Bio of the second Player",
                            ProfilePictureURL = "https://en.wikipedia.org/wiki/Michael_Jordan"
                        },
                        new BPlayer()
                        {
                            FullName = "Player 5",
                            Bio = "This is the Bio of the second Player",
                            ProfilePictureURL = "https://en.wikipedia.org/wiki/Michael_Jordan"
                        }
                    });
                    context.SaveChanges();
                }
                //Coaches
                if (!context.Coaches.Any())
                {
                    context.Coaches.AddRange(new List<Coach>()
                    {
                        new Coach()
                        {
                            FullName = "Coach 1",
                            Bio = "This is the Bio of the first Coach",
                            ProfilePictureURL = "https://en.wikipedia.org/wiki/Michael_Jordan"

                        },
                        new Coach()
                        {
                            FullName = "Coach 2",
                            Bio = "This is the Bio of the second Coach",
                            ProfilePictureURL = "https://en.wikipedia.org/wiki/Michael_Jordan"
                        },
                        new Coach()
                        {
                            FullName = "Coach 3",
                            Bio = "This is the Bio of the second Coach",
                            ProfilePictureURL = "https://en.wikipedia.org/wiki/Michael_Jordan"
                        },
                        new Coach()
                        {
                            FullName = "Coach 4",
                            Bio = "This is the Bio of the second Coach",
                            ProfilePictureURL = "https://en.wikipedia.org/wiki/Michael_Jordan"
                        },
                        new Coach()
                        {
                            FullName = "Coach 5",
                            Bio = "This is the Bio of the second Coach",
                            ProfilePictureURL = "https://en.wikipedia.org/wiki/Michael_Jordan"
                        }
                    });
                    context.SaveChanges();
                }
                //BestPlayers
                if (!context.BestPlayers.Any())
                {
                    context.BestPlayers.AddRange(new List<BestPlayer>()
                    {
                        new BestPlayer()
                        {
                             Name = "Life",
                            Description = "This is the Life movie description",
                            Points = 39.50,
                            ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/88/Michael_Jordan.jpg/220px-Michael_Jordan.jpg",
                            CareerStart = DateTime.Now.AddDays(-10),
                            CareerEnd = DateTime.Now.AddDays(10),
                            TeamId = 3,
                            CoachId = 3,
                            Position = Position.C
                        },
                        new BestPlayer()
                        {


                             Name = "Life",
                            Description = "This is the Life movie description",
                            Points = 39.50,
                            ImageURL = "https://en.wikipedia.org/wiki/Michael_Jordan",
                            CareerStart = DateTime.Now.AddDays(-10),
                            CareerEnd = DateTime.Now.AddDays(10),
                            TeamId = 3,
                            CoachId = 3,
                            Position = Position.C

                        },
                        new BestPlayer()
                        {


                             Name = "Life",
                            Description = "This is the Life movie description",
                            Points = 39.50,
                            ImageURL = "https://en.wikipedia.org/wiki/Michael_Jordan",
                            CareerStart = DateTime.Now.AddDays(-10),
                            CareerEnd = DateTime.Now.AddDays(10),
                            TeamId = 3,
                            CoachId = 3,
                            Position = Position.C
                        },
                        new BestPlayer()
                        {


                             Name = "Life",
                            Description = "This is the Life movie description",
                            Points = 39.50,
                            ImageURL = "https://en.wikipedia.org/wiki/Michael_Jordan",
                            CareerStart = DateTime.Now.AddDays(-10),
                            CareerEnd = DateTime.Now.AddDays(10),
                            TeamId = 3,
                            CoachId = 3,
                            Position = Position.C
                        },
                        new BestPlayer()
                        {


                             Name = "Life",
                            Description = "This is the Life movie description",
                            Points = 39.50,
                            ImageURL = "https://en.wikipedia.org/wiki/Michael_Jordan",
                            CareerStart = DateTime.Now.AddDays(-10),
                            CareerEnd = DateTime.Now.AddDays(10),
                            TeamId = 3,
                            CoachId = 3,
                            Position = Position.C
                        },
                        new BestPlayer()
                        {


                             Name = "Life",
                            Description = "This is the Life movie description",
                            Points = 39.50,
                            ImageURL = "https://en.wikipedia.org/wiki/Michael_Jordan",
                            CareerStart = DateTime.Now.AddDays(-10),
                            CareerEnd = DateTime.Now.AddDays(10),
                            TeamId = 3,
                            CoachId = 3,
                            Position = Position.C
                        }
                    });
                    context.SaveChanges();
                }
                //Bplayer & BestPlayers
                if (!context.BPlayers_BestPlayers.Any())
                {
                    context.BPlayers_BestPlayers.AddRange(new List<BPlayer_BestPlayer>()
                    {



                         new BPlayer_BestPlayer()
                        {
                            BPlayerId = 1,
                            BestPlayerId = 2
                        },


                        new BPlayer_BestPlayer()
                        {
                            BPlayerId = 1,
                            BestPlayerId = 3
                        },
                        new BPlayer_BestPlayer()
                        {
                            BPlayerId = 2,
                            BestPlayerId = 3
                        },
                        new BPlayer_BestPlayer()
                        {
                            BPlayerId = 5,
                            BestPlayerId = 3
                        },


                        new BPlayer_BestPlayer()
                        {
                            BPlayerId = 2,
                            BestPlayerId = 4
                        },
                        new BPlayer_BestPlayer()
                        {
                            BPlayerId = 3,
                            BestPlayerId = 4
                        },
                        new BPlayer_BestPlayer()
                        {
                            BPlayerId = 4,
                            BestPlayerId = 4
                        },


                        new BPlayer_BestPlayer()
                        {
                            BPlayerId = 2,
                            BestPlayerId = 2
                        },





                        new BPlayer_BestPlayer()
                        {
                            BPlayerId = 3,
                            BestPlayerId = 2
                        },
                        new BPlayer_BestPlayer()
                        {
                            BPlayerId = 4,
                            BestPlayerId = 2
                        },
                        new BPlayer_BestPlayer()
                        {
                            BPlayerId = 5,
                            BestPlayerId = 2
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@basketballFE.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@basketballFE.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
