using System;
using MelVincentAnonuevo_COMP306_Lab2.Models;
using Microsoft.EntityFrameworkCore;


namespace MelVincentAnonuevo_COMP306_Lab2
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Image> Images { get; set; }

		public DbSet<Album> Albums { get; set; }
	}
}

