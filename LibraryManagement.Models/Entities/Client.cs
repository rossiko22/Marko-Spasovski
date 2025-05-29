using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models.Entities
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public String FirstName { get; set; }

        [Required, MaxLength(200)]
        public String LastName { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required, MaxLength(400)]
        public String Address { get; set; }

        [Required]
        public String MembershipCardNumber { get; set; }

        [Required]
        public DateTime MembershipCardValidityDate { get; set; }

        [Required]
        public DateTime LoanDate { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }


        public List<Book> Books { get; set; }


    }
}
