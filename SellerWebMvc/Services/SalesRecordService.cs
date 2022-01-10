
using System.Collections.Generic;
using System.Threading.Tasks;
using SaleWebMvc.Models;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace SellerWebMvc.Services
{
    public class SalesRecordService
    {
        private readonly SaleWebMvcContext _context;

        public SalesRecordService(SaleWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            var salesRecords = _context.SalesRecords.Where(x => x.Date >= minDate && x.Date <= maxDate);
           //var salesRecords = from obj in _context.SalesRecords select obj;
            // if(minDate.HasValue)
            // {
            //     salesRecords = salesRecords.Where(x => x.Date >= minDate.Value);
            // }
            // if(maxDate.HasValue)
            // {
            //     salesRecords = salesRecords.Where(x => x.Date >= maxDate.Value);
            // }
            return await salesRecords
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        // public async Task<<SalesRecord>> GroupBySearch(DateTime? minDate, DateTime? maxDate)
        // {
        //     var salesRecords = _context.SalesRecords.Where(x => x.Date >= minDate && x.Date <= maxDate);

        //     return await salesRecords
        //         .Include(x => x.Seller)
        //         .Include(x => x.Seller.Department)
        //         .GroupBy(x => x.Seller.Department);
        // }
    }
}