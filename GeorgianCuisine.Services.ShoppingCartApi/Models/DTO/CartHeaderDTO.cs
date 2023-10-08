using System.ComponentModel.DataAnnotations;

namespace GeorgianCuisine.Services.ShoppingCartApi.Models.DTO
{
    public class CartHeaderDTO
    {
        public int CartHeaderId { get; set; }
        public string UserId { get; set; }
        public string CouponCode { get; set; }
    }
}
