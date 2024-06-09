using System.ComponentModel.DataAnnotations.Schema;

namespace ApiApp.Model.DTO
{
    public class PersonDetailsDTO
    {
        public int PersonDetailsId { get; set; }
        public DateTime BirthDay { get; set; }
        public string PersonCity { get; set; }
        public int PersonId { get; set; }
    }
}
