using Microsoft.EntityFrameworkCore;
using Movie.Models;
using Movie.DTOs;

namespace Movie.Services
{
    public class RendezoService
    {
        public static List<Rendezo> GetRendezok()
        {
            using(var context=new MovieContext())
            {
                try
                {
                    return context.Rendezos.ToList();
                }
                catch (Exception ex)
                {
                    List<Rendezo> response = new List<Rendezo>();
                    response.Add(new Rendezo { Id = -1, Nev = ex.Message});
                    return new List<Rendezo>();
                }
            }
        }


        public static List<RendezoDTO> GetRendezokDTO()
        {
            using (var context = new MovieContext())
            {
                try
                {
                    var response = context.Rendezos.Select(f => new RendezoDTO 
                    {
                        Id = f.Id,                      
                        Nev = f.Nev,
                        Nemzetiseg = f.Nemzetiseg,
                        SzulDatum = f.SzulDatum
                    }).ToList();
                    return response;
                }
                catch (Exception ex)
                {
                    List<RendezoDTO> response = new List<RendezoDTO>();
                    response.Add(new RendezoDTO { Id = -1, Nev = ex.Message });
                    return response;
                }
            }

        }

        public static Rendezo GetRendezo(int id)
        {
            using (var context = new MovieContext())
            {
                try
                {
                    var response = context.Rendezos.FirstOrDefault(f => f.Id == id);
                    return response;
                }
                catch
                {
                    return new Rendezo { Id = 0 };
                }
            }
        }





    }
}
