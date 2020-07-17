

namespace AssetManagement.Controllers
{
    using AssetManagement.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class assetManagementController : Controller
    {
        private assetManagementEntities entities = new assetManagementEntities();

        public assetManagementController()
        {
            var assetTypeList = entities.asset_type.ToList();
            SelectList list = new SelectList(assetTypeList, "type_id", "type");
            ViewBag.assetType_List = list;

            var costTypeList = entities.cost_type.ToList();
            SelectList costlist = new SelectList(costTypeList, "type_id", "type");
            ViewBag.costType_List = costlist;

            var employeeList = entities.employees.ToList();
            SelectList employeList = new SelectList(employeeList, "employee_id", "email_id");
            ViewBag.employee_List = employeList;
        }

        public ActionResult Details(int id)
        {
            Session["detailsId"] = id;
            return View();
        }
        public ActionResult viewAllAssets()
        {
            return View();
        }

        public ActionResult assignAsset(int id)
        {
            Session["assetId"] = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult assignAsset(int id, multiTable collection)
        {
            try
            {
                var asset = entities.asset_details.Find(id);
                asset.employee_id = collection.assetDetails.employee_id;
                entities.Entry(asset).State = EntityState.Modified;
                entities.SaveChanges();
                return View();
            }
            catch
            {

                return View();
            }
        }


        public ActionResult addNewAsset()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult addNewAsset(multiTable collection, HttpPostedFileBase upload)
        {
            try
            {
                if (upload != null && upload.ContentLength > 0)
                {

                    if (collection.costDetails != null)
                    {
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            collection.costDetails.bill = reader.ReadBytes(upload.ContentLength);
                        }
                        entities.cost_details.Add(collection.costDetails);
                        collection.assetDetails.cost_id = collection.costDetails.cost_id;
                        entities.asset_details.Add(collection.assetDetails);
                        entities.SaveChanges();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var asset = entities.asset_details.Find(id);
            multiTable table = new multiTable();
            table.assetDetails = asset;
            return View(table);
        }

        [HttpPost]
        public ActionResult Edit(int id, multiTable collection, string Cancel, string Delete)
        {
            try
            {
                if (Cancel != null)
                {
                    return RedirectToAction("viewAllAssets");
                }
                else if (Delete != null)
                {
                    DeleteFunc(id);
                }
                else
                {
                    entities.Entry(collection.assetDetails).State = EntityState.Modified;
                    entities.SaveChanges();
                }
                return View();
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
                var asset = entities.asset_details.Find(id);
                entities.asset_details.Remove(asset);
                entities.Entry(asset).State = EntityState.Modified;
                entities.SaveChanges();
            }
            catch
            {
            }
        }
    }
}
