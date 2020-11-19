using COMP306_Project_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP306_Project_Backend.Services
{
    interface ILogRepository
    {
        Task<IEnumerable<LogDto>> GetAllByBusiness(string email);
        Task<IEnumerable<LogDto>> GetAllByCustomer(string email);
        Task<LogDto> Save(LogDto logDto);
        void Delete(string id);
    }
}
