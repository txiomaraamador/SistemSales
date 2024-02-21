using Microsoft.AspNetCore.Mvc;

using SistemSales.Data;
using SistemSales.Models;

namespace SistemSales.Controllers
{

    public class SupplierController : Controller
    {
        SupplierData _supplierData = new SupplierData();

        public IActionResult ShowSuppliers()
        {
            //vist of companys
            var oList = _supplierData.ShowSuppliers();

            return View(oList);
        }
        public IActionResult CreateSupplier()
        {
            //only vist of html formulary
            return View();
        }
        [HttpPost]
        public IActionResult CreateSupplier(SupplierModel oSupplier)
        {
            if (!ModelState.IsValid)
                return View();
            //save object in the database
            var resp = _supplierData.CreateSupplier(oSupplier);

            if (resp)
                return RedirectToAction("ShowSuppliers");
            else
                return View();
        }
        public IActionResult EditSupplier(int IdSupplier)
        {
            var oSupplier = _supplierData.GetSupplier(IdSupplier);
            //only vist of html formulary
            return View(oSupplier);
        }
        [HttpPost]
        public IActionResult EditSupplier(SupplierModel oSupplier)
        {
            if (!ModelState.IsValid)
                return View();
            //save object in the database
            var resp = _supplierData.EditSupplier(oSupplier);

            if (resp)
                return RedirectToAction("ShowSuppliers");
            else
                return View();
        }
        public IActionResult DeleteSupplier(int IdSupplier)
        {
            var oSupplier = _supplierData.GetSupplier(IdSupplier);
            //only vist of html formulary
            return View(oSupplier);
        }
        [HttpPost]
        public IActionResult DeleteSupplier(SupplierModel oSupplier)
        {
            //save object in the database
            var resp = _supplierData.DeleteSupplier(oSupplier.IdSupplier);

            if (resp)
                return RedirectToAction("ShowSuppliers");
            else
                return View();
        }

    }
}

