using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FagTilmeldingApp.Codes;

namespace FagTilmeldingApp.Codes
{
    internal class Validation
    {
        public int FagID { get; set; }
        public int ElevID { get; set; }
        public string? ErrorMessage { get; set; }   
        public bool ValidationCourse(string fagID, List<CourseModel> listCourses)
        {
            bool succes = int.TryParse(fagID, out int result);
            if (!succes)
                Console.WriteLine("Det indtastede FagID er forkert format.");
            else
            {
                CourseModel? fagId = listCourses.FirstOrDefault(a => a.Id == result);
                // eksistere id ikke.
                if (fagId == null)
                {
                    succes = false;
                    ErrorMessage = "Det indtastede fagID eksistere ikke.";
                }
                else
                {
                    FagID = result;
                }
            }   
            return succes;
        }
        public bool ValidationStudent(string elevID, List<StudentModel> listStudents)
        {
            bool succes = int.TryParse(elevID, out int result);
            if (!succes)
                return succes;
            else
            {
                StudentModel? studentId = listStudents.FirstOrDefault(a => a.Id == result);
                // Hvis ingen match er, eksistere id ikke.
                if (studentId == null)
                {
                    succes = false;
                    ErrorMessage = "Det indtastede ElevID eksistere ikke.";
                }
                else
                {
                    ElevID = result;
                }
            }            
            return succes;
        }
        public bool EnrollmentValidation(List<Enrollment> listEnrollment)
        {
            bool succes = true;
            Enrollment? enrollmentID = listEnrollment.FirstOrDefault(a => a.FagId == FagID && a.ElevId ==ElevID);
            
            if(enrollmentID != null)
            {
                succes = false;
            }            
            return succes;
        }

    }
}
