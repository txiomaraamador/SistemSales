using Microsoft.AspNetCore.Mvc;
using SistemSales.Data;
using SistemSales.Models;

namespace SistemSales.Controllers
{
    public class SizeController : Controller
    {
        SizeData _SizeData = new SizeData();

        public IActionResult ShowSizes()
        {
            //vist of companys
            var oList = _SizeData.ShowSizes();

            return View(oList);
        }
        public IActionResult CreateSize()
        {
            //only vist of html formulary
            return View();
        }
        [HttpPost]
        public IActionResult CreateSize(SizeModel oSize)
        {
            if (!ModelState.IsValid)
                return View();
            //save object in the database
            var resp = _SizeData.CreateSize(oSize);

            if (resp)
                return RedirectToAction("ShowSizes");
            else
                return View();
        }
        public IActionResult EditSize(int IdSize)
        {
            var oCategory = _SizeData.GetSize(IdSize);
            //only vist of html formulary
            return View(oCategory);
        }
        [HttpPost]
        public IActionResult EditSize(SizeModel oSize)
        {
            if (!ModelState.IsValid)
                return View();
            //save object in the database
            var resp = _SizeData.EditSize(oSize);

            if (resp)
                return RedirectToAction("ShowSizes");
            else
                return View();
        }
        [HttpPost]
        public IActionResult DeleteSize(int IdSize)
        {
            var resp = _SizeData.DeleteSize(IdSize);

            if (resp)
                return Ok(); // Si la eliminación es exitosa, devuelve una respuesta 200 OK
            else
                return BadRequest(); // Si hay algún error, devuelve una respuesta 400 Bad Request
        }
    }
}
