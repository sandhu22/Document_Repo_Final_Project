using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Document_Repo_Final_Project.Models
{
    public class DocumentLog
    {
        public int Id { get; set; }

        public int DocumentId { get; set; }

        public Document Document { get; set; }

        public DateTime Time { get; set; }

        public Operation Operation { get; set; }

    }


    public enum Operation { 
        
        CREATED, UPDATED, DELETED
    
    }
}
