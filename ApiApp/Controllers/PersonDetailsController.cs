using ApiApp.Model.DTO;
using Internship.Model;
using Microsoft.AspNetCore.Mvc;
using Internship.ObjectModel;
using Microsoft.AspNetCore.Http;
using System.Data.Entity;
using ApiApp.Model;

namespace ApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonDetailsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var db = new APIDbContext();
            var list = db.PersonDetails.ToList();
            return Ok(list);
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            var db = new APIDbContext();
            PersonDetails personDetails = db.PersonDetails.FirstOrDefault(x => x.PersonDetailsId == Id);
            if (personDetails == null)
                return NotFound();
            else
                return Ok(personDetails);

        }


        [HttpPost]
        public IActionResult Post(PersonDetailsDTO personDetailsDto)
        {
            if (ModelState.IsValid)
            {
                var db = new APIDbContext();
                var personDetailsEntity = new PersonDetails();
                personDetailsEntity.PersonCity = personDetailsDto.PersonCity;
                personDetailsEntity.BirthDay = personDetailsDto.BirthDay;
                personDetailsEntity.PersonId = personDetailsDto.PersonId;
                personDetailsEntity.Person = db.Persons.Find(personDetailsDto.PersonId);
                db.PersonDetails.Add(personDetailsEntity);
                db.SaveChanges();
                return Created("", personDetailsDto);
            }
            else
                return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult UpdatePersonDetails(PersonDetailsDTO personDetailsDto)
        {
            if (ModelState.IsValid)
            {
                using (var db = new APIDbContext())
                {
                    PersonDetails personDetails = db.PersonDetails.Find(personDetailsDto.PersonDetailsId);
                    if (personDetails == null)
                        return NotFound();

                    personDetails.BirthDay = personDetailsDto.BirthDay;
                    personDetails.PersonCity = personDetailsDto.PersonCity;
                    personDetails.PersonId = personDetailsDto.PersonId;
                    personDetails.Person = db.Persons.Find(personDetailsDto.PersonId); // Ensure the related Person entity is updated

                    db.SaveChanges();
                    return NoContent();
                }
            }
            else
                return BadRequest();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var db = new APIDbContext();
            PersonDetails person = db.PersonDetails.Find(Id);
            if (person == null)
                return NotFound();
            else
            {
                db.PersonDetails.Remove(person);
                db.SaveChanges();
                return NoContent();
            }
        }
    }
}
