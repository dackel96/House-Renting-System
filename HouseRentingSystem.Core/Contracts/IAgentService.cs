using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Core.Contracts
{
    public interface IAgentService
    {
        Task<bool> ExistById(string userId);

        Task<bool> UserWithPhoneNumberExists(string phoneNum);

        Task<bool> UserHasRent(string userId);

        Task Create(string id, string phoneNum);

        Task<int> GetAgentId(string userId);
    }
}
