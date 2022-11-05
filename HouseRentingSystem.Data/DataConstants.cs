using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Data
{
    public static class DataConstants
    {
    }
    public static class CategoryConstants
    {
        public const int NameMaxLength = 50;

        public const int NameMinLength = 0;
    }

    public static class HouseConstants
    {
        public const int TitleMaxLength = 50;

        public const int TitleMinLength = 10;

        public const int AddressMaxLength = 150;

        public const int AddressMinLength = 30;

        public const int DescriptionMaxLength = 500;

        public const int DescriptionMinLength = 50;

        public const int PricePerMonthMax = 2000;

        public const int PricePerMonthMin = 0;

        public const int ImageUrlMax = 1000;

        public const int ImageUrlMin = 0;

        public const int PrecsisionDigits = 18;

        public const int PrecsisionAfterSign = 2;
    }

    public static class AgentConstants
    {
        public const int PhoneNumberMax = 15;

        public const int PhoneNumberMin = 7;
    }
}
