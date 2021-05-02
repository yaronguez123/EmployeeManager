using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    [Table("Employees")]
    public class Employees
    {
        [Column("EmployeeID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="Employee ID")]
        [Required(ErrorMessage = "Employee ID is required") ]
        public int EmployeeID { get; set; }

        [Column("FirstName")]
        [Display(Name ="First Name")]
        [StringLength(20,ErrorMessage =("First name must be less then 20 charecters"))]
        [Required(ErrorMessage =("Employee first name is requierd"))]
        
        public string FirstName { get; set; }

        [Column("LastName")]
        [Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage = ("Last name must be less then 30 charecters"))]
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }


        [Column("Title")]
        [Display(Name = "Title")]
        [StringLength(30, ErrorMessage = ("Title must be less then 30 charecters"))]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Column("BirthDate")]
        [Display(Name = "Birth Date")]
        
        [Required(ErrorMessage = "Birth date is required")]
        
        public DateTime BirthDate { get; set; }

        [Column("HireDate")]
        [Display(Name = "Hire Date")]
        [Required(ErrorMessage = "Hire date is required")]
        public DateTime HireDate { get; set; }


        [Column("Country")]
        [Display(Name = "Country")]
        [StringLength(30, ErrorMessage = ("Country must be less then 30 charecters"))]
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }

        [Column("Notes")]
        [Display(Name = "Notes")]
        [StringLength(500, ErrorMessage = ("Notes name must be less then 500 charecters"))]
        public string Notes { get; set; }

    }
}
