using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Document_Repo_Final_Project.Models;

namespace Document_Repo_Final_Project.Models
{
    public class Document_Repo_DataContext : DbContext
    {
        public Document_Repo_DataContext (DbContextOptions<Document_Repo_DataContext> options)
            : base(options)
        {
        }

        public DbSet<Document_Repo_Final_Project.Models.Document> Document { get; set; }

        public DbSet<Document_Repo_Final_Project.Models.DocumentLog> DocumentLog { get; set; }

        public DbSet<Document_Repo_Final_Project.Models.Publisher> Publisher { get; set; }
    }
}
