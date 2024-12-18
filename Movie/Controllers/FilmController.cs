using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Models;
using Newtonsoft.Json;

namespace Movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        [HttpDelete("{id}")]
        //http?://localhost:xxxx/api/film/id
        public IActionResult Delete(int id)
        {
            using (var context = new MovieContext())
            {
                try
                {
                    Film film = new Film { Id = id };
                    context.Films.Remove(film);
                    context.SaveChanges();
                    return Ok("A film sikeresen törölve.");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        public IActionResult Put([FromForm] string Json, [FromForm] IFormFile indexKep, [FromForm] IFormFile kep)
        {
            using (var context = new MovieContext())
            {
                try
                {
                    Film film = JsonConvert.DeserializeObject<Film>(Json);                
                    byte[] IndexKep;
                    using (var ms = new MemoryStream()) 
                    {
                        indexKep.CopyTo(ms);
                        IndexKep = ms.ToArray();
                    }

                    byte[] Kep;
                    using (var ms = new MemoryStream())
                    {
                        kep.CopyTo(ms);
                        Kep = ms.ToArray();
                    }

                    film.IndexKep = IndexKep;
                    film.Kep = Kep;
                    context.Films.Update(film);                    
                    context.SaveChanges();
                    return Ok("A film adatainak a módosítása sikeresen megtörtént.");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

    }
}
