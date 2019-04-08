using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace QuotingDojo.Models
{
    public class Quote
    {
        [Required]
        [MinLength(3)]
        public string quote {get;set;}
        [Required]
        [MinLength(5)]
        public string name {get;set;}


        // public Quote(string NAME, string QUOTE){
        //     quote = QUOTE;
        //     name = NAME;
        // }
    }
}