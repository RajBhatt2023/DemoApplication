using DummyProject.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Dummy.Domain.Entities;
using DummyProject.Repository.ApplicationDbContext;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DummyProject.Repository.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly AppDbContext _dbContext;

        public EmailRepository(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                using (var smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential("rajbhattlearning2023@gmail.com", "ftjh djqf wmca djxf");
                    smtpClient.EnableSsl = true;

                    using (var mailMessage = new MailMessage
                    {
                        From = new MailAddress("rajbhattlearning2023@gmail.com"),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = true,
                    })
                    {
                        mailMessage.To.Add("rajbhattlearning2023@gmail.com");
                        await smtpClient.SendMailAsync(mailMessage);

                        // Save email information in the database
                        await SaveEmailInformation(toEmail, subject, body);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public async Task SendEmailAsync(string toEmail, string sub, string bo)
        //{
        //    try
        //    {
        //        // Set your email configuration
        //        var fromAddress = new MailAddress("rajbhattlearning2023@gmail.com", "Raj");
        //        var toAddress = new MailAddress("test1993oiuytr@yopmail.com", "Recipient Name");
        //        const string subject = "Subject of your email";
        //        const string body = "Body of your email"; 

        //        // Create the email message
        //        using (var message = new MailMessage(fromAddress, toAddress)
        //        {
        //            Subject = subject,
        //            Body = body,
        //            IsBodyHtml = false // Set to true if your body contains HTML
        //        })
        //        {
        //            // Set up the SMTP client
        //            using (var smtpClient = new SmtpClient("smtp.gmail.com"))
        //            {
        //                smtpClient.Port = 465;
        //                smtpClient.Credentials = new NetworkCredential("rajbhattlearning2023@gmail.com", "ftjh djqf wmca djxf");
        //                smtpClient.EnableSsl = true;

        //                // Send the email synchronously
        //                smtpClient.Send(message);
        //            }
        //        }


        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //        // Handle exceptions, log errors, etc.

        //    }
        //}


        private async Task SaveEmailInformation(string toEmail, string subject, string body)
        {
            var emailModel = new EmailEntity
            {
                ToEmail = toEmail,
                Subject = subject,
                Body = body,
                //SentDate = DateTime.Now,
            };

            _dbContext.Emails.Add(emailModel);
            await _dbContext.SaveChangesAsync();
        }
    }
}