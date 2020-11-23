using COMP306_Project_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP306_Project_Backend.Services
{
    public interface ILogRepository
    {
        Task<IEnumerable<Log>> GetAllByBusiness(string email);
        Task<IEnumerable<Log>> GetAllByCustomer(string email);
        Task<Log> Save(Log logDto);
        void Delete(string id);
    }
}
