using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared
{
    public class Address
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String City { get; set; }
        public String Street{ get; set; }
        public String State { get; set; }
        public String Zip { get; set; }
        public String Country { get; set; }
    }
}
