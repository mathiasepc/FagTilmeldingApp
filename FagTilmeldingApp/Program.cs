using FagTilmeldingApp.Codes;

Console.WriteLine("Angiv skole?");

string? skole = Console.ReadLine();

Console.WriteLine("Angiv fag?");

string? fag = Console.ReadLine();

Semester semester = new(skole, fag);

Console.Clear();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("---------------------------------------");
Console.WriteLine($"{skole}, {fag} fag tilmelding app");
Console.WriteLine("---------------------------------------");