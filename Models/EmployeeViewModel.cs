﻿//using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using System.ComponentModel.DataAnnotations.Schema;

using System.ComponentModel;

namespace WebApplication3.Models
{
    public class EmployeeViewModel
    {
        public string CountText = "The Employee Count";

        public Guid Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("E-Mail")]
        public string Email { get; set; }
        [DisplayName("Salary")]
        public double Salary { get; set; }
        [DisplayName("Name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public string StatusID { get; set; }

        public List<EmployeeViewModelList> lstEmployees { get; set; }


    }

    public class EmployeeViewModelList
    {
        public Guid Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("E-Mail")]
        public string Email { get; set; }
        [DisplayName("Salary")]
        public double Salary { get; set; }
        [DisplayName("Name")]
        public string FullName {get; set; }

        public string StatusID { get; set; }

    }

}