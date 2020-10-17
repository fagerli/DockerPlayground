using System.ComponentModel.DataAnnotations;

namespace Person.Person
{
    public class PersonModel
    {
        [Required(ErrorMessage = "User Firstname is required")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "User Lastname is required")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "User Streetname is required")]
        public string Streetname { get; set; }

        [Required(ErrorMessage = "Zip is required")]
        public string Zip { get; set; }
    }
}
