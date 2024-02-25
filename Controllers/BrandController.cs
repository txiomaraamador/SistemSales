using Microsoft.AspNetCore.Mvc;
using SistemSales.Data;
using SistemSales.Models;

namespace SistemSales.Controllers
{
    public class BrandController : Controller
    {
        BrandData _BrandData = new BrandData();

        public IActionResult ShowBrands()
        {
            //vist of companys
            var oList = _BrandData.ShowBrands();

            return View(oList);
        }
        public IActionResult CreateBrand()
        {
            //only vist of html formulary
            return View();
        }
        [HttpPost]
        public IActionResult CreateBrand(BrandModel oBrand)
        {
            if (!ModelState.IsValid)
                return View();
            //save object in the database
            var resp = _BrandData.CreateBrand(oBrand);

            if (resp)
                return RedirectToAction("ShowBrands");
            else
                return View();
        }
        public IActionResult EditBrand(int IdBrand)
        {
            var oBrand = _BrandData.GetBrand(IdBrand);
            //only vist of html formulary
            return View(oBrand);
        }
        [HttpPost]
        public IActionResult EditBrand(BrandModel oBrand)
        {
            if (!ModelState.IsValid)
                return View();
            //save object in the database
            var resp = _BrandData.EditBrand(oBrand);

            if (resp)
                return RedirectToAction("ShowBrands");
            else
                return View();
        }
        [HttpPost]
        public IActionResult DeleteBrand(int IdBrand)
        {
            var resp = _BrandData.DeleteBrand(IdBrand);

            if (resp)
                return Ok(); // Si la eliminación es exitosa, devuelve una respuesta 200 OK
            else
                return BadRequest(); // Si hay algún error, devuelve una respuesta 400 Bad Request
        }
    }
}
