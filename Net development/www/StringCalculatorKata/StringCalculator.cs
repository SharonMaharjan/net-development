using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public  int Add(string numbers)
        {
            if(numbers == String.Empty) 
            { return 0; }
            string []array=numbers.Split(',');
            int total = 0;
            for (int i = 0; i < array.Length; i++)
            {
                total+=int.Parse(array[i]);
            }
            return total;
            //return int.Parse(numbers);
        }
    }
}
