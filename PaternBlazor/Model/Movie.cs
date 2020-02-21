using System;
using System.ComponentModel.DataAnnotations;

namespace PaternBlazor.Model
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Price { get; set; }
    }
}
