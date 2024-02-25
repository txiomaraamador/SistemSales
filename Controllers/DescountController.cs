using Microsoft.AspNetCore.Mvc;
using SistemSales.Data;
using SistemSales.Models;

namespace SistemSales.Controllers
{
    public class DescountController : Controller
    {
        DescountData _DescountData = new DescountData();

            public IActionResult ShowDescounts()
            {
                //vist of companys
                var oList = _DescountData.ShowDescounts();

                return View(oList);
            }
            public IActionResult CreateDescount()
            {
                //only vist of html formulary
                return View();
            }
            [HttpPost]
            public IActionResult CreateDescount(DescountModel oDescount)
            {
                if (!ModelState.IsValid)
                    return View();
                //save object in the database
                var resp = _DescountData.CreateDescount(oDescount);

                if (resp)
                    return RedirectToAction("ShowDescounts");
                else
                    return View();
            }
            public IActionResult EditDescount(int IdDescount)
            {
                var oSupplier = _DescountData.GetDescount(IdDescount);
                //only vist of html formulary
                return View(oSupplier);
            }
            [HttpPost]
            public IActionResult EditDescount(DescountModel oDescount)
            {
                if (!ModelState.IsValid)
                    return View();
                //save object in the database
                var resp = _DescountData.EditDescount(oDescount);

                if (resp)
                    return RedirectToAction("ShowDescounts");
                else
                    return View();
            }
            [HttpPost]
            public IActionResult DeleteDescount(int IdDescount)
                {
                var resp = _DescountData.DeleteDescount(IdDescount);

                if (resp)
                    return Ok(); // Si la eliminación es exitosa, devuelve una respuesta 200 OK
                else
                    return BadRequest(); // Si hay algún error, devuelve una respuesta 400 Bad Request
            }
            
         
        }
}
