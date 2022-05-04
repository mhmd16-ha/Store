using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Data.Interfaces;
using Store.Models;
using Store.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _model;

        public HomeController(IProductRepository product)
        {
            _model = product;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                PreferredProduct = _model.PreferedProducts,
            };
            return View(model);
        }

      
    }
}
