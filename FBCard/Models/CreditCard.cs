using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBCard.Models
{
    public class CreditCard
    {
        public int Id { get; set; }
        [Required]
        public string Headline { get; set; }
        [Required]
        public string NumberCard { get; set; }
        [Required]
        public string ExpirationDate { get; set; }
        [Required]
        public string CVV { get; set; }

    }
}
