using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using March23.Models;

namespace March23.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Home(bool asc)
        {
            CarManger mgr = new CarManger(@"Data Source=.\sqlexpress;Initial Catalog=Cars;Integrated Security=True;");
            Homeviewmodel hmv = new Homeviewmodel();
            hmv.cars = mgr.GetAll(asc);
            hmv.asc = asc;
            return View(hmv);
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult AddCar(Cars c)
        {
            CarManger mgr = new CarManger(@"Data Source=.\sqlexpress;Initial Catalog=Cars;Integrated Security=True;");
            mgr.AddCar(c);
            return Redirect("/Home/home");
        }
   

        
    }
}
