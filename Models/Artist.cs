using System;
using System.Collections.Generic;

namespace examplewebapi.Models {
    public class Artist {

        public int ArtistID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DeathDate { get; set; }
        public virtual List<Work> Works { get; set; }
    }

}