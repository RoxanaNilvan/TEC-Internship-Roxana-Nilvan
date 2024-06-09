using Internship.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiApp.Model
{
    public class PersonDetails
    {
        public int PersonDetailsId { get; set; }
        public DateTime BirthDay { get; set; }
        public string PersonCity {  get; set; }

        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public Person Person { get; set; }

    }
}
