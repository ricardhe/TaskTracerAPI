using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TaskTracerApi.Models
{
    public class WorkGroup
    {

        [Key]
        public int WorkGroupID { get; set; }
        
        [Required,MaxLength(50,ErrorMessage="Name must be 50 characters or less")]
        public string Name { get; set; }
        
        [Required, MaxLength(20, ErrorMessage = "Alias must be 20 characters or less")]
        public string Alias { get; set; }

        [MaxLength(200, ErrorMessage = "Description must be 200 characters or less")]
        public string Description { get; set; }
        
        [Required, MaxLength(150, ErrorMessage = "URLIdentifier must be 150 characters or less")]
        public string URLIdentifier { get; set; }
        
        [Required]
        public string EmailGroup { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

    }
}