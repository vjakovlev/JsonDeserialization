using System;
using System.Collections.Generic;
using System.Text;

namespace JsonConverter
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public List<Adress> Adress { get; set; }
        public List<string> Roles { get; set; }
    }
}
