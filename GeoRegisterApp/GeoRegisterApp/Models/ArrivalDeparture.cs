using System;
using System.Collections.Generic;
using System.Text;

namespace GeoRegisterApp.Models
{
    public class ArrivalDeparture
    {
        public string userId { get; set; }
        public string userName { get; set; }
        public string userSurname { get; set; }
        public string dateTime { get; set; }
        public string add { get; set; }
        public string workingPlaceId { get; set; }
        public string workingPlaceName { get; set; }
        public string DisplayName
        {
            get { return userName + " " + userSurname; }
            set
            {
                DisplayName = userName + " " + userSurname;
            }
        }
    }
}
