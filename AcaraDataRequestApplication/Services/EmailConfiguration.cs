using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaraDataRequestApplication.Services
{
    public class EmailConfiguration
    {
        public string FromName { get; set; }
        public string FromAddress { get; set; }

        public string MailServerAddress { get; set; }
        public int MailServerPort { get; set; }
        public bool EnableSSL { get; set; }

        public string UserId { get; set; }
        public string UserPassword { get; set; }

        public string AdminEmailAddress { get; set; }
    }
}
