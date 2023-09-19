using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using code.id.Test_AXA.Models;
using code.id.Test_AXA.Utility;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using X.PagedList.Mvc.Core;
using X.PagedList;

namespace code.id.Test_AXA.Controllers
{
    public class MasterController : Controller
    {

        // GET: Master
        public async Task<IActionResult> Index(int? page)
        {
            //Data data = new Data();
            //data.body = "testBody";
            //data.name = "testName";
            //data.email = "testEmail";
            //data.id = 1;
            //data.postId = 1;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var dataList = await GetDataAsync();
            return View(dataList.ToPagedList(pageNumber,pageSize));
        }

        // GET: Master/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Master/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Master/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Master/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Master/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Master/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Master/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<List<Data>> GetDataAsync()
        {
            string jsonRes = string.Empty;
            HttpClient client = new HttpClient();
            var res = JsonConvert.DeserializeObject<List<Data>>(await client.GetStringAsync("https://jsonplaceholder.typicode.com/comments")).ToList();
            return res;
        }

    }
}