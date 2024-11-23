using System.ComponentModel.DataAnnotations.Schema;

namespace SipaksiNew.Modules.User.Api.Entities
{
    [Table("user")]
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public DateTime EnrollmentDate { get; set; }
    }

}
