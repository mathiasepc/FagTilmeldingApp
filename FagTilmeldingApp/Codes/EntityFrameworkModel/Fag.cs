using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldingApp.Codes.EntityFrameworkModel
{
    //partial betyder at den hører sammen med en anden klasse
    public partial class Fag
    {
        public Fag()
        {
            Klasses = new HashSet<Klasse>();
        }

        public int Id { get; set; }
        public string Fag1 { get; set; } = null!;
        public int LærerId { get; set; }
        //virtual betyder bare at man gerne må override. Atlså ligesom abstract. Forksellen er virtual behøver ikke at overskrive. det skal man i abstract.
        public virtual Lærer Lærer { get; set; } = null!;
        public virtual ICollection<Klasse> Klasses { get; set; }
    }
}
