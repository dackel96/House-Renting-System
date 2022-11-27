using HouseRentingSystem.Core.Contracts;
using System.Text;
using System.Text.RegularExpressions;

namespace HouseRentingSystem.Extensions
{
    public static class ModelExtension
    {
        public static string GetInformation(this IHouseModel house)
        {
            var text = new StringBuilder();

            text.Append(house.Title.Replace(" ", "-"));
            text.Append("-");
            text.Append(GetAddress(house.Address));

            return text.ToString();
        }

        private static string GetAddress(string address)
        {
            string result = string.Join("-", address.Split(" ", StringSplitOptions.RemoveEmptyEntries).Take(3));

            return Regex.Replace(address, @"[^a-zA-Z0-9\-]", string.Empty);

        }
    }
}
