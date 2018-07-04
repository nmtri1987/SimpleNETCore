using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaraDataRequestApplication.Services
{
    public interface IEmailService
    {
        void SendEmail(string receivers, string subject, string message);
    }
}
