using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Bootsrap_Codefirst.Models;

namespace Mvc_Bootsrap_Codefirst.Controllers
{
    public class EmployeeController : Controller
    {
        public DatabaseContext _db = new DatabaseContext();
        public ActionResult AddEmployee(int id=0)
        {
            ViewBag.ctr = _db.tblcountries.ToList();
            ViewBag.Bt = "Create";
            tblEmployee obj = new tblEmployee();
            if (id > 0)
            {
                var data = (from a in _db.tblEmployees where a.empid==id select a).ToList();
                obj.empid = data[0].empid;
                obj.name = data[0].name;
                obj.age = data[0].age;
                obj.country = data[0].country;
                obj.state = data[0].state;
                ViewBag.Bt = "Update";
            }
            ViewBag.stt= _db.tblstates.Where(x => x.cid == obj.country).ToList();
            return View(obj);
        }
        [HttpPost]
        public ActionResult AddEmployee(tblEmployee _emp)
        {
            if (_emp.empid > 0)
            {
                _db.Entry(_emp).State = System.Data.Entity.EntityState.Modified;
            }
            
            else
            {
                _db.tblEmployees.Add(_emp);
            }
            _db.SaveChanges();
            return RedirectToAction("ShowEmployee");
        }

        public ActionResult ShowEmployee()
        {
            var data = (from a in _db.tblEmployees
                        join b in _db.tblcountries on a.country equals b.cid
                        join c in _db.tblstates on a.state equals c.sid
                        select new tblEmployee1 {empid=a.empid,name=a.name,age=a.age,country=b.cname,state=c.sname }).ToList();
            return View(data);
        }

        public ActionResult DeleteEmployee(int id =0)
        {
            var data = _db.tblEmployees.Find(id);
            _db.tblEmployees.Remove(data);
            _db.SaveChanges();
            return RedirectToAction("ShowEmployee");
        }

        public JsonResult StateGet(int A)
        {
            var data = _db.tblstates.Where(x=>x.cid==A).ToList();
            //var data = (from a in _db.tblstates where a.cid == A select a);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}