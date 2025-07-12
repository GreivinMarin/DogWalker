using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker.Core.Entities
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Identification { get; set; }

        public string Phone { get; set; }

        //Computed (not mapped in DB)
        public string FullName => $"{Name} {LastName}";
    }
}
