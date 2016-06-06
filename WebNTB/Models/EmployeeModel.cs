using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebNTB.Models
{
    public class EmployeeModel
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public int Salary { set; get; }
        public bool Status { set; get; }
    }
}