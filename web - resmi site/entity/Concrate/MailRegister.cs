﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.Concrate
{
    public class MailRegister
    {
		[Key]
		public int MailRegister_Id { get; set; }
		public string? Email { get; set; }
	}
}
