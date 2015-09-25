using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPIJServicesLibrary.Data
{
    public class PpijBoardFriends
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        private string time;

        public string Time
        {
            get { return time; }
            set { this.time = value; }
        }

        private string poruka;

        public string Poruka
        {
            get { return poruka; }
            set { poruka = value; }
        }

        private List<string> poruke;

        public List<string> Poruke
        {
            get { return poruke; }
            set { this.poruke = value; }
        }

        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
