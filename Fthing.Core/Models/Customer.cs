using System;
using System.Collections.Generic;
using System.Text;

namespace Fthing.Core.Models
{
    public class Customer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Is_married { get; set; }
        public string Address { get; set; }
    }
}
