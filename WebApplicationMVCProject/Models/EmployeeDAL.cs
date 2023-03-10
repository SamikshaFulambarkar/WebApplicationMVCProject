using AspNetCore;
using System.Data.SqlClient;
namespace WebApplicationMVCProject.Models
{
    public class EmployeeDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public EmployeeDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("MydbConnection"));
        }
        public Employee GetEmployeeById(int id)
        {
            Employee emp = new Employee();
            string str = "select * from table_Emplployee where id=@id";
            cmd=new SqlCommand(str,con);
            cmd.Parameters.AddWithValue("@id", id);

        }
        public int AddEmployee(Employee emp)
        {
            int result = 0;
            emp.IsActive = 1;
            string query = "insert into table_Employee values(@name, @email, @pass, @mobileno, @age, cast(@doj as date), @isactive)";
            cmd=new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@email", emp.Email_ID);
            cmd.Parameters.AddWithValue("@pass", emp.Create_Password);
            cmd.Parameters.AddWithValue("mobileno", emp.Mobile_No);
            cmd.Parameters.AddWithValue("@age", emp.Age);
            cmd.Parameters.AddWithValue("@doj", emp.DOJ);
            cmd.Parameters.AddWithValue("@isactive", emp.IsActive);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateEmployee(Employee emp)
        {
            int result = 0;
            emp.IsActive = 1;
            string query = "update table_Employee set name=@name, emailid=@email, createpassword=@pass," +
                "mobileno=@mobile, age=@age, doj=cast(@doj as date)where id=@id";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@email", emp.Email_ID);
            cmd.Parameters.AddWithValue("@pass", emp.Create_Password);
            cmd.Parameters.AddWithValue("mobileno", emp.Mobile_No);
            cmd.Parameters.AddWithValue("@age", emp.Age);
            cmd.Parameters.AddWithValue("@doj", emp.DOJ);
            cmd.Parameters.AddWithValue("@id", emp.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteEmployee(int id)
        {
            int result = 0;
            string query = "update table_Employee set isactive=0 where id=@id";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        internal int AddEmployee(Controllers.Employee emp)
        {
            throw new NotImplementedException();
        }
    }
}
