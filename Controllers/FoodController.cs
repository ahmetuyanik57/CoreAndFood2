﻿using CoreAndFood2.Data.Models;
using CoreAndFood2.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreAndFood2.Controllers
{
    [AllowAnonymous]
    
    public class FoodController : Controller
    {
        
        FoodRepository foodRepository = new FoodRepository();
        Context c = new Context();
        public IActionResult Index(int page = 1)
        {
            return View(foodRepository.TList("Category").ToPagedList(page, 3));
        }
        [HttpGet]
        
        public IActionResult AddFood()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            return View();
        }
        [HttpPost]

        public IActionResult AddFood(Food p)
        {
            foodRepository.TAdd(p);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteFood(int id)
        {
            foodRepository.TDelete(new Food { FoodID = id });
            return RedirectToAction("Index");
        }
        public IActionResult FoodGet (int id)
        {

            var x = foodRepository.TGet(id);
            List<SelectListItem> values = (from y in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            Food f = new Food()
            {
                FoodID=x.FoodID,
                CategoryID = x.CategoryID,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock,
                Description = x.Description,
                ImageURL = x.ImageURL

            };
            return View(f);

        }
        public IActionResult FoodUpdate(Food p)
        {

            var x = foodRepository.TGet(p.FoodID);
            x.Name = p.Name;
            x.Stock = p.Stock;
            x.Price = p.Price;
            x.ImageURL = p.ImageURL;
            x.Description = p.Description;
            x.CategoryID = p.CategoryID;
            foodRepository.TUpdate(x);
            return RedirectToAction("Index"); 
                
                
        }
    }
}
