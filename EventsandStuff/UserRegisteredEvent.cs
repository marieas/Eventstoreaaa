using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsandStuff
{
    internal class UserRegisteredEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }

        public UserRegisteredEvent(int id, string name, bool isAdmin)
        {
            Id = id;
            Name = name;
            IsAdmin = isAdmin; 
        }
    }
}
