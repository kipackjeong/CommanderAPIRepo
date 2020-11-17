using System.ComponentModel.DataAnnotations;

namespace CommanderAPI.Models
{
    public class Command
    {
        [Key] //using System.ComponentModel.DataAnnotations
        public int ID { get; set; }

        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }
        
        [Required]
        public string Platform { get; set; }

    }
}