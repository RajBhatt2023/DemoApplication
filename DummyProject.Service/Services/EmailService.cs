using DummyProject.Repository.IRepository;
using DummyProject.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyProject.Service.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _emailRepository;

        public EmailService(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            await _emailRepository.SendEmailAsync(toEmail, subject, body);
        }

    }
}
