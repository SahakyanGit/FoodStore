using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodStore.Domain.Abstract;
using FoodStore.Domain.Concrete;
using FoodStore.Domain.Entities;
using FoodStore.WebUI.Models;

namespace FoodStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository _repository = new EFProductRepository();

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel()
            {
                ReturnUrl = returnUrl,
                Cart = cart
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = _repository.Products.ToList().FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }

            return RedirectToAction("List", "Product");
        }


        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = _repository.Products.FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        //[HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }

            return View(new ShippingDetails());
        }
    }
}