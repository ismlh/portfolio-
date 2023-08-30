using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModelLayer
{
    public class profileItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string itemName { get; set; }
        public string itemImage { get; set; }
        public string itemDescription { get; set; }
        public string gitHubLink { get; set; }
        public string ItemUrl { get; set; }
    }
}
