using System;
using Microsoft.EntityFrameworkCore;
using RealEstate.Models;


// DATABASE
namespace RealEstate.Data
{
	public class ApiDbContext : DbContext
	{
		// TABLES
		// Categories table
		public DbSet<Category> Categories { get; set; }
		public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }


        // Connection String to DB Context Class
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//base.OnConfiguring(optionsBuilder);

			optionsBuilder.UseSqlServer(@"server=localhost;database=test;trusted_connection=false;User Id=sa;Password=reallyStrongPwd123;Persist Security Info=False;Encrypt=False");

		}

		//public ApiDbContext(DbContextOptions<ApiDbContext> options):base(options)
		//{

		//}

	}
}

