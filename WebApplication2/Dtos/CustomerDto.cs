using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WebApplication2.Models;

namespace WebApplication2.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name")]
        [StringLength(255)]
        public String Name { get; set; }

        public bool isSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        //[Min18AgeIfMember]
        public DateTime? BirthDate { get; set; }
    }
}