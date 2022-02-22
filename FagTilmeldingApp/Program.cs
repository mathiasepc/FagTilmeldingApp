//Her er interation
string errorMessage = null;

List<TeacherModel> listTeachers = new()
{
    new TeacherModel() { Id = 1, FirstName = "Niels", LastName = "Henriksen" },
    new TeacherModel() { Id = 2, FirstName = "Michael", LastName = "Thomasen" },
    new TeacherModel() { Id = 3, FirstName = "Klaus", LastName = "Pedersen" }
};

List<CourseModel> listCourses = new()
{
    new CourseModel() { Id = 1, Course = "Grundlæggende programmering" },
    new CourseModel() { Id = 2, Course = "Database programmering" },
    new CourseModel() { Id = 3, Course = "Studieteknik" }
};
List<StudentModel> listStudents = new()
{
    new StudentModel() { Id = 1, FirstName = "Martin", LastName = "Jensen" },
    new StudentModel() { Id = 2, FirstName = "Patrik", LastName = "Nielsen" },
    new StudentModel() { Id = 3, FirstName = "Susanne", LastName = "Hansen" },
    new StudentModel() { Id = 4, FirstName = "Thomas", LastName = "Olsen" }
};

List<Enrollment> listEnrollment = new();


Console.WriteLine("Angiv skole?");

string? skole = Console.ReadLine();

Console.WriteLine("Angiv hovedforløb?");

string? semesterNavn = Console.ReadLine();

Console.WriteLine("Angiv uddannelseslinje");

string? uddannelsesLinje = Console.ReadLine();

Semester semester = new(skole, semesterNavn);

semester.SetUddannelseslinje(uddannelsesLinje);

Console.Clear();

Validation v = new Validation();

while (true)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("---------------------------------------");
    Console.WriteLine($"{semester.SchoolName}, {semester.UddannelsesLinje}, {semester.SemesterNavn} fag tilmelding app");
    Console.WriteLine("---------------------------------------");
    Console.ForegroundColor = ConsoleColor.White;

    //a = søgeresultat
    List<Enrollment> listEleverDisplay = listEnrollment.Where(a => a.FagId == 1).ToList();
    Console.WriteLine($"{listEleverDisplay.Count()} Elever i grundlæggende programmering");

    listEleverDisplay = listEnrollment.Where(a => a.FagId == 2).ToList();
    Console.WriteLine($"{listEleverDisplay.Count()} Elever i database programmering");

    listEleverDisplay = listEnrollment.Where(a => a.FagId == 3).ToList();
    Console.WriteLine($"{listEleverDisplay.Count()} Elever i studieteknik");
    Console.WriteLine("---------------------------------------");

    Console.WriteLine();
    foreach (Enrollment displayInformation in listEnrollment)
    {
        CourseModel displayFag = listCourses.FirstOrDefault(a => a.Id == displayInformation.Id);
        StudentModel displayElev = listStudents.FirstOrDefault(a => a.Id == displayInformation.Id);

        Console.ForegroundColor = ConsoleColor.Red;
        if (errorMessage != null)
        {
            Console.WriteLine($"{errorMessage}");
        }
        Console.ForegroundColor = ConsoleColor.White;
        //nulstiller errorMessage
        errorMessage = null;
        
        if (displayElev != null && displayFag != null)
            Console.WriteLine($"{displayElev.FirstName} {displayElev.LastName} er tilmeldt {displayFag.Course}");
    }
    Console.WriteLine("---------------------------------------");

    bool succes = false;
    while (!succes)
    {
        Console.WriteLine("Indtast FagID");
        string FagID = Console.ReadLine();
        succes = v.ValidationCourse(FagID, listCourses);
        if (succes)
        {
            Console.WriteLine("Indtast ElevID");
            string ElevID = Console.ReadLine();

            succes = v.ValidationStudent(ElevID, listStudents);
            if (succes)
            {
                succes = v.EnrollmentValidation(listEnrollment);
                if (!succes)
                {
                    errorMessage = "Eksistere allerede.";
                    break;
                }
                else
                {
                    //tilføjer svaret til min liste.
                    listEnrollment.Add(new Enrollment() { Id = listEnrollment.Count() + 1, FagId = v.FagID, ElevId = v.ElevID });
                }
            }
            else
            {
                errorMessage = v.ErrorMessage;
                break;
            }
        }
        else
        {
            errorMessage = v.ErrorMessage;
            break;
        }
    }
}





