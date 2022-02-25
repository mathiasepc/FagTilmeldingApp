using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldingApp.Codes.EntityFrameworkModel
{
    public partial class Elever
    {
        public Elever()
        {
            Klasses = new HashSet<Klasse>();
        }

        public int Id { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        //virtual betyder bare at man gerne må override. Atlså ligesom abstract. Forksellen er virtual behøver ikke at overskrive. det skal man i abstract.
        public virtual ICollection<Klasse> Klasses { get; set; }
    }
}
