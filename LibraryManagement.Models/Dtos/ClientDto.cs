using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models.Dtos
{
    public class ClientDto
    {
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public DateTime DOB { get; set; }

        public String Address { get; set; }

        public String MembershipCardNumber { get; set; }

        [Required]
        public DateTime MembershipCardValidityDate { get; set; }

        public DateTime LoanDate { get; set; }

        public DateTime ReturnDate { get; set; }
        public List<int> BookIds { get; set; }

    }
}
