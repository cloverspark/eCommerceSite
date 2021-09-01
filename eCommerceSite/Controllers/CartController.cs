﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerceSite.Data;
using eCommerceSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace eCommerceSite.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public CartController(ProductContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        /// <summary>
        /// Adds a product to the shopping cart
        /// </summary>
        /// <param name="id">The id of the product to add</param>
        /// <returns></returns>
        public async Task<IActionResult> Add(int id, string prevUrl)
        {
            Product p = await ProductDb.GetProductAsync(_context, id);

            CookieHelper.AddProductToCart(_httpContext, p);

            TempData["Message"] = p.Title + " added successfully";

            // Redirect back to previous page
            return Redirect(prevUrl);
        }

        public IActionResult Summary()
        {
            List<Product> cartProducts = CookieHelper.GetCartProducts(_httpContext);
            return View(cartProducts);
        }
    }
}