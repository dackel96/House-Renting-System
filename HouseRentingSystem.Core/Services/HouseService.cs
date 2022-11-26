using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Exceptions;
using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Data.Common;
using HouseRentingSystem.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services
{
    public class HouseService : IHouseService
    {
        private readonly IRepository repository;
        private readonly IGuard guard;

        public HouseService(IRepository _repository, IGuard _guard)
        {
            repository = _repository;
            guard = _guard;
        }

        public async Task<HousesQueryModel> All(string? category = null, string? searchTerm = null, HouseSorting sorting = HouseSorting.Newest, int currentPage = 1, int housesPerPage = 1)
        {
            var result = new HousesQueryModel();

            var houses = repository.AllReadonly<House>()
                .Where(x => x.IsActive);

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

        public async Task<IEnumerable<HouseServiceModel>> AllHousesByAgentId(int id)
        {
            return await repository.AllReadonly<House>()
                .Where(x => x.IsActive)
                .Where(x => x.AgentId == id)
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
        }

        public async Task<IEnumerable<HouseServiceModel>> AllHousesByUserId(string id)
        {
            return await repository.AllReadonly<House>()
                .Where(x => x.IsActive)
                .Where(x => x.RenterId == id)
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

        public async Task Delete(int houseId)
        {
            var house = await repository.GetByIdAsync<House>(houseId);

            house.IsActive = false;

            await repository.SaveChangesAsync();
        }

        public async Task Edit(int houseId, HouseModel model)
        {
            var house = await repository.GetByIdAsync<House>(houseId);

            house.Title = model.Title;
            house.Address = model.Address;
            house.ImageUrl = model.ImageUrl;
            house.CategoryId = model.CategoryId;
            house.Description = model.Description;
            house.PricePerMonth = model.PricePerMonth;

            await repository.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await repository.AllReadonly<House>()
                .AnyAsync(x => x.Id == id && x.IsActive);
        }

        public async Task<int> GetHouseCategoryId(int houseId)
        {
            return (await repository.GetByIdAsync<House>(houseId)).CategoryId;
        }

        public async Task<bool> HasAgentWithId(int houseId, string userId)
        {
            bool result = false;

            var house = await repository.AllReadonly<House>()
                .Where(x => x.IsActive)
                .Where(x => x.Id == houseId)
                .Include(x => x.Agent)
                .FirstOrDefaultAsync();

            if (house?.Agent != null && house.Agent.UserId == userId)
            {
                result = true;
            }

            return result;

        }

        public async Task<HouseDetailsModel> HouseDetailsById(int id)
        {
            return await repository.AllReadonly<House>()
                .Where(x => x.IsActive)
                .Where(x => x.Id == id)
                .Select(x => new HouseDetailsModel()
                {
                    Address = x.Address,
                    Category = x.Category.Name,
                    Description = x.Description,
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    IsRented = x.RenterId != null,
                    PricePerMonth = x.PricePerMonth,
                    Title = x.Title,
                    Agent = new Models.Agent.AgentServiceModel()
                    {
                        Email = x.Agent.User.Email,
                        PhoneNumber = x.Agent.PhoneNumber
                    }

                })
                .FirstAsync();
        }

        public async Task<bool> IsRented(int houseId)
        {
            return (await repository.GetByIdAsync<House>(houseId)).RenterId != null;
        }

        public async Task<bool> IsRentedByUserWithId(int houseId, string currentUserId)
        {
            bool result = false;
            var house = await repository.AllReadonly<House>()
                .Where(x => x.IsActive)
                .Where(x => x.Id == houseId)
                .FirstOrDefaultAsync();

            if (house != null && house.RenterId == currentUserId)
            {
                result = true;
            }

            return result;
        }

        public async Task<IEnumerable<HouseHomeModel>> LastThreeHouses()
        {
            return await repository.AllReadonly<House>()
                .Where(x => x.IsActive)
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

        public async Task Leave(int houseId)
        {
            var house = await repository.GetByIdAsync<House>(houseId);

            guard.AgainstNull(house, "House can not be found");

            house.RenterId = null;

            await repository.SaveChangesAsync();

        }

        public async Task Rent(int houseId, string currentUserId)
        {
            var house = await repository.GetByIdAsync<House>(houseId);

            if (house != null && house.RenterId == currentUserId)
            {
                throw new ArgumentException("House is alredy rented");
            }

            guard.AgainstNull(house, "House can not be found");
            house!.RenterId = currentUserId;

            await repository.SaveChangesAsync();
        }
    }
}
