using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IncidentsByTechnician {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

            // retrieve technician and incident lists from their respective text files
            List<Technician> technicianList = TechnicianDB.GetTechnicians();
            List<Incident> incidentList = IncidentDB.GetIncidents();

            // LINQ expression to query the above lists: returns only incidents that were assigned a technician and closed, then ordered by tech name and date opened
            var closedIncidents = from incident in incidentList
                                  join technician in technicianList
                                  on incident.TechID equals technician.TechID
                                  where incident.DateClosed != null
                                  orderby technician.Name, incident.DateOpened
                                  select new {
                                      technician.Name,
                                      incident.ProductCode,
                                      incident.DateOpened,
                                      incident.DateClosed,
                                      incident.Title
                                  };

            string technicianName = ""; // used below to prevent repetition of technician name display in multiple incidents

            int i = 0; // used below to denote row of listview control for purposes of adding sub-items (i.e. column data)

            foreach (var incident in closedIncidents) {
                // add each technician name, but do not repeat name for multiple incidents closed by that tech
                if (incident.Name != technicianName) {
                    lvIncidents.Items.Add(incident.Name);
                    technicianName = incident.Name;
                }
                else {
                    lvIncidents.Items.Add("");
                }

                // add incident properties as column data for the row specified by index
                lvIncidents.Items[i].SubItems.Add(incident.ProductCode);
                lvIncidents.Items[i].SubItems.Add(incident.DateOpened.ToString());
                lvIncidents.Items[i].SubItems.Add(incident.DateClosed.ToString());
                lvIncidents.Items[i].SubItems.Add(incident.Title);

                i += 1;
            }


        }
    }
}
