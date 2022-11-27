using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAtrioAPI.DTOs;
using WebAtrioAPI.Entities;

namespace WebAtrioAPI.Controllers
{
    [ApiController]
    [Route("api/personnes")]
    public class PersonneController : ControllerBase
    {
        public readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public PersonneController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> AjouterUnePersonne(PersonneDTO personneDTO)
        {
            var today = DateTime.Today;
            var age = today.Year - personneDTO.DateDeNaissance.Year;
            var personne = mapper.Map<Personne>(personneDTO);

            if (age > 150)
            {
               return StatusCode(StatusCodes.Status401Unauthorized, new { message = "Seule les personnes de moins de 150 ans peuvent être enregistrées" });
            }

            context.Add(personne);
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpGet("/listedespersonnes")]
        public IEnumerable<PersonneDTO> ListeDesPersonnes()
        {
            List<PersonneDTO> personnes = new List<PersonneDTO>();

            var dataset =
            (from personne in context.Personnes

             select new PersonneDTO
             {
                 Nom = personne.Nom,
                 Prenom = personne.Prenom,
                 DateDeNaissance = personne.DateDeNaissance,
                 Age = DateTime.Now.Year - personne.DateDeNaissance.Year

             }).ToList();

            personnes = dataset;

            return  personnes.OrderBy(g => g.Nom);

        }
    }
}
