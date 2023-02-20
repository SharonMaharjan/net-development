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
    //dervied class and inherits from Material
    class Bike : Material
    {

        Random rnd = new Random();
        int value = rnd.Next(100, 999);
        public virtual int  Code() {
            return value;
        }
        public override string ToString()
        {
            return serialNumber + description+Code+ReturnRentalPrice;
        }
    }
}
