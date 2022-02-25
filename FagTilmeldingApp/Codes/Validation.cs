    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FagTilmeldingApp.Codes;

namespace FagTilmeldingApp.Codes
{
    internal class Validation
    {
        public int FagID { get; set; }
        public int ElevID { get; set; }
        public string? ErrorMessage { get; set; }   
        public bool ValidationFag(string fagID, List<Fag> fag)
        {
            bool succes = int.TryParse(fagID, out int result);
            if (!succes)
               ErrorMessage = "Det indtastede fagID er forkert format.";
            else
            {
                Fag? fagId = fag.FirstOrDefault(a => a.Id == result);
                // eksistere id ikke.
                if (fagId == null)
                {
                    succes = false;
                    ErrorMessage = "Det indtastede fagID eksistere ikke.";
                }
                else
                {
                    FagID = result;
                }
            }   
            return succes;
        }
        public bool ValidationElever(string elevID, List<Elever> elever)
        {
            bool succes = int.TryParse(elevID, out int result);
            if (!succes)
                 ErrorMessage = "Det indtastede elevID er forkert format";
            else
            {
                Elever? studentId = elever.FirstOrDefault(a => a.Id == result);
                // Hvis ingen match er, eksistere id ikke.
                if (studentId == null)
                {
                    succes = false;
                    ErrorMessage = "Det indtastede ElevID eksistere ikke.";
                }
                else
                {
                    ElevID = result;
                }
            }            
            return succes;
        }
        public bool ValidationKlasse(List<Klasse> klasse)
        {
            bool succes = true;
            Klasse? klasseID = klasse.FirstOrDefault(a => a.FagId == FagID && a.ElevId ==ElevID);
            
            if(klasseID != null)
            {
                succes = false;
            }            
            return succes;
        }

    }
}
