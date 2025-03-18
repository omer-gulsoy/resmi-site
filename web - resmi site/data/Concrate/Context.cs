using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity.Concrate;
using System.Reflection.Metadata;

namespace data.Concrate
{
	public class Context : IdentityDbContext<AppUser, AppRole, int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=ELITEBOOK\\MSSQLSERVER2012;database=ResmiSiteDB;integrated security=true;TrustServerCertificate=True;");
		}
		public DbSet<Contact>? Contacts { get; set; }
		public DbSet<ContactType>? ContactTypes { get; set; }
		public DbSet<ContactForm>? ContactForms { get; set; }
		public DbSet<MailRegister>? MailRegisters { get; set; }
		public DbSet<News>? News { get; set; }
		public DbSet<Event>? Events { get; set; }
		public DbSet<Notice>? Notices { get; set; }
		public DbSet<Service>? Services { get; set; }
		public DbSet<Modul>? Moduls { get; set; }
		public DbSet<Product>? Products { get; set; }
		public DbSet<DemoBasvuru>? DemoBasvurus { get; set; }
	}
}
