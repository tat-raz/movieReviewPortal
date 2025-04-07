using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieReviewPortal.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Login { get; set; }

        [StringLength(256)]
        public string Password { get; set; }
    }
}