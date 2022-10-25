using BuildSharper.Course401.Models;
using BuildSharper.Course401.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildSharper.Course401.Services
{
    public class DbMessageService : IMessageService
    {
        public string Name => "Database";

        public void Send(string message)
        {
            using (var db = new MessageDbContext())
            {
                db.Message.Add(new Message()
                {
                    MessageText = message,
                    DateSent = DateTime.Now
                });

                db.SaveChanges();
            }
        }
    }
}
