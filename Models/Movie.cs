using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieReviewPortal.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}