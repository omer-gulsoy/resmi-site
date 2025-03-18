using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
    public class Modul
    {
		[Key]
		public int Modul_Id { get; set; }
		public string? Title { get; set; }
		public string? ShortText { get; set; }
		public string? Text { get; set; }
		public string? PhotoURL { get; set; }
		[ForeignKey("Product")]
		public int? Product_Id { get; set; }
		public Product? Product { get; set; }
	}
}
