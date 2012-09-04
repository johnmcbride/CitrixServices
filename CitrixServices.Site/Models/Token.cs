using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitrixServices.Site.Models
{
    public class Token
    {
        public Guid ID { get; set; }
        public string Username { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateExpired { get; set; }
    }
}