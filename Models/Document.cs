using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Document_Repo_Final_Project.Models
{
    public class Document
    {
        public int Id { get; set; }

        public string DocumentName { get; set; }

        public string DocumentUrl { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }

        public int PublisherId { get; set; }

        public Publisher Publisher { get; set; }

        public DateTime Modified { get; set; }

        

    }
}
