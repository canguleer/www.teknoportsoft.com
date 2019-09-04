using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace TeknoportSoft.Models
{
	public class MailSender
	{
		public bool SendMailNt(MailView detail)
		{
			string baslik = "Gönderen :" + detail.name + "<br /> Telefon :" + detail.phone + " <br /> E-Posta :" + detail.email;

			bool sonuc = false;
			MailMessage mm = new MailMessage();
			mm.To.Add(new MailAddress("erhan.gurbuz@teknoportsoft.com", "Yeni Web Bildirim Mesajı"));
			mm.From = new MailAddress("talep@teknoportsoft.com");
			mm.Sender = new MailAddress("talep@teknoportsoft.com", "Yeni Web Bildirim Mesajı");
			mm.Subject = baslik;
			mm.Body = detail.body;
			mm.IsBodyHtml = true;
			mm.Priority = MailPriority.High; // Set Priority to sending mail
			SmtpClient smtCliend = new SmtpClient();
			smtCliend.Host = "mail.teknoportsoft.com";
			smtCliend.Port = 587;    // SMTP port no            
			smtCliend.Credentials = new NetworkCredential("talep@teknoportsoft.com", "PDha45M4");
			smtCliend.DeliveryMethod = SmtpDeliveryMethod.Network;
			try
			{
				smtCliend.Send(mm);
				sonuc = true;
			}
			catch (Exception ex)
			{
				sonuc = false;
			}
			return sonuc;
		}


		public bool SendEmail(MailView detail)
		{
			bool sonuc = false;
			using (MailMessage mail = new MailMessage())
			{
				string bodyx = "Gönderen :" + detail.name + "<br /> Telefon :" + detail.phone + " <br /> E-Posta :" + detail.email + "<br /> Mesaj içerik:"+ detail.body;
				mail.From = new MailAddress("xcan1534@gmail.com", "Site Mesajı");
				mail.To.Add("erhan.gurbuz@teknoportsoft.com");
				mail.Subject = detail.name +" Adlı kişiden yeni mesaj bildirimi";
				mail.Body = bodyx;
				mail.IsBodyHtml = true;			
				using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
				{
					try
					{
						smtp.Credentials = new NetworkCredential("xcan1534@gmail.com", "copypaste12345");
						smtp.EnableSsl = true;
						smtp.Send(mail);
						sonuc = true;
					}
					catch (Exception ex)
					{
						sonuc = false;
					}
				}
			}
			return sonuc;
		}
	}

}