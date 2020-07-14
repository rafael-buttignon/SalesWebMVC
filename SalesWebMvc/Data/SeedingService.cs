using Microsoft.EntityFrameworkCore.Internal;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;
using System;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Department.Any() 
                || _context.Seller.Any() 
                || _context.SalesRecord.Any())
            {
                return; // O banco de dados já foi populado
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(4, "Fashion");
            Department d4 = new Department(5, "Books");

            Seller s1 = new Seller(1, "Bob Brown", "Bob@gmail.com", new System.DateTime(1998, 4, 21), 1500.0, d1);
            Seller s2 = new Seller(2, "Raphael Cost", "CostRapha@gmail.com", new System.DateTime(1988, 2, 22), 4000.0, d2);
            Seller s3 = new Seller(3, "Martha Grey", "MarthaGrey@gmail.com", new System.DateTime(1966, 1, 20), 3000.0, d2);
            Seller s4 = new Seller(4, "Joaquin Rusb", "JoaquinRube@gmail.com", new System.DateTime(1999, 8, 6), 1399.0, d1);
            Seller s5 = new Seller(5, "Rosangela Pink", "RosangelaPink@gmail.com", new System.DateTime(1989, 11, 15), 1799.0, d3);
            Seller s6 = new Seller(6, "Donald Trump", "Trump@gmail.com", new System.DateTime(1955, 12, 26), 70000.0, d4);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2018, 09, 25), 11000.0, SaleStatus.Pending, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2019, 06, 28), 1000.0, SaleStatus.Canceled, s2);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2019, 03, 20), 1800.0, SaleStatus.Billled, s3);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2018, 04, 22), 10000.0, SaleStatus.Billled, s4);
            SalesRecord r5 = new SalesRecord(5, new DateTime(2018, 05, 24), 16000.0, SaleStatus.Pending, s5);
            SalesRecord r6 = new SalesRecord(6, new DateTime(2019, 03, 25), 20000.0, SaleStatus.Billled, s6);
            SalesRecord r7 = new SalesRecord(7, new DateTime(2017, 05, 05), 6000.0, SaleStatus.Canceled, s1);
            SalesRecord r8 = new SalesRecord(8, new DateTime(2020, 04, 07), 4000.0, SaleStatus.Billled, s2);
            SalesRecord r9 = new SalesRecord(9, new DateTime(2020, 01, 08), 8000.0, SaleStatus.Billled, s3);
            SalesRecord r10 = new SalesRecord(10, new DateTime(2019, 08, 19), 4000.0, SaleStatus.Pending, s4);
            SalesRecord r11 = new SalesRecord(11, new DateTime(2019, 07, 17), 100.0, SaleStatus.Billled, s5);
            SalesRecord r12 = new SalesRecord(12, new DateTime(2019, 03, 16), 11000.0, SaleStatus.Billled, s6);
            SalesRecord r13 = new SalesRecord(13, new DateTime(2018, 07, 11), 13000.0, SaleStatus.Pending, s1);
            SalesRecord r14 = new SalesRecord(14, new DateTime(2020, 05, 21), 10500.0, SaleStatus.Canceled, s2);
            SalesRecord r15 = new SalesRecord(15, new DateTime(2020, 06, 20), 500.0, SaleStatus.Billled, s3);
            SalesRecord r16 = new SalesRecord(16, new DateTime(2020, 06, 21), 800.0, SaleStatus.Billled, s6);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);
            _context.SalesRecord.AddRange(r1, r2, r3, r4, r5, r6, r7,
                r8, r9, r10, r11, r12, r13, r14, r15, r16);

            _context.SaveChanges();

        }
    }
}
