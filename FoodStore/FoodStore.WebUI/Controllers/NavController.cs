using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodStore.Domain.Abstract;
using FoodStore.Domain.Concrete;

namespace FoodStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository _repository;


        // GET: Nav
        public PartialViewResult Menu(string category =null)
        {
            ViewBag.SelectedCategory = category;


            _repository = new EFProductRepository();
            IEnumerable<string> categories = _repository.Products.ToList().Select(x => x.Category).Distinct().OrderBy(x => x);

            return PartialView(categories);
        }
    }
}