using Microsoft.Data.SqlClient;

namespace CrudUsingADO.Models
{
    public class StudentCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public StudentCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }

        // get all emp
        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            cmd = new SqlCommand("select * from student", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Student student = new Student();
                    student.StudentID = Convert.ToInt32(dr["StudentID"]);
                    student.Name = dr["name"].ToString();
                    student.Email = dr["email"].ToString();
                    student.Course = dr["course"].ToString();
                    students.Add(student);
                }
            }
            con.Close();
            return students;
        }
        public Student GetStudentById(int id)
        {
            Student student = new Student();
            cmd = new SqlCommand("select * from student where StudentID=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    student.StudentID = Convert.ToInt32(dr["StudentID"]);
                    student.Name = dr["name"].ToString();
                    student.Email = dr["email"].ToString();
                    student.Course = dr["course"].ToString();

                }
            }
            con.Close();
            return student;
        }

        public int AddStudent(Student std)
        {
            int result = 0;
            string qry = "insert into student values(@name,@email,@course)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", std.Name);
            cmd.Parameters.AddWithValue("@email", std.Email);
            cmd.Parameters.AddWithValue("@course", std.Course);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateStudent(Student std)
        {
            int result = 0;
            string qry = "update student set name=@name,email=@email,course=@course where StudentID=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", std.Name);
            cmd.Parameters.AddWithValue("@email", std.Email);
            cmd.Parameters.AddWithValue("@course", std.Course);
            cmd.Parameters.AddWithValue("@id", std.StudentID);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteStudent(int id)
        {
            int result = 0;
            string qry = "delete from student where StudentID=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
