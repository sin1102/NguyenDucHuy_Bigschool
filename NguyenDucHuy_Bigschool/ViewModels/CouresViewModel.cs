using NguyenDucHuy_Bigschool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace NguyenDucHuy_Bigschool.ViewModels
{
    public class CouresViewModel
    {
        [Required]
        public String Place { get; set; }
        [Required]
        [FutureDate]
        public String Date { get; set; }
        [Required]
        [ValidTime]
        public String Time { get; set; }
        [Required]
        public byte Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public DateTime GetDateTime()
        {
            //return DateTime.Parse(string.Format(Date + " " + Time));
            return DateTime.ParseExact(Date + " " + Time, "dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture);
        }
        //trang 24
        public IEnumerable<Course> UpcommingCourses { get; set; }
        public bool ShowAction { get; set; }

    }
}