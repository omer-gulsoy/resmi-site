using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class ContactType
	{
		[Key]
		public int ContactType_Id { get; set; }
		public string? Name { get; set; }

		// Navigation property için ICollection kullanabilirsin
		public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
	}

}
