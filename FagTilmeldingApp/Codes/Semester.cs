using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldingApp.Codes
{
    //Sealed betyder det er den sidste i nedarving
    internal sealed class Semester : School
    {
        string SemesterNavn { get; set; }
        //base = parent. ved at skrive base ved construkter, betyder at data kan komme fra parent til child og omvendt
        public Semester(string semesterNavn, string schoolName) : base(schoolName)
        {
            SemesterNavn = semesterNavn;
        }
    }
}
