using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HouseRentingSystem.Data.HouseConstants;
namespace HouseRentingSystem.Data.Data.Entities
{
    public class House
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMax)]
        public string ImageUrl { get; set; } = null!;

        [Column(TypeName = "money")]
        [Precision(PrecsisionDigits,PrecsisionAfterSign)]
        public decimal PricePerMonth { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        public int AgentId { get; set; }
        [ForeignKey(nameof(AgentId))]
        public  Agent Agent { get; set; } = null!;

        public string? RenterId { get; set; }
        [ForeignKey(nameof(RenterId))]
        public IdentityUser? Renter { get; set; }
    }
}