using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Statistic;
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
    public class StatisticService : IStatisticService
    {
        private readonly IRepository repository;
        public StatisticService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<StatisticsServiceModel> Tottal()
        {
            int tottalHouses = await repository.AllReadonly<House>().CountAsync(x => x.IsActive);

            int tottalRented = await repository.AllReadonly<House>().CountAsync(x => x.IsActive && x.RenterId != null);

            return new StatisticsServiceModel()
            {
                TotalHouses = tottalHouses,
                TotalRents = tottalRented
            };
        }
    }
}
