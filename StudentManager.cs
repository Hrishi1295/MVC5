using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
    public class StudentManager
    {
        public static bool RegisterStudent(Student stud)
        {
            bool status = false;

            bool result = DBStudentManager.RegisterStudent(stud);
            if(result==true)
            {
                status = true;
            }
            return status;
        }
        public static bool Authenticate(string email,string password)
        {
            bool status = false;
            status = DBStudentManager.AuthenticateStud(email, password);
            return status;
        }
    }
}
