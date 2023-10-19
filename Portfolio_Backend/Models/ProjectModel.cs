﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio_Backend.Models
{
    public class ProjectModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string title { get; set; }

        [Required]
        [MaxLength(101)]
        public string route { get; set; }

        [Required]
        public string imgsrc { get; set; }

        [Required]
        [MaxLength(100)]
        public string imgalt { get; set; }

        [Required]
        public string github { get; set; }

        [Required]
        public string skills { get; set; }

        [Required]
        public string[] descriptions { get; set; }

        [Required]
        public string[] subImages { get; set; }
    }
}
