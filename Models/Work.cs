using System;
namespace examplewebapi.Models {
    public class Work{

        public int WorkID { get; set; }
        public virtual Artist Artist { get; set; }
        public DateTime CreationDate { get; set; }
        public string MediaType { get; set; }
        public string ImageUrl { get; set; }

    }
}