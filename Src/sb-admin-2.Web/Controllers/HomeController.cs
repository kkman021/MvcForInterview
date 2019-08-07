using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EIP.Entities;

namespace sb_admin_2.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IEipDbContext _db;

        public HomeController(IEipDbContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            var data = _db.Employees.ToList();

            return View();
        }

    }
}