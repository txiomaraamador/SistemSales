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
            if(!ModelState.IsValid)
                return View();
            //save object in the database
            var resp = _companyData.CreateCompany(oCompany);

            if (resp)
                return RedirectToAction("ShowCompanys");
            else
                return View();
        }
        public IActionResult EditCompany(int IdCompany)
        {
            var oCompany = _companyData.GetCompany(IdCompany);
            //only vist of html formulary
            return View(oCompany);
        }
        [HttpPost]
        public IActionResult EditCompany(CompanyModel oCompany)
        {
            if (!ModelState.IsValid)
                return View();
            //save object in the database
            var resp = _companyData.EditCompany(oCompany);

            if (resp)
                return RedirectToAction("ShowCompanys");
            else
                return View();
        }
        public IActionResult DeleteCompany(int IdCompany)
        {
            var oCompany = _companyData.GetCompany(IdCompany);
            //only vist of html formulary
            return View(oCompany);
        }
        [HttpPost]
        public IActionResult DeleteCompany(CompanyModel oCompany)
        {
            //save object in the database
            var resp = _companyData.DeleteCompany(oCompany.IdCompany);

            if (resp)
                return RedirectToAction("ShowCompanys");
            else
                return View();
        }

    }
}
