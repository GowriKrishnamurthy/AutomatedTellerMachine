using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutomatedTellerMachine.Models
{
    public class CheckingAccount
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        [Display(Name = "Account #")]
        [RegularExpression(@"\d{6,10}", ErrorMessage = "Account # must be between 6 and 10 digits")]
        public string AccountNumber { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Name => $"{FirstName} {LastName}";

        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        [Required]
        // lazy loading of the related objct - ApplicationUser table
        public virtual ApplicationUser User { get; set; }
        public string ApplicationUserId { get; set; }

        // collection of all the transactions
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}