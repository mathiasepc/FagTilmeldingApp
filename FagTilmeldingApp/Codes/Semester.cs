using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldingApp.Codes
{
    //Sealed betyder det er den sidste i nedarving.
    //Semester : School betyder at Semester er en nedarving af School.
    internal sealed class Semester : School
    {
        public string SemesterNavn { get; set; }
        public string? UddannelsesLinje { get; set; }
        public string? UddannelsesLinjeBeskrivelse { get; set; }
        //base = parent. ved at skrive base ved construkter, betyder at data kan komme fra parent til child og omvendt
        //jeg har schoolName med fordi den kommer fra parentklasse.
        public Semester(string semesterNavn, string schoolName) : base(schoolName)
        {
            SemesterNavn = semesterNavn;
        }
        //bliver brugt til at kunne tilføje en ekstra propperty uden at ødelægge parent og child struktur eller metode.
        public override void SetUddannelsesLinje(string? uddannelsesLinje)
        {
            UddannelsesLinje = uddannelsesLinje;
        }

        public void SetUddannelsesLinje(string uddannelsesLinje, string uddannelsesLinjeBeskrivelse)
        {
            UddannelsesLinje = uddannelsesLinje;
            UddannelsesLinjeBeskrivelse = uddannelsesLinje;
        }
    }
}
