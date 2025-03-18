using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
    public class News
    {
		[Key]
		public int News_Id { get; set; }
		public DateTime? Date { get; set; }
		public string? Title { get; set; }
		public string? PreDescription { get; set; }
		public string? Content { get; set; }
		public string? PhotoURL { get; set; }
	}
}
