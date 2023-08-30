using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModelLayer
{
    public class Owner
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public string ProfilePicture { get; set; }
        public string Specilization { get; set; }
        public string Address { get; set; }
        public string AboutMe { get; set; }

    }
}
