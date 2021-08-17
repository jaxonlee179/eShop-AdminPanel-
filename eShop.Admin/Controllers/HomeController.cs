using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using eShop.DatabaseRepository.DbRepos;
using eShop.DatabaseRepository.DbModels;
using Microsoft.AspNetCore.Authorization;

namespace eShop.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {     
        public IActionResult Index()
        {
            return View();
        }  
    }
}
