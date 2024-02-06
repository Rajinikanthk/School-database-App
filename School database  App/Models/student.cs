using System.ComponentModel.DataAnnotations;

namespace School_database__App.Models
{
    public class student
    {
        [Key]
        public int Student_id { get; set; }

        public string? FirstName { get; set; }
    }
}
