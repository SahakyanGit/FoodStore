using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodStore.Domain.Abstract;
using FoodStore.Domain.Concrete;
using FoodStore.Domain.Entities;
using FoodStore.WebUI.Infrastructure;
using FoodStore.WebUI.Models;

namespace FoodStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public IProductRepository _repository;
        public int _pageSize = 4;

        public ViewResult List(string category,int page=1)
        {
            _repository = new EFProductRepository();
            //return View(_repository.Products.OrderBy(p=>p.ProductID).Skip((page-1)*_pageSize).Take(_pageSize));

            ProductsListViewModel model = new ProductsListViewModel
            {
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = _pageSize,
                    //TotalItems = _repository.Products.ToList().Count
                    TotalItems = category == null ? _repository.Products.Count() : _repository.Products.Where(e=>e.Category==category).Count(),
                } ,
                
                CurrentCategory =  category
            };

            if (category != null)
            {
                model.Products =
                               _repository.Products.ToList()
                                   .Where(p => p.Category == category)
                                   .OrderBy(p => p.ProductID)
                                   .Skip((page - 1) * _pageSize)
                                   .Take(_pageSize);
            }
            else
            {
                model.Products = _repository.Products.ToList().OrderBy(p => p.ProductID).Skip((page - 1) * _pageSize).Take(_pageSize);
            }

            return View(model);
        }

        public ViewResult Details(int productId)
        {
            _repository = new EFProductRepository();
            ProductsListViewModel model = new ProductsListViewModel();
            model.Products = _repository.Products.ToList().Where(p => p.ProductID == productId);

            return View(model);
        }
    }
}