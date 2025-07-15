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
        public bool FilterByDate { get; set; } = true;
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
