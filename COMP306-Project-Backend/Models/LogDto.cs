using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP306_Project_Backend.Models
{
    public class LogDto
    {
        public string Id { get; set; }
        public string BusinessEmail { get; set; }
        public string ClientEmail { get; set; }
        public string VisitedDate { get; set; }
        public string VisitedTime { get; set; }

        public LogDto(
            string Id,
            string BusinessEmail,
            string ClientEmail,
            string VisitedDate,
            string VisitedTime
            )
        {
            this.Id = Id;
            this.BusinessEmail = BusinessEmail;
            this.ClientEmail = ClientEmail;
            this.VisitedDate = VisitedDate;
            this.VisitedTime = VisitedTime;
        }
    }
}
