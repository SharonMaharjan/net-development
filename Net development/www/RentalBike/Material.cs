using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalBike
{
    internal class Material
    {
        public string serialNumber { get; set; }
        public string description { get; set; }
        public virtual int ReturnRentalPrice()
        {
            return 100;
        }
    }
    public string SerialNumber
    {
        get { return serialNumber; }

    }
    public Material(string serialNumber,string description)
    {
        SerialNumber = serialNumber;
        Description = description;
    }
    public virtual double R()
    {
        return 100;
    }
    //dervied class and inherits from Material
    public class Bike : Material
    {
        public Bike(string serialNumber,string description):base(serialNumber,description)
        Random rnd = new Random();
        int value = rnd.Next(100, 999);
        public virtual int  Code() {
            return value;
        }
        public override double ToString()
        { 
            return base Rental() = 1.20;
        }
        public override string ToString()
        {
            return serialNumber + description+Code+ReturnRentalPrice;
        }
    }
}
