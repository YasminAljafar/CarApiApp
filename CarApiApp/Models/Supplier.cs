using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApiApp.Models
{
    public class Supplier
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Part?> Part { get; set;}
    }
}
