using HouseRentingSystem.Core.Models.House;

namespace HouseRentingSystem.Core.Contracts
{
    public interface IHouseService
    {
        Task<IEnumerable<HouseHomeModel>> LastThreeHouses();

        Task<IEnumerable<HouseCategoryModel>> AllCategories();

        Task<bool> CategoryExists(int categoryId);

        Task<int> Create(HouseModel model, int agentId);

        Task<HousesQueryModel> All(
             string? category = null
            , string? searchTerm = null
            , HouseSorting sorting = HouseSorting.Newest
            , int currentPage = 1
            , int housesPerPage = 1);

        Task<IEnumerable<string>> AllCategoriesNames();

        Task<IEnumerable<HouseServiceModel>> AllHousesByUserId(string id);

        Task<IEnumerable<HouseServiceModel>> AllHousesByAgentId(int id);

        Task<HouseDetailsModel> HouseDetailsById(int id);

        Task<bool> Exists(int id);

    }
}
