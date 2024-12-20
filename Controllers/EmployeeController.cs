﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using System.Text.RegularExpressions;
using WebApplication3.Models;
using WebApplication3.modules;
using WebApplication3.modules.EmployeeEntity;

namespace WebApplication3.Controllers
{
    public class EmployeeController : CommonController
    {

        private readonly dbContext _db;

        EmployeeViewModel _objModel;

        public EmployeeController(dbContext context)
        {
            _db = context;
        }
 
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create(Guid empid)
        {

            var employee = _db.Employee.SingleOrDefault(x => x.Id == empid);
            if (employee != null)
            {
                EmployeeViewModel employeeDetails = GetEditDetails(empid);
                return View(employeeDetails);
            }
            return View();

        }

        public List<EmployeeViewModelList> GetActiveEmployee()
        {
            List<EmployeeViewModelList> EmployeeList = (from dbEmp in _db.Employee
                                                        where dbEmp.StatusID == "A"
                                                        orderby dbEmp.FirstName descending
                                                        select new EmployeeViewModelList
                                                        {
                                                            Id = dbEmp.Id,
                                                            FirstName = dbEmp.FirstName,
                                                            LastName = dbEmp.LastName,
                                                            DateOfBirth = ConvertToUserDate(dbEmp.DateOfBirth),
                                                            Email = dbEmp.Email,
                                                            Salary = dbEmp.Salary,
                                                            StatusID = dbEmp.StatusID,
                                                            FullName = dbEmp.FirstName + " " + dbEmp.LastName
                                                        }).ToList();

            return EmployeeList;
        }

        public List<EmployeeViewModelList> GetAllEmployee()
        {
            List<EmployeeViewModelList> EmployeeList = (from dbEmp in _db.Employee
                                                        orderby dbEmp.FirstName descending
                                                        select new EmployeeViewModelList
                                                        {
                                                            Id = dbEmp.Id,
                                                            FirstName = dbEmp.FirstName,
                                                            LastName = dbEmp.LastName,
                                                            DateOfBirth = ConvertToUserDate(dbEmp.DateOfBirth),
                                                            Email = dbEmp.Email,
                                                            Salary = dbEmp.Salary,
                                                            StatusID = dbEmp.StatusID,
                                                            FullName = dbEmp.FirstName + " " + dbEmp.LastName
                                                        }).ToList();

            return EmployeeList;
        }

        public EmployeeViewModel GetEditDetails(Guid empid)
        {
            EmployeeViewModel employeeView = new EmployeeViewModel();

            try
            {
                Employee employee = _db.Employee.SingleOrDefault(x => x.Id == empid);
                if (employee != null)
                {

                    employeeView.Id = employee.Id;
                    employeeView.FirstName = employee.FirstName;
                    employeeView.LastName = employee.LastName;
                    employeeView.DateOfBirth = ConvertToUserDate(employee.DateOfBirth);
                    employeeView.Email = employee.Email;
                    employeeView.Salary = employee.Salary;
                    employeeView.StatusID = employee.StatusID;


                    return employeeView;
                }
                else
                {
                    TempData["errorMessage"] = $"Employee details not available with the Id: {empid}";
                    return employeeView;
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return employeeView;
            }
        }
 
        public ActionResult SaveData(EmployeeViewModel employeedata)
        {
            try
            {
                Employee existdata = _db.Employee.Where(x => x.Id == employeedata.Id).SingleOrDefault();
                if (existdata != null)
                {

                    existdata.FirstName = employeedata.FirstName;
                    existdata.LastName = employeedata.LastName;
                    existdata.DateOfBirth = convertToDate(employeedata.DateOfBirth);
                    existdata.Email = employeedata.Email;
                    existdata.Salary = employeedata.Salary;
                    existdata.StatusID = "A";

                    _db.Employee.Update(existdata);
                    _db.SaveChanges();


                    TempData["successMessage"] = "Employee Updated successfully.....";
                    return Json(new { message = TempData["successMessage"] });


                }
                else
                {

                    Employee employee = new Employee();

                    employee.Id = Guid.NewGuid();
                    employee.FirstName = employeedata.FirstName;
                    employee.LastName = employeedata.LastName;
                    employee.DateOfBirth = convertToDate(employeedata.DateOfBirth);
                    employee.Email = employeedata.Email;
                    employee.Salary = employeedata.Salary;
                    employee.StatusID = "A";
                    employee.Creationdate = DateTime.Now;


                    _db.Employee.Add(employee);
                    _db.SaveChanges();

                    TempData["successMessage"] = "Employee Created successfully.....";
                    return Json(new { message = TempData["successMessage"] });

                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return Json(new { message = TempData["errorMessage"] });

            }

        }

        public ActionResult ActivateEmp(string empid)
        {
            Guid Guidempid = Guid.Parse(empid);
            try
            {
                Employee delEmployee = _db.Employee.Where(x => x.Id == Guidempid).SingleOrDefault();

                if (delEmployee == null)
                {
                    TempData["deleteMessage"] = $"Employee not available with Id: {delEmployee.FirstName}";
                    return Json(new { message = TempData["deleteMessage"] });
                }
                if (delEmployee.StatusID == "A")
                {
                    TempData["deleteMessage"] = $"Employee Already Active...";
                    return Json(new { message = TempData["deleteMessage"] });
                }

                delEmployee.StatusID = "A";
                _db.Employee.Update(delEmployee);
                _db.SaveChanges();
                TempData["deleteMessage"] = $"Employee Activated successfully...";
                return Json(new { message = TempData["deleteMessage"] });


            }
            catch (Exception ex)
            {
                TempData["deleteMessage"] = ex.Message;
                return Json(new { message = TempData["deleteMessage"] });
            }

        }

        public ActionResult Delete(string empid)
        {

            Guid Guidempid = Guid.Parse(empid);

            try
            {
                Employee delEmployee = _db.Employee.Where(x => x.Id == Guidempid).SingleOrDefault();

                if (delEmployee == null)
                {
                    TempData["deleteMessage"] = $"Employee not available with First Name: {delEmployee.FirstName}";
                    return RedirectToAction("Index");
                }

                delEmployee.StatusID = "D";
                _db.Employee.Update(delEmployee);
                _db.SaveChanges();
                TempData["deleteMessage"] = $"Employee deleted successfully...";
                //return RedirectToAction("Index");
                return Json(new { message = TempData["deleteMessage"] });



            }
            catch (Exception ex)
            {
                TempData["deleteMessage"] = ex.Message;
                //return RedirectToAction("Index");
                return Json(new { message = TempData["deleteMessage"] });

            }

        }

        public JsonResult GetCountRecord()
        {
            int count = _db.Employee.Count(x => x.StatusID == "A");
            return Json(new { success = true, count });
        }
    }
}
