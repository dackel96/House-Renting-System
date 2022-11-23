using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Data.Common;
using HouseRentingSystem.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services
{
    public class HouseService : IHouseService
    {
        private readonly IRepository repository;

        public HouseService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<HousesQueryModel> All(string? category = null, string? searchTerm = null, HouseSorting sorting = HouseSorting.Newest, int currentPage = 1, int housesPerPage = 1)
        {
            var result = new HousesQueryModel();

            var houses = repository.AllReadonly<House>();

            if (string.IsNullOrEmpty(category) == false)
            {
                houses = houses
                    .Where(x => x.Category.Name == category);
            }

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                searchTerm = $"%{searchTerm.ToLower()}%";

                houses = houses
                    .Where(x =>
                    EF.Functions.Like(x.Title.ToLower(), searchTerm)
                    || EF.Functions.Like(x.Address.ToLower(), searchTerm)
                    || EF.Functions.Like(x.Description.ToLower(), searchTerm));
            }

            houses = sorting switch
            {
                HouseSorting.Price => houses
                .OrderBy(x => x.PricePerMonth),
                HouseSorting.NotRentedFirst => houses
                .OrderBy(x => x.RenterId),
                _ => houses.OrderByDescending(x => x.Id)
            };

            result.Houses = await houses
                .Skip((currentPage - 1) * housesPerPage)
                .Take(housesPerPage)
                .Select(x => new HouseServiceModel()
                {
                    Address = x.Address,
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    IsRented = x.RenterId != null,
                    PricePerMonth = x.PricePerMonth,
                    Title = x.Title
                })
                .ToListAsync();

            result.TotalHouseCount = await houses.CountAsync();

            return result;
        }

        public async Task<IEnumerable<HouseCategoryModel>> AllCategories()
        {
            return await repository.AllReadonly<Category>()
                .OrderBy(x => x.Name)
                .Select(x => new HouseCategoryModel()
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllCategoriesNames()
        {
            return await repository.AllReadonly<Category>()
                .Select(x => x.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<bool> CategoryExists(int categoryId)
        {
            return await repository.AllReadonly<Category>()
                .AnyAsync(x => x.Id == categoryId);
        }

        public async Task<int> Create(HouseModel model, int agentId)
        {
            var house = new House()
            {
                AgentId = agentId,
                Address = model.Address,
                CategoryId = model.CategoryId,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                PricePerMonth = model.PricePerMonth,
                Title = model.Title
            };

            await repository.AddAsync<House>(house);

            await repository.SaveChangesAsync();

            return house.Id;
        }

        public async Task<IEnumerable<HouseHomeModel>> LastThreeHouses()
        {
            return await repository.AllReadonly<House>()
                .OrderByDescending(h => h.Id)
                .Select(h => new HouseHomeModel()
                {
                    Id = h.Id,
                    ImageUrl = h.ImageUrl,
                    Title = h.Title
                })
                .Take(3)
                .ToListAsync();
        }
    }
}
