using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FagTilmeldingApp.Codes
{
    enum SkoleInfo
    {
        Lærer,
        Elev,
        Fag,
        Klasse
    }
    internal class AdoHandler
    {
        //readonly. Da vi ikke kunne skrive readonly, stiller vi det op sådan her. Betyder det samme.
        public string? ErrorMessage { get; set; }
        public string? ConnectionString
        {
            get => "Data Source=DESKTOP-GV81FRQ;Initial Catalog=TEC;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
        public List<TeacherModel> GetTeachers(SkoleInfo lærer)
        {
            List<TeacherModel> teachers = new();
            try
            {
                //using så den lukker og åbner automatisk.
                using SqlConnection con = new(ConnectionString);

                con.Open();

                SqlCommand command = new("SELECT * FROM Lærer", con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    teachers.Add
                        (
                        new TeacherModel() { Id = reader.GetInt32(0), LastName = reader.GetString(1), FirstName = reader.GetString(2) }
                        );
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            return teachers;
        }
        public List<StudentModel> GetStudents(SkoleInfo elev)
        {
            List<StudentModel> students = new();
            try
            {
                //using så den lukker og åbner automatisk.
                using SqlConnection con = new(ConnectionString);

                con.Open();

                SqlCommand command = new("SELECT * FROM Elever", con);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    students.Add
                        (
                        new StudentModel() { Id = reader.GetInt32(0), LastName = reader.GetString(1), FirstName = reader.GetString(2) }
                        );
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            return students;
        }
        public List<CourseModel> GetCourses(SkoleInfo fag)
        {
            List<CourseModel> courses = new();
            try
            {
                //using så den lukker og åbner automatisk.
                using SqlConnection con = new(ConnectionString);

                con.Open();

                SqlCommand command = new("SELECT * FROM Fag", con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    courses.Add
                        (
                        //Her instatiere jeg mine col
                        new CourseModel() { Id = reader.GetInt32(0), Course = reader.GetString(1) }
                        );
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            return courses;
        }

        public List<Enrollment> GetEnrollment(SkoleInfo Klasse)
        {
            List<Enrollment> enrollmentList = new();
            try
            {
                //using så den lukker og åbner automatisk.
                using SqlConnection con = new(ConnectionString);

                con.Open();

                SqlCommand command = new("SELECT * FROM Klasse", con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    enrollmentList.Add
                        (
                        //Her instatiere jeg mine col
                        new Enrollment() { Id = reader.GetInt32(0), FagId = reader.GetInt32(1), ElevId = reader.GetInt32(2) }
                        );
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            return enrollmentList;
        }

        public void InsertEnrollment(int studentId, int courseId)
        {
            try
            {
                //using så den lukker og åbner automatisk.
                using SqlConnection con = new(ConnectionString);

                con.Open();

                SqlCommand command = null;

                command = new($"SELECT COUNT(*) FROM Klasse WHERE FagID = 2", con);
                using SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int rawsCount = reader.GetInt32(0);
                    if (rawsCount == 3)
                    {
                        //en custom error. Dvs. en fejl som du selv laver i programmet. Da der er 'new Exception' parser jeg en besked ind i min catch. 
                        //som så bliver min try i stedet.
                        throw new Exception("Maks 3 elever kan være tilmeldt database programmering.");
                    }
                    reader.Close();
                }
                command = new($"INSERT INTO Klasse VALUES ({courseId}, {studentId})", con);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
        public void DeleteAllInEnrollment(SkoleInfo klasse)
        {
            try
            {
                //using så den lukker og åbner automatisk.
                using SqlConnection con = new(ConnectionString);

                con.Open();

                SqlCommand command = new($"DELETE FROM Klasse", con);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
