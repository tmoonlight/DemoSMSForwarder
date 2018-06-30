using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSServer.EFRepo
{
    public class SMSDbContext : DbContext
    {
        public DbSet<SMS> SMS { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=SMS.db");
            //optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ContentYardDB;Integrated Security=True");
        }
    }

    public class SMS
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Sender { get; set; }
        public DateTime SendTime { get; set; }
        public string UserCode { get; set; }
        //public string Receiver { get; set; }
    }

}
