using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HangfireCourse.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
    }
}
