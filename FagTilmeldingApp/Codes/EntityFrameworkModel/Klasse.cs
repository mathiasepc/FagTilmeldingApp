using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldingApp.Codes.EntityFrameworkModel
{
    //partial betyder at den hører sammen med en anden klasse
    public partial class Klasse
    {
        public int KlasseId { get; set; }
        public int FagId { get; set; }
        public int ElevId { get; set; }
        //virtual betyder bare at man gerne må override. Atlså ligesom abstract. Forksellen er virtual behøver ikke at overskrive. det skal man i abstract.
        public virtual Elever Elev { get; set; } = null!;
        public virtual Fag Fag { get; set; } = null!;
    }
}
