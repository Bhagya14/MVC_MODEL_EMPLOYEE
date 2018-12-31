using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Model_Employee.Models;

namespace MVC_Model_Employee.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                EmployeeDAL dal = new EmployeeDAL();
                bool status = dal.Login(model);
                if (status == true)
                {
                    Session["loginid"] = model.loginid;
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    ViewBag.msg = "Invalid User ID or Password";
                    ModelState.Clear();
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult Index()
        {
            int loginid = Convert.ToInt32(Session["loginid"]);
            ViewBag.loginid = loginid;
            return View();
        }
        public ActionResult NewEmployee()
        {
            EmployeeDAL dal = new EmployeeDAL();
            ViewBag.cities = dal.Getcities();
            return View();
        }
        [HttpPost]
        public ActionResult NewEmployee(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                model.employeeimageaddress = "/Images/" + Guid.NewGuid() + ".jpg";
                model.employeeimagefile.SaveAs(Server.MapPath(model.employeeimageaddress));

                EmployeeDAL dal = new EmployeeDAL();
                int id = dal.AddEmploee(model);
                ViewBag.msg = "Employee Added: " + id;
                ModelState.Clear();
                ViewBag.cities = dal.Getcities();
                return View();
            }
            else
            {
                EmployeeDAL dal = new EmployeeDAL();
                ViewBag.cities = dal.Getcities();
                return View();
            }
        }

        public ActionResult search()
        {
            List<EmployeeProjectionModel> list = new List<EmployeeProjectionModel>();
            return View(list);
        }

        [HttpPost]
        public ActionResult search(string key)
        {
            EmployeeDAL dal = new EmployeeDAL();
            List<EmployeeProjectionModel> list = dal.Search(key);
            return View(list);
        }
        public ActionResult Find(int id)
        {
            EmployeeDAL dal = new EmployeeDAL();
            EmployeeModel model = dal.Find(id);
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            EmployeeDAL dal = new EmployeeDAL();
            bool status = dal.Delete(id);
            return View();
        }

        public ActionResult Edit(int id)
        {
            EmployeeDAL dal = new EmployeeDAL();
            EmployeeModel model = dal.Find(id);
            return View(model);
        }
        [HttpPost]

        public ActionResult Edit(EmployeeModel model)
        {
            EmployeeDAL dal = new EmployeeDAL();
            dal.Update(model.employeeid, model.password, model.employeeemail);
            return View("view_updated");
        }

    }
}
