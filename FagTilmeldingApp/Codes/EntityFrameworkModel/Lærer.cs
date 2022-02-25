using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldingApp.Codes.EntityFrameworkModel
{
    public partial class Lærer
    {
        public Lærer()
        {
            Fags = new HashSet<Fag>();
        }

        public int Id { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public int ElevId { get; set; }
        //virtual betyder bare at man gerne må override. Atlså ligesom abstract. Forksellen er virtual behøver ikke at overskrive. det skal man i abstract.
        public virtual ICollection<Fag> Fags { get; set; }
    }
}
