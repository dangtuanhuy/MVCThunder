using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Thunder.Models;

namespace Thunder.Controllers
{
    public class SupplierController : Controller
    {
        //Khai báo đối tượng Entity
        private ShoppingCartEntities DB;
       //Hàm khởi tạo Entity
        public SupplierController()
        {
            DB = new ShoppingCartEntities ();
        }
        public ActionResult Index()
        {
            
            return View();
        }
        //Khi dùng ajax để gọi thì Trang Index sẽ hiển thị đầu tiên (Ajax gồm get, set các đối tượng)
        public ActionResult GetSupplier()
        {
            //Lấy ra danh sách các nhà cung cấp
            var Supplier = DB.Suppliers.ToList();
            //Trả về đối tượng Json với phương thức get
            return Json(Supplier, JsonRequestBehavior.AllowGet);

        }
        //Trả về đúng các tham số đã truyền vào 
        public ActionResult GetSupplierId(int Id)
        {
            var Supplier = DB.Suppliers.ToList().Find(m => m.SupplierId == Id);
            return Json(Supplier, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Create([Bind(Exclude = "SupplierId")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                DB.Suppliers.Add(supplier);
                DB.SaveChanges();
            }

            return Json(supplier, JsonRequestBehavior.AllowGet);
        }
        // Chỉnh sửa thông tin của một record
        [HttpPost]
        public ActionResult Update(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(supplier).State = EntityState.Modified;
                DB.SaveChanges();
            }

            return Json(supplier, JsonRequestBehavior.AllowGet);
        }


        // Xóa record tương ứng với tham số id đã truyền vào
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var supplier = DB.Suppliers.ToList().Find(m => m.SupplierId == id);

            if (supplier != null)
            {
                DB.Suppliers.Remove(supplier);
                DB.SaveChanges();
            }

            return Json(supplier, JsonRequestBehavior.AllowGet);
        }

    }
}
