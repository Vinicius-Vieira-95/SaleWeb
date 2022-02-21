using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaleWebMvc.Models
{
    public class Seller
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage ="{0} requiered")]
        [StringLength(60, MinimumLength = 3, ErrorMessage ="{0} size should be between {2} and {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} requiered")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} requiered")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")] //formato padrão BR
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} requiered")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> sales { get; set; } = new List<SalesRecord>();



        public Seller() { }

        public Seller(string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSale(SalesRecord sr)
        {
            sales.Add(sr);

        }

        public void RemoveSale(SalesRecord sr)
        {
            sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return sales.Where(s => s.Date >= initial && s.Date <= final).Sum(s => s.Amount);
        }
    }
}
