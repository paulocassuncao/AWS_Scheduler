using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AWS_Scheduler.Models
{
    public class Credentials
    {
        public int Id { get; set; }
        public string CredentialsName { get; set; }
        public string AccessKeyId { get; set; }
        public string SecretAccessKey { get; set; }
    }
}