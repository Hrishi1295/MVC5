using BOL;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DBStudentManager
    {
        public static string sqlCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hrishikesh\source\repos\practice\StudentMVC\App_Data\Student.mdf;Integrated Security=True";


        public static bool RegisterStudent(Student stud)
        {
            string cmdString = "insert into Student values (@Id,@name,@email,@password,@age)";
            Boolean status = false;
            IDbConnection con = new SqlConnection();
            con.ConnectionString = sqlCon;
           IDbCommand cmd = new SqlCommand();


            cmd.Connection = con;
            cmd.CommandText = cmdString;

            cmd.Parameters.Add(new SqlParameter("@Id", stud.Id));
            cmd.Parameters.Add(new SqlParameter("@name", stud.Name));
            cmd.Parameters.Add(new SqlParameter("@email", stud.Email));
            cmd.Parameters.Add(new SqlParameter("@password", stud.Password));
            cmd.Parameters.Add(new SqlParameter("@age", stud.Age));
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if(result<0)
                {
                    status = true;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return status;
        }

        public static bool AuthenticateStud(string email,string password)
        {
            bool status = false;
            string cmdString = "select * from Student where email=@email and password=@password";
            IDbConnection con = new SqlConnection();
            con.ConnectionString = sqlCon;

            IDbCommand cmd= new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = cmdString;

            cmd.Parameters.Add(new SqlParameter("@email", email));
            cmd.Parameters.Add(new SqlParameter("@password", password));

            IDataReader reader= null;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    status = true;
                }
            }catch(Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
            return status;
        }
    }
}
