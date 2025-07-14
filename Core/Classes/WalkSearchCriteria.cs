using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalker.Core.Classes
{
    public class WalkSearchCriteria
    {
        public string ClientName { get; set; } = "";
        public string DogName { get; set; } = "";
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
