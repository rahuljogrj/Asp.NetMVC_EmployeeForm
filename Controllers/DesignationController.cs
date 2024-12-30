using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using WebApplication3.modules;
using WebApplication3.modules.EmployeeEntity;

namespace WebApplication3.Controllers
{
    public class DesignationController : Controller
    {

        private readonly dbContext _db;

        EmployeeViewModel _objModel;

        public DesignationController(dbContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create(Guid DesignationId)
        {

            var desig = _db.MasterData.SingleOrDefault(x => x.MasterID == DesignationId);
            if (desig != null)
            {
                DesignationModel employeeDetails = GetEditDetails(DesignationId);
                return View(employeeDetails);
            }
            return View();

        }

        public DesignationModel GetEditDetails(Guid DesignationId)
        {
            DesignationModel desigView = new DesignationModel();

            try
            {
                MasterData desigData = _db.MasterData.SingleOrDefault(x => x.MasterID == DesignationId);
                if (desigData != null)
                {

                    desigView.Id = desigData.MasterID;
                    desigView.Code = desigData.Code;
                    desigView.Name = desigData.Name;
                    desigView.Status = desigData.Status;

                    return desigView;
                }
                else
                {
                    TempData["errorMessage"] = $"Employee details not available with the Id: {DesignationId}";
                    return desigView;
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return desigView;
            }
        }

        public ActionResult SaveData(DesignationModel mdlDesignation)
        {
            try
            {
                MasterData masterData1 = _db.MasterData.Where(x => x.MasterID == mdlDesignation.Id).SingleOrDefault();

                if(masterData1 == null)
                {

                    MasterData masterData = new MasterData();
                    masterData.MasterID = Guid.NewGuid();
                    masterData.Creationdate = DateTime.Now;
                    masterData.LastModificationDate = null;
                    masterData.Code = mdlDesignation.Code;
                    masterData.Name = mdlDesignation.Name;
                    masterData.MasterType = "Designation";
                    masterData.Status = "A";

                    _db.Entry(masterData).State = EntityState.Added;
                    _db.SaveChanges();

                    TempData["successMessage"] = "Designation Created successfully.....";
                    return Json(new { message = TempData["successMessage"] });

                }
                else
                { 
                    masterData1.LastModificationDate = DateTime.Now;
                    masterData1.Code = mdlDesignation.Code;
                    masterData1.Name = mdlDesignation.Name;
                    masterData1.MasterType = "Designation";
                    masterData1.Status = "A";

                    _db.Entry(masterData1).State = EntityState.Modified;
                    _db.SaveChanges();



                    TempData["successMessage"] = "Designation Updated successfully.....";
                    return Json(new { message = TempData["successMessage"] });
                }
 
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return Json(new { message = TempData["errorMessage"] });
            }

        }

        public List<DesignationListModel> GetAllDesignation()
        {
            List<DesignationListModel> lstDesig = new List<DesignationListModel>();

            lstDesig = (from dbDesig in _db.MasterData
                        select new DesignationListModel
                        {
                            Id = dbDesig.MasterID,
                            Name = dbDesig.Name,
                            Code = dbDesig.Code,
                            MasterType = dbDesig.MasterType,
                            Status = dbDesig.Status
                        }).ToList();

            return lstDesig;
        }

        public ActionResult Delete(string DesignationId)
        {
            Guid GuidDesignationId = Guid.Parse(DesignationId);

            try
            {
                MasterData _deletedata = _db.MasterData.Where(x => x.MasterID == GuidDesignationId).FirstOrDefault();

                var _checkdeletedata = (from dbcheckDesig in _db.MasterData
                                          join dbEmployee in _db.Employee on dbcheckDesig.MasterID equals dbEmployee.DesignationID
                                          where dbEmployee.StatusID=="A" && dbcheckDesig.MasterID == GuidDesignationId
                                        select dbcheckDesig).ToList();

                if (_checkdeletedata.Count() == 0)
                {
                    if (_deletedata != null)
                    {
                        _deletedata.Status = "D";
                        _db.Entry(_deletedata).State = EntityState.Modified;
                        _db.SaveChanges();
                    }

                    TempData["successMessage"] = "Designation Deleted successfully.....";
                    return Json(new { message = TempData["successMessage"] });
                }
                else
                {
                    TempData["successMessage"] = "Designation Can't be Delete, it's Already assign to Active Employee.....";
                    return Json(new { message = TempData["successMessage"] });
                }

              
            }
            catch (Exception ex)
            {
                TempData["successMessage"] = ex.Message;
                return Json(new { message = TempData["successMessage"] });
            }

        }

        public ActionResult ActivateDesignation(string DesignationId)
        {
            Guid GuidDesignationId = Guid.Parse(DesignationId);

            try
            {
                MasterData _deletedata = _db.MasterData.Where(x => x.MasterID == GuidDesignationId).FirstOrDefault();
                if (_deletedata != null)
                {
                    _deletedata.Status = "A";
                    _db.Entry(_deletedata).State = EntityState.Modified;
                    _db.SaveChanges();
                }

                TempData["successMessage"] = "Designation Activated successfully.....";
                return Json(new { message = TempData["successMessage"] });
            }
            catch (Exception ex)
            {
                TempData["successMessage"] = ex.Message;
                return Json(new { message = TempData["successMessage"] });
            }

        }

    }
}
