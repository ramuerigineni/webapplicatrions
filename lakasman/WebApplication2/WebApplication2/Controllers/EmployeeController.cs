using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using System.Data.SqlClient;
namespace WebApplication2.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult EmployeeList()
        {
            //var list = new List<Empmodel>(); 
            //var empmodel = new Empmodel();
            //empmodel.Address = "Hyd";
            //empmodel.Empname = "Ram";
            //empmodel.phoneNo = 8179377052;
            //empmodel.Email = "erigineniram@gmail.com";
            //list.Add(empmodel);
            //return View(list);

            //this for view the data
            List<Empmodel> emplist = new List<Empmodel>();
            ViewBag.Response = TempData["Response"];
            SqlConnection con = new SqlConnection("Data Source=RAM;Database=personalsmvc;Integrated Security=true");
            con.Open();
            string query = "select * from Employee";
            SqlCommand cmd = new SqlCommand(query,con);
            var data=cmd.ExecuteReader();
            while (data.Read())
            {
                Empmodel model = new Empmodel();
                model.id = Convert.ToInt64(data["id"].ToString());
                model.Address = data["Address"].ToString();
                model.Empname = data["Empname"].ToString();
                model.phoneNo = Convert.ToInt64(data["phoneNo"].ToString());
                model.Email = data["Email"].ToString();
                emplist.Add(model);
            }
            return View(emplist);
        }
        [HttpGet]
        public ActionResult CreateEmpoyee()
        {
            return View();
        }

        public ActionResult EmployeeDetailsById(int id)
        {
            Empmodel model = new Empmodel();
            SqlConnection con = new SqlConnection("Data Source=RAM;Database=personalsmvc;Integrated Security=true");
            con.Open();
            string query = "select * from Employee where id='"+ id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            var data = cmd.ExecuteReader();
            while (data.Read())
            {
               
                model.id = Convert.ToInt64(data["id"].ToString());
                model.Address = data["Address"].ToString();
                model.Empname = data["Empname"].ToString();
                model.phoneNo = Convert.ToInt64(data["phoneNo"].ToString());
                model.Email = data["Email"].ToString();

            }
            con.Close();
            return View(model);
        }
            [HttpPost]
        public ActionResult CreateEmpoyee(Empmodel emp) {
            //sql connection
            SqlConnection con = new SqlConnection("Data Source=RAM;Database=personalsmvc;Integrated Security=true");
            con.Open();
            string query = "insert into Employee values('" + emp.Empname + "','" + emp.Address + "','" + emp.phoneNo + "','" + emp.Email + "')";
            SqlCommand cmd = new SqlCommand(query, con);
           int i= cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                TempData["responcemsg"] = "Employee Added";
                return RedirectToAction("EmployeeList");
            }
            else {
                return View();
            }
            
        }
        [HttpGet]
        public ActionResult Editemployee(int id) 
        {
            Empmodel model = new Empmodel();
            SqlConnection con = new SqlConnection("Data Source=RAM;Database=personalsmvc;Integrated Security=true");
            con.Open();
            string query = "select * from Employee where id='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            var data = cmd.ExecuteReader();
            while (data.Read())
            {

                model.id = Convert.ToInt64(data["id"].ToString());
                model.Address = data["Address"].ToString();
                model.Empname = data["Empname"].ToString();
                model.phoneNo = Convert.ToInt64(data["phoneNo"].ToString());
                model.Email = data["Email"].ToString();

            }
            con.Close();
            return View(model);

        }
        [HttpPost]
        public ActionResult Editemployee(Empmodel emp)
        {
            Empmodel model = new Empmodel();
            SqlConnection con = new SqlConnection("Data Source=RAM;Database=personalsmvc;Integrated Security=true");
            con.Open();
            string query = "Update employee set  Empname='" + emp.Empname + "',Email='"+emp.Email+ "',Address='" + emp.Address+"'where id='"+emp.id+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            var data = cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("EmployeeList");

        }
        [HttpGet]
        public ActionResult Deleteemp(int id)
        {
            var data = getdata(id);
            return View(data);
        }
        [HttpPost]
        public  ActionResult Deleteemp(string id)
        {
            Empmodel model = new Empmodel();
            SqlConnection con = new SqlConnection("Data Source=RAM;Database=personalsmvc;Integrated Security=true");
            con.Open();
            string query = "delete  from Employee where id='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            var j = cmd.ExecuteNonQuery();
            if (j == 1)
            {
                TempData[""] = "Employee delete sucessfully";
            }
            con.Close();
            return RedirectToAction("EmployeeList");

        }



        private Empmodel getdata(int id)
        {
            Empmodel model = new Empmodel();
            SqlConnection con = new SqlConnection("Data Source=RAM;Database=personalsmvc;Integrated Security=true");
            con.Open();
            string query = "select * from Employee where id='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            var data = cmd.ExecuteReader();
            while (data.Read())
            {

                model.id = Convert.ToInt64(data["id"].ToString());
                model.Address = data["Address"].ToString();
                model.Empname = data["Empname"].ToString();
                model.phoneNo = Convert.ToInt64(data["phoneNo"].ToString());
                model.Email = data["Email"].ToString();

            }
            con.Close();
            return model;
            
        }
    }
}