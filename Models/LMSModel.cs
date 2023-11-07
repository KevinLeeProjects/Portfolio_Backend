using System.ComponentModel.DataAnnotations;

namespace Portfolio_Backend.Models
{
    public class LMSModel
    {
        [Key, Required]
        public string route { get; set; }
        [Required]
        public string skills { get; set; }
        [Required]
        public string blurb { get; set; }
        [Required]
        public string github { get; set; }
        [Required]
        public string mainImg { get; set; }
        [Required]
        public string getBookTitle { get; set; }
        [Required]
        public string getBookDesc { get; set; }
        [Required]
        public string addBookTitle { get; set; }
        [Required]
        public string addBookDesc { get; set; }
        [Required]
        public string checkoutBookTitle { get; set; }
        [Required]
        public string checkoutBookDesc { get; set; }
        [Required]
        public string transactionHistoryTitle { get; set; }
        [Required]
        public string transactionHistoryDesc { get; set; }
        [Required]
        public string getBookImg { get; set; }
        [Required]
        public string addBookImg { get; set; }
        [Required]
        public string checkoutImg { get; set; }
        [Required]
        public string transactionImg { get; set; }
        [Required]
        public string getUserTitle { get; set; }
        [Required]
        public string getUserBlurb { get; set; }
        [Required]
        public string getUserImg { get; set; }

    }
}
