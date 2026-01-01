using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SiteYonetim.Business.Abstract;
using SiteYonetim.Entity.Concrete;
using SiteYonetim.WebUI.Models;
using ClosedXML.Excel;


namespace SiteYonetim.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DuesController : Controller
    {
        private readonly IDuesService _duesService;
        private readonly IApartmentService _apartmentService;

        public DuesController(IDuesService duesService, IApartmentService apartmentService)
        {
            _duesService = duesService;
            _apartmentService = apartmentService;
        }

        public IActionResult Index()
        {
            var values = _duesService.TGetListWithApartment();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddDues()
        {
            List<SelectListItem> apartmentList = (from x in _apartmentService.TGetApartmentListWithBlock()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Block.Name + " - " + x.ApartmentNumber,
                                                      Value = x.Id.ToString()
                                                  }).ToList();

            var model = new AddDuesViewModel
            {
                ApartmentList = apartmentList
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddDues(Dues dues)
        {
            dues.IsPaid = false;
            _duesService.TInsert(dues);
            return RedirectToAction("Index");
        }
        public IActionResult Payment(int id)
        {
            var dues = _duesService.TGetByID(id);
            dues.IsPaid = true;
            _duesService.TUpdate(dues);
            return RedirectToAction("Index");
        }
        public IActionResult ExportExcel()
        {

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Dues");
                worksheet.Cell(1, 1).Value = "Daire";
                worksheet.Cell(1, 2).Value = "Oturan(Kullanıcı)";
                worksheet.Cell(1, 3).Value = "Dönem (Ay/Yıl)";
                worksheet.Cell(1, 4).Value = "Tutar";
                worksheet.Cell(1, 5).Value = "Durum";

                var values = _duesService.TGetListWithApartment();
                int RowCount = 2;
                foreach (var dues in values)
                {
                    worksheet.Cell(RowCount, 1).Value = dues.Apartment.Block.Name + " - " + dues.Apartment.ApartmentNumber;
                    worksheet.Cell(RowCount, 2).Value = dues.Apartment.User != null ? dues.Apartment.User.Name + " " + dues.Apartment.User.Surname : "Boş";
                    worksheet.Cell(RowCount, 3).Value = dues.Month + "/" + dues.Year;
                    worksheet.Cell(RowCount, 4).Value = dues.Amount;
                    worksheet.Cell(RowCount, 5).Value = dues.IsPaid ? "Ödendi" : "Ödenmedi";
                    RowCount++;
                }


                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Aidat_Listesi{DateTime.Now.ToShortDateString()}.xlsx");
                }
            }
        }
    }
}