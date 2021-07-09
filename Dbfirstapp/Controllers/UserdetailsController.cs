using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dbfirstapp.Controllers
{
    public class UserdetailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}