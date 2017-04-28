using System;
using System.Runtime.InteropServices.ComTypes;

namespace LINQ.Demo
{
    public class User
    {
        public string FullName { get; set; }
        public string EMail { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }

        public override string ToString()
        {
            return $"{FullName}, {EMail}, from {Zip} in {Country}";
        }
    }
}
