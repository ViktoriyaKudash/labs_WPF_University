using System;

namespace Healthcare.DataAccess
{
    public class Patient : ModelBase
    {
        public int PatientId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string Home_address { get; set; }
    }
}
