using JIPT_Institute.Models;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace JIPT_Institute.ViewModels
{
    public class RegisterViewModel
    {
        static InstituteDataDataContext DataContext = new InstituteDataDataContext("Data Source=DESKTOP-DQFRRRU\\SQLEXPRESS;Initial Catalog=InstituteDb;User ID=sa;Password=9431353474;Encrypt=False");

        public static ResponseModel SaveUser(StudentModel student)
        {

            ResponseModel resp = new ResponseModel();
            try
            {
                tblstudent ct = new tblstudent();

                if (ct.sid == 0)
                {                    
                    ct.Name = student.Name;
                    ct.Age = student.Age;
                    ct.Gender = student.Gender;
                    ct.Phone = student.Phone;
                    ct.Email = student.Email;
                    ct.Address = student.Address;
                    ct.Course = student.Course;

                    DataContext.tblstudents.InsertOnSubmit(ct);
                    DataContext.SubmitChanges();
                    resp.Status = true;
                    resp.Message = "You have been Registered successsfully";
                    return resp;
                }
                else
                {
                    ct = (from v in DataContext.tblstudents where v.sid == student.sId select v).FirstOrDefault();
                    {
                        ct.Name = student.Name;
                        ct.Age = student.Age;
                        ct.Gender = student.Gender;
                        ct.Phone = student.Phone;
                        ct.Email = student.Email;
                        ct.Address = student.Address;
                        ct.Course = student.Course;

                        DataContext.SubmitChanges();
                        resp.Status = true;
                        resp.Message = "Student Details Updated Successfully...";
                        return resp;
                    }
                }

            }
            catch (Exception ex)
            {
                resp.Status = false;
                resp.Message = ex.Message;
                return resp;
            }

        }
    }
}