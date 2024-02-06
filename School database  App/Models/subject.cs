using System.ComponentModel.DataAnnotations;

namespace School_database__App.Models
{
    public class subject
    {
        [Key]
        public int Subject_id { get; set; }

        public string? Subject_Name { get; set; }
    }
}
