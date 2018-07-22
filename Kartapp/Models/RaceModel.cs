using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kartapp.Models
{
    public class RaceModel
    {

        public int ID { get; set; }
        public string Title { get; set; }
        public string Local { get; set; }
        public DateTime EventDate { get; set; }
        public string Type { get; set; } //Normal or Joker

    }
}
