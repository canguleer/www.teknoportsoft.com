using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknoportSoft.Models;

namespace TeknoportSoft.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		[ValidateAntiForgeryToken]
		public ActionResult SendMail(MailView data)
		{
			bool sonuc = new MailSender().SendEmail(data);
			return Json(sonuc, JsonRequestBehavior.AllowGet);
		}



	}
}