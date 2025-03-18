using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
    public class YabanciDil
    {
		[Key]
		public int YabanciDil_Id { get; set; }
		public string? MyProperty { get; set; }
	}
}
