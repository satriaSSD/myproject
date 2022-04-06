using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Contact.Dto
{
    public class GmailDto
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Body { get; set; }
        public DateTime MailDateTime { get; set; }
        public List<string> Attachments { get; set; }
        public string MsgId { get; set; }
    }
}
