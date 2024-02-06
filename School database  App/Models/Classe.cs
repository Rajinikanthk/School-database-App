using System.ComponentModel.DataAnnotations;

namespace School_database__App.Models
{
    public class Classe
    {
        [Key]
        public int class_id { get; set; }

        public string? ClassSection { get; set; }
    }
}
