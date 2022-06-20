﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Interfaces;

namespace Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketViewModelService _basketViewModelService;

        public BasketController(IBasketViewModelService basketViewModelService)
        {
            _basketViewModelService = basketViewModelService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _basketViewModelService.GetBasketViewModelAsync());
        }


        [HttpPost]
        public async Task<IActionResult> AddItem(int productId, int quantity = 1)
        {
            int totalItems = await _basketViewModelService.AddItemToBasketAsync(productId, quantity);
            return Json(new { totalItems });
        }
    }
}