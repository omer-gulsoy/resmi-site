using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
    public class DemoBasvuru
    {
		[Key]
		public int DemoBasvuru_Id { get; set; }
		public string? Isim { get; set; }
		public string? Soyisim { get; set; }
		public string? Mail { get; set; }
		public string? TelefonSabit { get; set; }
		public string? TelefonCep { get; set; }
		public string? Unvan { get; set; }
		public string? KurumIsmi { get; set; }
		public string? Aciklama { get; set; }
	}
}
