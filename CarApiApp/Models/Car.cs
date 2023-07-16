using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApiApp.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Gear { get; set; }
        public double Km { get; set; }
        public Sale? Sale { get; set; }
        public List<Part?> Parts { get; set; }= new List<Part?>();
    }
}
