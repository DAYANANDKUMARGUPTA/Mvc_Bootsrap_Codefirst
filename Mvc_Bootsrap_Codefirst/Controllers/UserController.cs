using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Mvc_Bootsrap_Codefirst.Models;

namespace Mvc_Bootsrap_Codefirst.Controllers
{
    public class UserController : Controller
    {
        DatabaseContext _db = new DatabaseContext();

        public ActionResult Adduser(int id = 0)
        {
            ViewBag.ctr = _db.tblcountries.ToList();
            tbluser obj = new tbluser();
            ViewBag.BT = "Create";
            if (id > 0)
            {
                var data =(from a in _db.tblusers where a.uid==id select a).ToList();
                obj.uid = data[0].uid;
                obj.name = data[0].name;
                obj.age = data[0].age;
                obj.salary = data[0].salary;
                obj.country = data[0].country;
                obj.state = data[0].state;
                ViewBag.BT = "Update";
            }
            ViewBag.stt= (from a in _db.tblstates where a.cid == obj.country select a).ToList();
            return View(obj);
        }


        [HttpPost]
        public ActionResult Adduser(tbluser _usr)
        {
            if (_usr.uid > 0)
            {
                _db.Entry(_usr).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                _db.tblusers.Add(_usr);
            }
            
            _db.SaveChanges();
            return RedirectToAction("Showuser");
        }

        public ActionResult Deleteuser(int id=0)
        {
           var data= _db.tblusers.Find(id);
            _db.tblusers.Remove(data);
            _db.SaveChanges();
            return RedirectToAction("Showuser");
        }

        public ActionResult Showuser()
        {
            var data = (from a in _db.tblusers 
                        join b in _db.tblcountries on a.country equals b.cid
                        join c in _db.tblstates on a.state equals c.sid
                        select new tbluser1 {uid=a.uid,name=a.name,age=a.age,salary=a.salary,country=b.cname,state=c.sname }).ToList();
            return View(data);
        }

        public JsonResult Stateget(int A)
        {
            var data = (from a in _db.tblstates where a.cid==A select a ).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}