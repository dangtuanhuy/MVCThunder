using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Thunder.Models;

namespace Thunder.Controllers
{
    public class ImgProductsController : Controller
    {
        private ShoppingCartEntities db = new ShoppingCartEntities();

        // GET: ImgProducts
        public ActionResult Index()
        {
            var imgProducts = db.ImgProducts.Include(i => i.Product);
            return View(imgProducts.ToList());
        }

        // GET: ImgProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImgProduct imgProduct = db.ImgProducts.Find(id);
            if (imgProduct == null)
            {
                return HttpNotFound();
            }
            return View(imgProduct);
        }

        // GET: ImgProducts/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProduceCode");
            return View();
        }

        // POST: ImgProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ImgId,ImgProduct1,ProductId")] ImgProduct imgProduct)
        {
            if (ModelState.IsValid)
            {
                db.ImgProducts.Add(imgProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProduceCode", imgProduct.ProductId);
            return View(imgProduct);
        }

        // GET: ImgProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImgProduct imgProduct = db.ImgProducts.Find(id);
            if (imgProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProduceCode", imgProduct.ProductId);
            return View(imgProduct);
        }

        // POST: ImgProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImgId,ImgProduct1,ProductId")] ImgProduct imgProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imgProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProduceCode", imgProduct.ProductId);
            return View(imgProduct);
        }

        // GET: ImgProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImgProduct imgProduct = db.ImgProducts.Find(id);
            if (imgProduct == null)
            {
                return HttpNotFound();
            }
            return View(imgProduct);
        }

        // POST: ImgProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImgProduct imgProduct = db.ImgProducts.Find(id);
            db.ImgProducts.Remove(imgProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
