using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentsByTechnician {
    public class Incident {

        public int CustomerID { get; set; }
        public DateTime? DateClosed { get; set; }
        public DateTime DateOpened { get; set; }
        public string Description { get; set; }
        public int IncidentID { get; set; }
        public string ProductCode { get; set; }
        public int? TechID { get; set; }
        public string Title { get; set; }


    }
}
