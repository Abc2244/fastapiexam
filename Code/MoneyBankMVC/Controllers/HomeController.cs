﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MoneyBankMVC.Models;
using MoneyBankMVC.Services;
using System.Diagnostics;

namespace MoneyBankMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly MoneybankdbContext _DBContext;

        public HomeController(MoneybankdbContext context)
        {
            _DBContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}