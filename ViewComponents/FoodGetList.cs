using CoreAndFood2.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood2.ViewComponents
{
    public class FoodGetList : ViewComponent

    {

        public IViewComponentResult Invoke()

        {
            FoodRepository categoryRepository = new FoodRepository();
            var foodlist = categoryRepository.TList();
            return View(foodlist);


        }
    }
}