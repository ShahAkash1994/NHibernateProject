using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Cfg;
using NHibernateApplicationMVC.ViewModel;
using NHibernateApplicationMVC.Models;
using System.Windows.Forms;
namespace NHibernateApplicationMVC.Controllers
{
    public class EmployeeDetailsController : Controller
    {
        //
        // GET: /EmployeeDetails/
        [HttpGet]
        public ActionResult EmployeeDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EmployeeDetails(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                EmployeeDetails emp = new EmployeeDetails();
                using (ISession session = StartNHibernateSession.OpenSession())
                {
                    using (ITransaction tx = session.BeginTransaction())
                    {
                        emp.Name = employeeViewModel.Name;
                        emp.Address = employeeViewModel.Address;
                        emp.BirthDate = employeeViewModel.BirthDate;
                        emp.BloodGroup = employeeViewModel.BloodGroup;
                        emp.EmergencyNo = employeeViewModel.EmergencyNo;
                        emp.MobileNo = employeeViewModel.MobileNo;
                        emp.AddedOn = DateTime.Now;
                        emp.UpdatedOn = DateTime.Now;
                        emp.Isactive = true;
                        try
                        {
                            session.Save(emp);
                            tx.Commit();
                            return RedirectToAction("ViewEmployeeDetails", new {id=emp.Id});
                        }
                        catch (Exception e)
                        {
                            throw new Exception(e.ToString());
                        }
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult ViewEmployeeDetails(int id)
        {
            EmployeeViewModel employee = new EmployeeViewModel();
            using(ISession session=StartNHibernateSession.OpenSession())
            {
                var employees = session.Get<EmployeeDetails>(id);
                employee.Name = employees.Name.ToString();
                employee.Address = employees.Address.ToString();
                employee.BirthDate = Convert.ToDateTime(employees.BirthDate);
                employee.EmergencyNo = employees.EmergencyNo.ToString();
                employee.MobileNo= employees.MobileNo.ToString();
                employee.BloodGroup = employees.BloodGroup.ToString();
                employee.Id = (int)employees.Id;
            }
            return View(employee);
        }

        [HttpPost]
        public ActionResult ViewEmployeeDetails(EmployeeViewModel employeeViewModel, string Submit)
        {
            if (Submit == "Save")
            {
                if (ModelState.IsValid)
                {
                    EmployeeDetails emp = new EmployeeDetails();
                    using (ISession session = StartNHibernateSession.OpenSession())
                    {
                        using (ITransaction tx = session.BeginTransaction())
                        {
                            emp.Id = employeeViewModel.Id;
                            emp.Name = employeeViewModel.Name;
                            emp.Address = employeeViewModel.Address;
                            emp.BloodGroup = employeeViewModel.BloodGroup;
                            emp.EmergencyNo = employeeViewModel.EmergencyNo;
                            emp.MobileNo = employeeViewModel.MobileNo;
                            emp.AddedOn = DateTime.Now;
                            emp.UpdatedOn = DateTime.Now;
                            emp.BirthDate = employeeViewModel.BirthDate;
                            emp.Isactive = true;
                            try
                            {
                                session.Update(emp);
                                tx.Commit();
                                return RedirectToAction("ViewEmployeeDetails", new { id = emp.Id });
                            }
                            catch (Exception e)
                            {
                                throw new Exception(e.ToString());
                            }
                        }
                    }
                }
                
            }
            else
            {
                EmployeeDetails emp = new EmployeeDetails();
                using (ISession session = StartNHibernateSession.OpenSession())
                {
                    using (ITransaction tx = session.BeginTransaction())
                    {
                        emp.Id = employeeViewModel.Id;
                        try
                        {
                            session.Delete(emp);
                            tx.Commit();
                            MessageBox.Show("Record Deleted Successfully");
                            return RedirectToAction("EmployeeDetails");
                        }
                        catch(Exception e)
                        {
                            throw new Exception(e.ToString());
                        }
                    }
                }
            }
            return View();
        }
        [HttpGet]
         public ActionResult EmployeeDetailsRecord()
        {
            using (ISession session = StartNHibernateSession.OpenSession())
            {
                    try
                    {
                    var employee= session.CreateQuery("from " + typeof(EmployeeDetails)).List<EmployeeDetails>();
                    return View(employee);
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.ToString());
                    }
            }
        }
	}
}