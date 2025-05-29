using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models.Dtos
{
    public class BookDto
    {

        public String IBAN { get; set; }


        public String Name { get; set; }


        public String Author { get; set; }


        public String Publisher { get; set; }


        public String Year { get; set; }

        public int NumberOfCopies { get; set; }
        
        public int ClientId { get; set; }
    }
}
