using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace Mo_Titan_Enterprise.Model
{
	public class ContactModel
  {
    [Required, Display(Name = "Enter Your name")]
      public string Firstname { get; set; }
      [Required, Display(Name = "Your email"), EmailAddress]
      public string Email { get; set; }
      [Required]
      public string Subject { get; set; }
      [Required]
      public string Message { get; set; }
  }
}