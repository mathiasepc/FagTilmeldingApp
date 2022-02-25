EntityFrameworkHandler em = new();

em.ClearKlasse();

string? errorMessage = null;

//opretter mine lister og linker det til min SQL server - link med Entity
List<Elever> elever = em.GetElever();
List<Fag> fag = em.GetFag();
List<Lærer> lærer = em.GetLærer();

//opretter min Klasse list
List<Klasse> klasse = em.GetKlasse();


Console.WriteLine("Angiv skole?");

string? skole = Console.ReadLine();

Console.WriteLine("Angiv hovedforløb?");

string? semesterNavn = Console.ReadLine();

Console.WriteLine("Angiv uddannelseslinje");

string? uddannelsesLinje = Console.ReadLine();

Semester semester = new(skole, semesterNavn);
semester.SetUddannelsesLinje(uddannelsesLinje);

uddannelsesLinje = null;
bool exitLoop = false;

while (!exitLoop)
{
    Console.WriteLine("Ønsker du at angive en kort beskrivelse til uddannelses linjen?");
    Console.WriteLine("1: Ja.");
    Console.WriteLine("2: Nej.");
    Console.Write("Vælg 1 eller 2: ");

    var choice = Console.ReadKey();

    switch (choice.Key)
    {
        case ConsoleKey.D1:
            Console.WriteLine();
            Console.WriteLine("Angiv kort beskrivelse af uddannelseslinjen");
            semester.UddannelsesLinjeBeskrivelse = Console.ReadLine();
            exitLoop = true;
            break;
        case ConsoleKey.D2:
            exitLoop = true;
            break;
        default:
            Console.WriteLine("Indtastede format er forkert. Prøv igen.");
            break;
    }   
}

Console.Clear();

Validation v = new Validation();

while (true)
{
    Console.Clear();

    klasse = em.GetKlasse();

    if (semester.UddannelsesLinjeBeskrivelse != null)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("---------------------------------------");
        Console.WriteLine($"{semester.SchoolName}, {semester.UddannelsesLinje}, {semester.SemesterNavn} fag tilmelding app");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"[ {semester.UddannelsesLinjeBeskrivelse} ]");
        Console.WriteLine("---------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("---------------------------------------");
        Console.WriteLine($"{semester.SchoolName}, {semester.UddannelsesLinje}, {semester.SemesterNavn} fag tilmelding app");
        Console.WriteLine("---------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
    }
    
    //a = søgeresultat
    List<Klasse> listEleverDisplay = klasse.Where(a => a.FagId == 1).ToList();
    Console.WriteLine($"{listEleverDisplay.Count()} Elever i grundlæggende programmering");

    listEleverDisplay = klasse.Where(a => a.FagId == 2).ToList();
    Console.WriteLine($"{listEleverDisplay.Count()} Elever i database programmering");

    listEleverDisplay = klasse.Where(a => a.FagId == 3).ToList();
    Console.WriteLine($"{listEleverDisplay.Count()} Elever i studieteknik");
    Console.WriteLine("---------------------------------------");

    if (errorMessage != null)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{errorMessage}");
        Console.ForegroundColor = ConsoleColor.White;
    }

    //nulstiller errormessage
    errorMessage = null;

    Console.WriteLine();
    
    foreach (Klasse displayInformation in klasse)
    {
        Fag? displayFag = fag.FirstOrDefault(a => a.Id == displayInformation.FagId);
        Elever? displayElev = elever.FirstOrDefault(a => a.Id == displayInformation.ElevId);

        if (displayElev != null && displayFag != null)
            Console.WriteLine($"{displayElev.FirstName} {displayElev.LastName} er tilmeldt {displayFag.Fag1}");
    }

    Console.WriteLine("---------------------------------------");

    bool succes = false;
    while (!succes)
    {
        Console.WriteLine("Indtast FagID");
        string? FagID = Console.ReadLine();
        succes = v.ValidationFag(FagID, fag);
        if (succes)
        {
            Console.WriteLine("Indtast ElevID");
            string? ElevID = Console.ReadLine();

            succes = v.ValidationElever(ElevID, elever);
            if (succes)
            {
                succes = v.ValidationKlasse(klasse);
                if (!succes)
                {
                    errorMessage = "Eksistere allerede.";
                    break;
                }
                else
                {
                    //tilføjer svaret til min Database.
                    em.InsertKlasse(v.ElevID, v.FagID);
                    errorMessage = em.ErrorMessage;
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





