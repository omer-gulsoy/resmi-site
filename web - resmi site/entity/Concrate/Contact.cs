using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class Contact
	{
		[Key]
		public int Contact_Id { get; set; }
		public string? Text { get; set; }

		// Foreign Key'in hangi sütuna karşılık geldiğini açıkça belirtiyoruz.
		[ForeignKey(nameof(ContactType))]
		public int ContactType_Id { get; set; }

		public ContactType ContactType { get; set; } = null!;
	}
}
