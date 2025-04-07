using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieReviewPortal.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string UserId { get; set; }
        public int Rating { get; set; }
        public string Text { get; set; }

        public virtual Movie Movie { get; set; }
    }
}