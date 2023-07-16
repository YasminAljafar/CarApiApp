using CarApiApp.Models;

namespace CarApiApp.ViewModels
{
    public class CarForCreate
    {
        public string Model { get; set; }
        public int Year { get; set; }
        public int Gear { get; set; }
        public double Km { get; set; }
    }
}
