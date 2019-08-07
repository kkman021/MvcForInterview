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

        public ActionResult Create()
        {
            var model = new Create();

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Create model)
        {
            if (!ModelState.IsValid)
            {
                NotifyError("有資料異常，請檢核");
                return View(model);
            }

            if (_db.Employees.Any(x => x.No == model.No.Trim()))
            {
                ModelState.AddModelError(nameof(model.No), "員工編號重覆");
                NotifyError("員工編號重覆，請重新輸入");
                return View(model);
            }

            var entity = new Employee()
            {
                ChtName = model.ChtName.Trim(),
                EngName = model.EngName.Trim(),
                Email = model.Email.Trim(),
                No = model.No.Trim()
                // 這邊不用每次寫 新增時間、人、更新時間、人，因為 SaveChanges 那邊寫好統一處理了
            };

            _db.Employees.Add(entity);
            _db.SaveChanges(EmployeeId);

            NotifySuccess("新增成功");
            return RedirectToAction("Index");
        }
    }
}