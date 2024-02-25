using Microsoft.AspNetCore.Mvc;
using SistemSales.Data;
using SistemSales.Models;

namespace SistemSales.Controllers
{
    public class CategoryController: Controller
    {
        CategoryData _categoryData = new CategoryData();

        public IActionResult ShowCategorys()
        {
            //vist of companys
            var oList = _categoryData.ShowCategorys();

            return View(oList);
        }
        public IActionResult CreateCategory()
        {
            //only vist of html formulary
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(CategoryModel oCategory)
        {
            if (!ModelState.IsValid)
                return View();
            //save object in the database
            var resp = _categoryData.CreateCategory(oCategory);

            if (resp)
                return RedirectToAction("ShowCategorys");
            else
                return View();
        }
        public IActionResult EditCategory(int IdCategory)
        {
            var oCategory = _categoryData.GetCategory(IdCategory);
            //only vist of html formulary
            return View(oCategory);
        }
        [HttpPost]
        public IActionResult EditCategory(CategoryModel oCategory)
        {
            if (!ModelState.IsValid)
                return View();
            //save object in the database
            var resp = _categoryData.EditCategory(oCategory);

            if (resp)
                return RedirectToAction("ShowCategorys");
            else
                return View();
        }
        [HttpPost]
        public IActionResult DeleteCategory(int IdCategory)
        {
            var resp = _categoryData.DeleteCategory(IdCategory);

            if (resp)
                return Ok(); // Si la eliminación es exitosa, devuelve una respuesta 200 OK
            else
                return BadRequest(); // Si hay algún error, devuelve una respuesta 400 Bad Request
        }

    }
}
