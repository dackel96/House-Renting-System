using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Data.Common;
using HouseRentingSystem.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Core.Services
{
    public class AgentService : IAgentService
    {
        private readonly IRepository repository;

        public AgentService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task Create(string id, string phoneNum)
        {
            var agent = new Agent()
            {
                UserId = id,
                PhoneNumber = phoneNum
            };

            await repository.AddAsync(agent);

            await repository.SaveChangesAsync();
        }

        public async Task<bool> ExistById(string userId)
        {
            return await repository.All<Agent>()
                .AnyAsync(a => a.UserId == userId);
        }

        public async Task<int> GetAgentId(string userId)
        {
            return (await repository.AllReadonly<Agent>()
                .FirstOrDefaultAsync(a => a.UserId == userId))?.Id ?? 0;
        }

        public async Task<bool> UserHasRent(string userId)
        {
            return await repository.All<House>()
               .AnyAsync(x => x.RenterId == userId);
        }

        public async Task<bool> UserWithPhoneNumberExists(string phoneNum)
        {
            return await repository.All<Agent>()
               .AnyAsync(x => x.PhoneNumber == phoneNum);
        }
    }
}
