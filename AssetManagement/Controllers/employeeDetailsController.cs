using System.Data.Entity;
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

        public ActionResult Edit(int id)
        {
            var employeeDetails = entities.employees.Find(id);
            multiTable table = new multiTable();
            table.employee = employeeDetails;
            return View(table);
        }

        [HttpPost]
        public ActionResult Edit(int id, multiTable collection,string Cancel, string Delete)
        {
            try
            {
                if (Cancel != null)
                {
                    return RedirectToAction("viewEmployeeList");
                }
                else if (Delete != null)
                {
                    DeleteFunc(id);
                }
                else
                {
                    entities.Entry(collection.employee).State = EntityState.Modified;
                    entities.SaveChanges();
                }
                return RedirectToAction("viewEmployeeList");
            }
            catch
            {
                return View();
            }
        }

        public void DeleteFunc(int id)
        {
            try
            {
                var employeeDetails = entities.employees.Find(id);
                entities.employees.Remove(employeeDetails);
                entities.Entry(employeeDetails).State = EntityState.Modified;
                entities.SaveChanges();
            }
            catch
            {
            }
        }
    }
}
