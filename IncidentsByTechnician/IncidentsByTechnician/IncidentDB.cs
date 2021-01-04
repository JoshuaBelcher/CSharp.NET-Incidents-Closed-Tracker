using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IncidentsByTechnician
    {
    public static class IncidentDB
    {
        private const string Dir = @"..\\..\\";
        private const string Path = Dir + "Incidents.txt";
        //private const string Path = "Incidents.txt";

        public static List<Incident> GetIncidents()
        {
            List<Incident> incidents = new List<Incident>();

            StreamReader textIn = new StreamReader(
                new FileStream(Path, FileMode.Open, FileAccess.Read));

            while (textIn.Peek() != -1)
            {
                string row = textIn.ReadLine();
                string[] columns = row.Split('|');
                Incident incident = new Incident();
                incident.IncidentID = Convert.ToInt32(columns[0]);
                incident.CustomerID = Convert.ToInt32(columns[1]);
                incident.ProductCode = columns[2];
                if (columns[3] == "")
                    incident.TechID = null;
                else
                    incident.TechID = Convert.ToInt32(columns[3]);
                incident.DateOpened = Convert.ToDateTime(columns[4]);
                if (columns[5] == "")
                    incident.DateClosed = null;
                else
                    incident.DateClosed = Convert.ToDateTime(columns[5]);
                incident.Title = columns[6];
                incident.Description = columns[7];
                incidents.Add(incident);
            }

            textIn.Close();
            return incidents;
        }
    }
}
