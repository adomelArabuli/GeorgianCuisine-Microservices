﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeorgianCuisine.Services.ShoppingCartApi.Models
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1,100)]
        public double Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
