using System;

namespace GeoRegisterApp.Models
{
    public class SendObjectBody
    {
        public string DateTime { get; set; }
        public string UserId { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
    }
}
