using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPIJServicesLibrary.Data
{
    public class TwitterUserProfile
    {
        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private decimal id;
        public decimal Id
        {
            get { return id; }
            set { id = value; }
        }
        private string language;
        public string Language
        {
            get { return language; }
            set { language = value; }
        }
        private string location;
        public string Location
        {
            get { return location; }
            set { location = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private long numberOfFriends;
        public long NumberOfFriends
        {
            get { return numberOfFriends; }
            set { numberOfFriends = value; }
        }
        private long numberOfStatuses;
        public long NumberOfStatuses
        {
            get { return numberOfStatuses; }
            set { numberOfStatuses = value; }
        }
        private string profileImageLocation;
        public string ProfileImageLocation
        {
            get { return profileImageLocation; }
            set { profileImageLocation = value; }
        }
        private string profileSecureImageLocation;
        public string ProfileSecureImageLocation
        {
            get { return profileSecureImageLocation; }
            set { profileSecureImageLocation = value; }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        private string screenName;
        public string ScreenName
        {
            get { return screenName; }
            set { screenName = value; }
        }
        private string website;
        public string Website
        {
            get { return website; }
            set { website = value; }
        }
    }
}
