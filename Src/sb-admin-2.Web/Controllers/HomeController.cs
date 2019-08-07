using System.Linq;
using System.Web.Mvc;
using EIP.Core.Extensions;
using EIP.Entities;
using sb_admin_2.Web.Models.Employee;

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
            var condition = new QueryCondition();
            return View(condition);
        }

        /// <summary>
        ///     查詢員工列表結果
        /// </summary>
        /// <param name="condition">查詢條件<see cref="QueryCondition" /></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetQueryData(QueryCondition condition)
        {
            var data = _db.Employees
                .Where(condition.EmployeeNo, x => x.No.Contains(condition.EmployeeNo))
                .Where(condition.EmplyeeName,
                    x => x.ChtName.Contains(condition.EmplyeeName) || x.EngName.Contains(condition.EmplyeeName))
                .Select(x => new QueryResult
                {
                    Id = x.Id,
                    ChtName = x.ChtName,
                    No = x.No
                })
                .ToPagedList(condition.Draw, condition.StartRecordCount, condition.PageSize);

            return Json(data);
        }
    }
}