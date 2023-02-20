using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalBike
{
   
    internal class BikeRental
    {
        List<T> OverviewRentals = new List<T>();
        
    }
    class BikeRental : Material { 
    public void RegisterRent
    {
        if (OverviewRentals.Contains(Serialnumber)==true){
            Console.WriteLine("Item exists!");
        }
            
        else{
            OverviewRentals.Add(new BikeRental());
        }
    public void DeregisterRent
    {
        OverviewRentals.Remove();
    }
}

}
