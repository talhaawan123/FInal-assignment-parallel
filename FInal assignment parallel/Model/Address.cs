using System.ComponentModel.DataAnnotations;

namespace FInal_assignment_parallel.Model
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }

        // Foreign key
        public int StudentId { get; set; }

        // Navigation property
        public Student Student { get; set; }
    }
}
