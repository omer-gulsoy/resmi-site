using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
    public class IsBasvuru
    {
		[Key]
		public int IsBasvuru_Id { get; set; }
		public string? Ad { get; set; }
		public string? Soyad { get; set; }
		public bool? Cinsiyet { get; set; }
		public DateTime? DogumTarihi { get; set; }
		public string? DogumYeri { get; set; }
		public string? TelefonGSM { get; set; }
		public string? TelefonEV { get; set; }
		public string? Eposta { get; set; }
		public string? MedeniHal { get; set; }
		public string? Uyruk { get; set; }
		public string? Il { get; set; }
		public string? Ilce { get; set; }
		public string? Adres { get; set; }
		public string? MezuniyetDerecesi { get; set; }
		public string? Bolum { get; set; }
		public string? SonOkul { get; set; }
		public int? MezuniyetYil { get; set; }
		public string? AskerlikDurumu { get; set; }
		public DateTime? AskerlikTarihi { get; set; }
		public bool? EhliyetVarMi { get; set; }
		public string? EhliyetSinif { get; set; }
		public DateTime? EhliyetTarihi { get; set; }
		public string? YabanciDil { get; set; }
		public string? YabanciDilDerece { get; set; }

	}
}
