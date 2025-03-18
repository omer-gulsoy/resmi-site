using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
	public class Product
	{
		[Key]
		public int Product_Id { get; set; }
		public string? Title { get; set; }
		public string? ShortText { get; set; }
		public string? Text { get; set; }
		public string? PhotoURL { get; set; }
		public List<Modul>? Moduls { get; set; }
	}
}
