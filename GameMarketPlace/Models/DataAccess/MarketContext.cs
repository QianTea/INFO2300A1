using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GameMarketPlace.Models.DomainModels;
using System.Runtime.CompilerServices;

namespace GameMarketPlace.Models.DataAccess
{
	public class MarketContext : IdentityDbContext
	{
		public MarketContext(DbContextOptions<MarketContext> options) : base(options)
		{ }


		public DbSet<Member> Members { get; set; }
		public DbSet<Platform> Platforms { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Game> Games { get; set; }
		public DbSet<CreditCard> CreditCards { get; set; }
		public DbSet<Wishlist> Wishlists { get; set; }
		public DbSet<Event> Events { get; set; }
		public DbSet<RegisteredEvents> RegisteredEvents { get; set; }
		public DbSet<Gender> Genders { get; set; }
		public DbSet<Province> Provinces { get; set; }
		public DbSet<Review> Reviews { get; set; }


		/// <summary>
		/// Creates admin user if none exists
		/// </summary>
		/// <param name="serviceProvider">Service Provider</param>
		/// <returns>Task to create admin</returns>
		public static async Task CreateAdminUser(IServiceProvider serviceProvider)
		{
			// Gets the user manager
			UserManager<Member> userManager = serviceProvider.GetRequiredService<UserManager<Member>>();

			// Gets the role manager
			RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

			// Sets the admin user properties
			string email = "admin@admin.com";
			string password = "admin";
			string roleName = "Admin";

			// Checks if the role does not exist
			if (await roleManager.FindByNameAsync(roleName) == null)
			{
				// Creates it if it doesn't
				await roleManager.CreateAsync(new IdentityRole(roleName));
			}

			// Checks if the admin exists
			if (await userManager.FindByNameAsync(email) == null)
			{
				Member admin = new Member { Email = email };
				var result = await userManager.CreateAsync(admin, password);

				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(admin, password);
				}
			}
		}

	   

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			var password = new PasswordHasher<Member>();

			// Only using this to make the asp tables
			builder.Entity<Member>().HasData(
				new Member
				{
					MemberId = "Admin",
					UserName = "admin",
					Email = "Admin@admin.com",
					PasswordHash = password.HashPassword(null, "admin"),
					PlatformId = 1,
					GenreId = 1,
					FirstName = "",
					LastName = "",
					GenderId = 1,
					ProvinceId = 1,
					StreetAddress = "421 Strawberry Road",
					City = "Waterloo",
					PostalCode = "",
					APSuiteNumber = "",
					DateOfBirth = DateTime.Now,
					MailingAddress = "",
					MailingAPNumber = "",
					MailingProvince = 1,
					MailingPostalCode = "",
					MailingCity = "",
					WishListId = 1,
					PromotionalEmail = false,
					EmailConfirmed = true
				},
				new Member
				{ 
					MemberId = "Testing",
					UserName = "Testing",
					Email = "NJackson6581@conestogac.on.ca",
					PasswordHash = password.HashPassword(null, "admin"),
					PlatformId = 1,
					GenreId = 1,
					ProvinceId = 1,
					EmailConfirmed = true,
					PromotionalEmail = false,
					WishListId = 2,
					City = "",
					FirstName = "",
					LastName = "",
					DateOfBirth = DateTime.Now,
					StreetAddress = "",
					PostalCode = "",
					MailingAddress = "",
					MailingAPNumber = "",
					MailingProvince = 1,
					MailingPostalCode = "",
					MailingCity = "",
					SameAsShipping = false,
					APSuiteNumber = ""
				}
			); 

			builder.Entity<Platform>().HasData(
				new Platform
				{
					PlatformId = 1,
					PlatformName = "NONE"
				},
				new Platform
				{
					PlatformId = 2,
					PlatformName = "PC"
				},
				new Platform
				{
					PlatformId = 3,
					PlatformName = "Playstation"
				},
				new Platform
				{
					PlatformId = 4,
					PlatformName = "Xbox"
				},
				new Platform
				{
					PlatformId = 5,
					PlatformName = "Nintendo Switch"
				}
			);

