using Horeca.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Horeca.DataAccessLayer
{
	public class HorecaContext : DbContext
	{
		public HorecaContext()
		{

		}

		public HorecaContext(DbContextOptions<HorecaContext> options) : base(options)
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
		{
			optionBuilder.UseSqlServer(@"Server=(local);Database=Horeca;Trusted_Connection=True;");
		}

		public DbSet<Identification> Identifications { get; set; }
		public DbSet<Information> Informations { get; set; }
		public DbSet<Shedule> Shedules { get; set; }
	}
}
