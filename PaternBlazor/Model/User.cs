using System;
using System.ComponentModel.DataAnnotations;

namespace PaternBlazor.Model
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
