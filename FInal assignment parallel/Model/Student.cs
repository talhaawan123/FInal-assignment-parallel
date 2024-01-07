using System.ComponentModel.DataAnnotations;

namespace FInal_assignment_parallel.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string RollNo { get; set; }
        public string Class { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
