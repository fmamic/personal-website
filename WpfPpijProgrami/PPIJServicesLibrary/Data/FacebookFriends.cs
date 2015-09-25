using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPIJServicesLibrary.Data
{
    public class FacebookFriends
    {

        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string gender;

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        private string date;

        public string Date
        {
            get { return date; }
            set { date = value;}
        }
    }
}
