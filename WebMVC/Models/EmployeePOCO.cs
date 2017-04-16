using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class EmployeePOCO
    {   public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime StartDate { get; set; }
        public double HoulyRate { get; set; }
        public int Salary { get; set; }
        public int Type { get; set; }
        
    }
}