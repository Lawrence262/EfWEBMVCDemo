using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EfWEBMVCDemo.Models;
using Newtonsoft.Json;

namespace EfWEBMVCDemo.Controllers
{
    public class SuppliersController : Controller
    {
        // GET: Suppliers
        public ActionResult Index()
        {
            IEnumerable<ModelSupplier> supdata = null;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = "https://localhost:44344/api/";

                var json = webClient.DownloadString("Suppliers");
                var list = JsonConvert.DeserializeObject<List<ModelSupplier>>(json);
                supdata = list.ToList();
                return View(supdata);
            }
        }

        // GET: Suppliers/Details/5
        public ActionResult Details(int id)
        {
            ModelSupplier supdata;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = "https://localhost:44344/api/";

                var json = webClient.DownloadString("Suppliers/" + id);
                //  var list = emp 
                supdata = JsonConvert.DeserializeObject<ModelSupplier>(json);
            }
            return View(supdata);
        }

        // GET: Suppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        [HttpPost]
        public ActionResult Create(ModelSupplier model)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = "https://localhost:44344/api/";
                    var url = "Suppliers/POST";
                    //webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string data = JsonConvert.SerializeObject(model);
                    var response = webClient.UploadString(url, data);
                    JsonConvert.DeserializeObject<ModelSupplier>(response);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        // GET: Suppliers/Edit/5
        public ActionResult Edit(int id)
        {
            ModelSupplier supdata;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = "https://localhost:44344/api/";

                var json = webClient.DownloadString("Suppliers/" + id);
                //  var list = emp 
                supdata = JsonConvert.DeserializeObject<ModelSupplier>(json);
            }
            return View(supdata);
        }

        // POST: Suppliers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ModelSupplier model)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = "https://localhost:44344/api/Suppliers/" + id;
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string data = JsonConvert.SerializeObject(model);

                    var response = webClient.UploadString(webClient.BaseAddress, "PUT", data);
                    ModelSupplier modeldata = JsonConvert.DeserializeObject<ModelSupplier>(response);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        // GET: Suppliers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Suppliers/Delete/5
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
