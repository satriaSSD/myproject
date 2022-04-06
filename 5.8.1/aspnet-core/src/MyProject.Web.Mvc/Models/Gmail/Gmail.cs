using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Web.Models.Gmail
{
    public class Gmail
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Body { get; set; }
        public DateTime MailDateTime { get; set; }
        public List<string> Attachments { get; set; }
        public string MsgId { get; set; }
    }
}
