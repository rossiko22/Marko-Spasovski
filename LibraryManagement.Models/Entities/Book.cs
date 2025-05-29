using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryManagement.Models.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String IBAN { get; set; }

        [Required]
        public String Name { get; set; }
        
        [Required]
        public String Author { get; set; }

        [Required]
        public String Publisher { get; set; }

        [Required]
        public String Year { get; set; }

        [Required]
        public int NumberOfCopies { get; set; }


        [ForeignKey("Client")]
        public int ClientId;
        [JsonIgnore]
        public Client Client;


    }
}
