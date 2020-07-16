using System.Linq;
using System.Web.Mvc;
using AssetManagement.Models;

namespace AssetManagement.Controllers
{
    public class employeeDetailsController : Controller
    {
        private assetManagementEntities entities = new assetManagementEntities();

        public employeeDetailsController()
        {
            var assetTypeList = entities.asset_type.ToList();
            SelectList list = new SelectList(assetTypeList, "type_id", "type");
            ViewBag.assetType_List = list;
        }

        // GET: employeeDetails
        public ActionResult viewEmployeeList()
        {
            return View();
        }

        // GET: employeeDetails/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: employeeDetails/Create
        public ActionResult addNewEmployee()
        {
            return View();
        }

        // POST: employeeDetails/addNewEmployee
        [HttpPost]
        public ActionResult addNewEmployee(multiTable collection)
        {
            try
            {
                entities.employees.Add(collection.employee);
                entities.SaveChanges();

                return RedirectToAction("viewEmployeeList");
            }
            catch
            {
                return View();
            }
        }

        // GET: employeeDetails/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: employeeDetails/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: employeeDetails/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: employeeDetails/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
