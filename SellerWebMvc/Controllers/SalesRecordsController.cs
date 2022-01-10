using Microsoft.AspNetCore.Mvc;
using SellerWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleWebMvc.Controllers
{
    public class SalesRecordsController : Controller
    {

        private readonly SalesRecordService _service; 

        public SalesRecordsController(SalesRecordService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {   
            if(!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1,1);
            }
            if(!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var list = await _service.SimpleSearch(minDate, maxDate);
            return View(list);
        }

        public IActionResult GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            return View();
        }
    }
}
