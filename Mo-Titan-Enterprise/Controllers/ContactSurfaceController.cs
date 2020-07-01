using Mo_Titan_Enterprise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Mvc;

namespace Mo_Titan_Enterprise.Controllers
{
	public class ContactSurfaceController : SurfaceController
	{
		public const string PARTIAL_VIEW_FOLDER = "~/Views/Partials/ContactSurface/";

		public ActionResult RenderForm()
		{
			//Return a partial view ContactForm.cshtml in /views/ContactFormSurface/ContactForm.cshtml
			//With an empty/new ContactFormViewModel
			return PartialView(PARTIAL_VIEW_FOLDER + "_Contact.cshtml");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult SubmitForm(ContactModel model)
		{
			if(ModelState.IsValid)
			{
				SendMail();
				TempData["Success"] = "Your message has been submitted successfully. We will back to you as soon as posible.";
				return RedirectToCurrentUmbracoPage();
			}
			return CurrentUmbracoPage();
		}


		public void SendMail()
		{
			try
			{
				var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
				var message = new MailMessage();
				message.From = new MailAddress("fabrutu@gmail.com");
				message.To.Add("rutu.gadhethariya@gmail.com");
				message.Subject = "Your email subject";
				message.Body = body;
				message.IsBodyHtml = true;

				using (var smtp = new SmtpClient())
				{
					var credential = new NetworkCredential
					{
						UserName = "fabrutu@gmail.com",  // replace with valid value
						Password = "shahinpatel2374907"  // replace with valid value
					};
					smtp.Credentials = credential;
					smtp.Host = "smtp.gmail.com";
					smtp.Port = 587;
					smtp.EnableSsl = true;
					smtp.Send(message);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				TempData["Error"] = "Something went wrong please try again or contact us on given phone no.";
			}
		}
	}
}