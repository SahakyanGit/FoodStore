using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FoodStore.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter address")]
        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string OrderDate { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public string Total { get; set; }

        public string Username { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number must be numeric")]
        public string Phone { get; set; }

        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
    }
}
