using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Helpers;
using MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private ICartService _cartService;
        private ICartSessionHelper _cartSessionHelper;
        private IProductService _productService;

        public CartController(ICartService cartService, ICartSessionHelper cartSessionHelper, IProductService productService)
        {
            _cartService = cartService;
            _cartSessionHelper = cartSessionHelper;
            _productService = productService;
        }

        public IActionResult AddToCart(int productId)
        {
            //ürün çek
            Product product = _productService.GetById(productId);

            var cart = _cartSessionHelper.GetCart("cart");
            _cartService.AddToCart(cart,product);
            _cartSessionHelper.SetCart("cart", cart); //hata olabilir.

            TempData.Add("message", product.ProductName + " sepete eklendi");   //TempData =tek requeset'lik data taşır 

            return RedirectToAction("Index", "Product");
        }

        public IActionResult Index()
        {
            var model = new CartListViewModel
            {
                Cart = _cartSessionHelper.GetCart("cart")
            };
            return View(model);
        }

        public IActionResult RemoveFromCart(int productId)
        {
            //ürün çek
            Product product = _productService.GetById(productId);
            
            var cart = _cartSessionHelper.GetCart("cart");
            _cartService.RemoveFromCart(cart, productId);
            _cartSessionHelper.SetCart("cart", cart); //hata olabilir.

            TempData.Add("message", product.ProductName + " sepetten silindi");   //TempData =tek requeset'lik data taşır 

            return RedirectToAction("Index", "Cart");    //sepette kal demektir.
        }

        public IActionResult Complete() //sipariş tamamlama sayfası için
        {
            var model = new ShippingDetailsViewModel
            {
                ShippingDetail = new ShippingDetail()
            };
            return View(model);//get işlemi olduğundan direkt view yazıyoruz
        }

        [HttpPost]
        public IActionResult Complete(ShippingDetail shippingDetail)   //kullanıcı herşeyi doldurdu gönderiyor
        {
            if (!ModelState.IsValid) //geçersizse demektir
            {
                return View();
            }

            TempData.Add("message", "Siparişiniz Başarıyla Tamamlandı");
            _cartSessionHelper.Clear();
            return RedirectToAction("Index", "Cart");
        }
    }
}
