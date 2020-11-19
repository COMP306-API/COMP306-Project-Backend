using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP306_Project_Backend.Models
{
    public class LogDto
    {
        public string BusinessEmail { get; set; }
        public string DateVisited { get; set; }
        public string TimeVisited { get; set; }
        public string ClientEmail { get; set; }

        public LogDto(
            string BusinessEmail,
            string DateVisited,
            string TimeVisited,
            string ClientEmail
            )
        {
            this.BusinessEmail = BusinessEmail;
            this.DateVisited = DateVisited;
            this.TimeVisited = TimeVisited;
            this.ClientEmail = ClientEmail;
        }
    }
}
