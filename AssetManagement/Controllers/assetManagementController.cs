

namespace AssetManagement.Controllers
{
    using AssetManagement.Models;
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
        }
        public ActionResult viewAllAssets ()
        {
            return View();
        }

        // GET: assetManagement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult assignAsset(int id)
        {
            return View();
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
                       
                        //entities.SaveChanges();
                        Session["documentAdded"] = "Yes";
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: assetManagement/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: assetManagement/Edit/5
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

        // GET: assetManagement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: assetManagement/Delete/5
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
