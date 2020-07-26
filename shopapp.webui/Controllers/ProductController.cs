using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using shopapp.webui.Data;
using shopapp.webui.Models;

namespace shopapp.webui.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {

            var product = new Product { Name = "Iphone X", Price = 6000, Description = "İyi Telefon" };

            ViewBag.Category = "Telefonlar";

            return View(product);//model
        }
        public IActionResult list(int? id)
        { 
            var products=ProductRepository.Products;
            if(id!=null)
            {
                products=products.Where(p=>p.CategoryId==id).ToList();
            }
        var productsViewModel = new ProductViewModel//her ikisinide kullanmak için progda viewmodels klasörü açtım içine category ve list ekledim
        {
            Products =products
        };

            return View(productsViewModel);//burdanda viewe gönderdim ve şimdi productsviewmodeli @model ..... olarak başa yazacağım
        }

        public IActionResult Details(int id)
        {
            return View(ProductRepository.GetProductById(id));
        }


    }
}