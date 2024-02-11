using Microsoft.AspNetCore.Mvc;

using SistemSales.Data;
using SistemSales.Models;

namespace SistemSales.Controllers
{
    public class CompanyController : Controller
    {
        CompanyData _companyData = new CompanyData();

        public IActionResult ShowCompanys()
        {
            //vist of companys
            var oList = _companyData.ShowCompanys();

            return View(oList);
        }
        public IActionResult CreateCompany()
        {
            //only vist of html formulary
            return View();
        }
        [HttpPost]
        public IActionResult CreateCompany(CompanyModel oCompany)
        {
            //save object in the database
            var resp = _companyData.CreateCompany(oCompany);

            if (resp)
                return RedirectToAction("ShowCompanys");
            else
                return View();
        }
    }
}