			builder.Entity<Genre>().HasData(
				new Genre
				{
					GenreId = 1,
					GenreName = "NONE",
				},
				new Genre
				{
					GenreId = 2,
					GenreName = "Sandbox"
				},
				new Genre
				{
					GenreId = 3,
					GenreName = "Strategy"
				},
				new Genre
				{
					GenreId = 4,
					GenreName = "FPS"
				},
				new Genre
				{
					GenreId = 5,
					GenreName = "MOBA"
				},
				new Genre
				{
					GenreId = 6,
					GenreName = "RPG"
				},
				new Genre
				{
					GenreId = 7,
					GenreName = "Simulation"
				},
				new Genre
				{
					GenreId = 8,
					GenreName = "Sports"
				},
				new Genre
				{
					GenreId= 9,
					GenreName = "Puzzle"
				},
				new Genre
				{
					GenreId = 10,
					GenreName = "Party"
				},
				new Genre
				{
					GenreId = 11,
					GenreName = "Action"
				},
				new Genre
				{
					GenreId = 12,
					GenreName = "Survivor"
				},
				new Genre
				{
					GenreId = 13,
					GenreName = "Horror"
				},
				new Genre
				{
					GenreId = 14,
					GenreName = "Platformer"
				}
			);

			builder.Entity<Game>().HasData(
				new Game
				{
					GameId = 1,
					GameName = "Call of Duty",
					GamePrice = 200.00,
					Inventory = 100,
					PhysicalEditor = "Infinity Ward",
					Publisher = "Battle.NET",
					ReleaseDate = new DateTime(year: 2022, month: 10, day: 28),
					GenreId = 4
				}/*,

				new Game
				{
					GameId = 2,
					GameName = "Minecraft",
					GamePrice = 56.00,
					Inventory = 100,
					PhysicalEditor = "Mojang Studios",
					Publisher = "Mojang Studios",
					ReleaseDate = new DateTime(year: 2011, month: 11, day: 18),
					GenreId = 2
				}*/
			);

			builder.Entity<CreditCard>().HasData(
				new CreditCard
				{
					CreditCardId = 1,
					MemberId= "abcd123",
					CardNumber = "1234-1234-1234",
					ExpiryDate = DateTime.Now.AddYears(2),
					CVV = 123
				},
				new CreditCard
				{
					CreditCardId = 2,
					MemberId  = "abcd1234",
					CardNumber = "1234-1234-1234",
					ExpiryDate = DateTime.Now.AddYears(3),
					CVV = 123
				}
			);

			builder.Entity<Wishlist>().HasData(
				new Wishlist
				{
					WishlistId = 1,
					GameId = 1,
					UserId = "46e733d2 - 6e60 - 4c7e - afc9 - 22796a13a145"
				}
			);

			builder.Entity<Event>().HasData(
				new Event
				{
					EventId = 1,
					EventName = "Testing",
					EventDetails = "An event to test the events features",
					EventDate = DateTime.Now.AddDays(5)
				}
			);

			builder.Entity<RegisteredEvents>().HasData(
				new RegisteredEvents
				{
					RegisteredEventId = 1,
					EventId = 1,
					MemberId = "abc123"
				}
			);

			builder.Entity<Gender>().HasData(
				new Gender
				{
					GenderId = 1,
					GenderName = ""
				},
				new Gender
				{
					GenderId = 2,
					GenderName = "Male",
				},
				new Gender
				{
					GenderId = 3,
					GenderName = "Female",
				},
				new Gender
				{
					GenderId = 4,
					GenderName = "Other",
				}
			);

			builder.Entity<Province>().HasData(
				new Province
				{
					ProvinceId = 1,
					ProvinceName = ""
				},
				new Province
				{
					ProvinceId = 2,
					ProvinceName = "Alberta"
				},
				new Province
				{
					ProvinceId = 3,
					ProvinceName = "Ontario"
				},
				new Province
				{
					ProvinceId = 4,
					ProvinceName = "Manitoba"
				},
				new Province
				{
					ProvinceId = 5,
					ProvinceName = "Quebec"
				},
				new Province
				{
					ProvinceId = 6,
					ProvinceName = "Nova Scotia"
				},
				new Province
				{
					ProvinceId = 7,
					ProvinceName = "Saskatchewan"
				},
				new Province
				{
					ProvinceId = 8,
					ProvinceName = "Britich Columbia"
				},
				new Province
				{
					ProvinceId = 9,
					ProvinceName = "New Brunswick"
				},
				new Province
				{
					ProvinceId = 10,
					ProvinceName = "Prince Edward Island"
				},
				new Province
				{
					ProvinceId = 11,
					ProvinceName = "Nunavut"
				},
				new Province
				{
					ProvinceId = 12,
					ProvinceName = "Newfoundland and Labrador"
				},
				new Province
				{
					ProvinceId = 13,
					ProvinceName = "Northwest Territories"
				},
				new Province
				{
					ProvinceId = 14,
					ProvinceName = "Yukon"
				}
			);

			builder.Entity<Review>().HasData(
				new Review
				{
					ReviewId = 1,
					GameId = 1,
					MemberName = "Admin",
					ReviewComments = "Test",
					Rating = 1,
					Approved = true
				}
			);
		}
	}
}
