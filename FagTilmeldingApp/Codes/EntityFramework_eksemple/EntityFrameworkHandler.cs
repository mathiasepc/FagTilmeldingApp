using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace FagTilmeldingApp.Codes.EntityFramework_eksemple
{
    internal class EntityFrameworkHandler
    {
        //public EntityFrameworkHandler DB
        //{
        //    get
        //    {
        //        using TECContext db = new();
        //        return db;
        //    }
        //}

        public string ErrorMessage { get; set; }

        public List<Lærer> GetLærer()
        {
            List<Lærer> lærer = new();
            try
            {
                using TECContext db = new();
                lærer = db.Lærers.ToList();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            return lærer;
        }
        public List<Elever> GetElever()
        {
            List<Elever> elever = new();
            try
            {
                using TECContext db = new();
                elever = db.Elevers.ToList();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            return elever;
        }
        public List<Fag> GetFag()
        {
            List<Fag> fag = new();
            try
            {
                using TECContext db = new();
                fag = db.Fags.ToList();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            return fag;
        }

        public List<Klasse> GetKlasse()
        {
            List<Klasse> klasse = new();
            try
            {
                using TECContext db = new();
                klasse = db.Klasses.ToList();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            return klasse;
        }

        public void InsertKlasse(int elevId, int fagId)
        {
            try
            {
                //using så den lukker og åbner automatisk.
                using TECContext db = new();
                var klasse = new Klasse() { FagId = fagId, ElevId = elevId };

                int rawsCount = (db.Klasses.Where(a => a.FagId == 2)).Count();
                if (rawsCount == 3)
                {
                    throw new Exception("Maks 3 elever i database programmering");
                }
                else
                {
                    db.Add(klasse);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
        public void ClearKlasse()
        {
            try
            {
                //using så den lukker og åbner automatisk.
                using TECContext db = new();
                foreach (Klasse item in db.Klasses.ToList())
                    db.Remove(item);

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}

