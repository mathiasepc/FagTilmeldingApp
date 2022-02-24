using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldingApp.Codes
{
    //abstract indkapsler School så den kun kan være parentklasse.
    internal abstract class School 
    {
        public string SchoolName { get; set; }

        public string UddannelsesLinjen {get; set;}

        public School (string schoolName)
        {
            SchoolName = schoolName;
        }
       
        //hvis man ikke ved hvad kroppen skal være, men kender metoden. Derfor abstract så jeg laver child lave kroppen.
        public abstract void SetUddannelsesLinje(string? uddannelsesLinje);
    }
}
