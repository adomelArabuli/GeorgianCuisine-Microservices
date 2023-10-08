using GeorgianCuisine.Web.Models;
using GeorgianCuisine.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GeorgianCuisine.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        public async Task<IActionResult> ProductIndex()
        {
            var products = new List<ProductDTO>();
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.GetAllProductsAsync<ResponseDTO>(accessToken);
            if (response != null && response.Success)
            {
                products = JsonConvert.DeserializeObject<List<ProductDTO>>(Convert.ToString(response.Result));
            }
            return View(products);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _productService.CreateProductAsync<ResponseDTO>(productDTO,accessToken);
                if (response != null && response.Success)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(productDTO);
        }

        public async Task<IActionResult> ProductEdit(int productId)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.GetProductByIdAsync<ResponseDTO>(productId,accessToken);
            if (response != null && response.Success)
            {
                ProductDTO productDTO = JsonConvert.DeserializeObject<ProductDTO>(Convert.ToString(response.Result));
                return View(productDTO);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductEdit(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _productService.UpdateProductAsync<ResponseDTO>(productDTO,accessToken);
                if (response != null && response.Success)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(productDTO);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ProductDelete(int productId)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.GetProductByIdAsync<ResponseDTO>(productId,accessToken);
            if (response != null && response.Success)
            {
                ProductDTO productDTO = JsonConvert.DeserializeObject<ProductDTO>(Convert.ToString(response.Result));
                return View(productDTO);
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductDelete(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _productService.DeleteProductAsync<ResponseDTO>(productDTO.ProductId,accessToken);
                if (response.Success)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(productDTO);
        }
    }
}
