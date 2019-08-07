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
                .OrderBy(x=> x.Id)
                .ToPagedList(condition.Draw, condition.Start, condition.Length);

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

            var entity = new Employee
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

        public ActionResult Edit(int id)
        {
            var model = _db.Employees
                .Where(x => x.Id == id)
                .Select(x => new Edit
                {
                    Id = x.Id,
                    ChtName = x.ChtName,
                    EngName = x.EngName,
                    Email = x.Email,
                    No = x.No
                })
                .FirstOrDefault();

            if (model == null)
            {
                NotifyError("查無資料，或資料已被刪除");
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(Edit model)
        {
            if (!ModelState.IsValid)
            {
                NotifyError("有資料異常，請檢核");
                return View(model);
            }

            if (_db.Employees.Any(x => x.No == model.No.Trim() && x.Id != model.Id))
            {
                ModelState.AddModelError(nameof(model.No), "員工編號重覆");
                NotifyError("員工編號重覆，請重新輸入");
                return View(model);
            }

            var entity = _db.Employees.Find(model.Id);

            if (entity == null)
            {
                NotifyError("查無資料，或資料已被刪除");
                return RedirectToAction("Index");
            }

            entity.No = model.No.Trim();
            entity.ChtName = model.ChtName.Trim();
            entity.EngName = model.EngName.Trim();
            entity.Email = model.Email.Trim();

            _db.SaveChanges(EmployeeId);

            NotifySuccess("更新成功");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var entity = _db.Employees.Find(id);

            if (entity == null)
            {
                Response.StatusCode = 400;
                return Json("查無資料");
            }

            _db.Employees.Remove(entity);
            _db.SaveChanges(EmployeeId);
            
            return Json("刪除成功");
        }
    }
}