using Business.Abstract;
using Microsoft.AspNetCore.Mvc; //controller için
using MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index(int category)
        {
            var model = new ProductListViewModel
            {
                Products = category>0?_productService.GetByCategory(category):_productService.GetAll()  //if koşulu koyduk category varsa ona göre yoksa hepsi listelenecek
            };
            return View(model);
        }
    }
}
