using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name")]
        [StringLength(255)]
        public String Name { get; set; }

        public bool isSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Min18AgeIfMember]
        [Display(Name = "Date of Birth")]
        public DateTime? BirthDate { get; set; }
    }
}