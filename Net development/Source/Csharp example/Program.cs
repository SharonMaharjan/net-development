using System.Diagnostics;
using static System.Math;


//1a. Create a variable courseName that contains the test '.Net development'
string courseName = ".Net Development";

//1b. Show this variable in the console
Console.WriteLine(courseName);

//1c. Show this variable in the output window using WriteLine from Trace class
Trace.WriteLine(courseName);

//2a. Create a constant variable 'students' containing the value 36
const int students = 36;

//2b. Log the test 'Number of students: 36'
Trace.WriteLine("Number of students"+students);
Trace.WriteLine($"Number of students:{ students}");

//3a. Create the variable 'pi'
double pi = Math.PI;

//3b. Log the test '3.14 is the famous pi number'
Trace.WriteLine(Math.Round(pi,2)+"is the famous pi number");

//4a. Create a boolean 'passed' with value true
//4b. if passed then log 'Pass' otherwise 'Fail'
bool passed = true;
if (passed)
{
    Trace.WriteLine("Passed");
}
else
{
    Trace.WriteLine("Failed");
}

//5a. Set a variable "result" to 8
int result = 8;
//5b. <8: Failed
if (result <8)
{
    Trace.WriteLine("Failed");
}
//5c. between 8 and 10: Tolerable
else if (result>8 && result<10)
{
    Trace.WriteLine("Tolerable");

}
//5d. >10:Passed
else if (result>10)
{
    Trace.WriteLine("Passed");
}

//6a. Create variable color with content 'Green'
string colour = "Green";
switch (colour) 
{
    case "Green":
        Trace.WriteLine("Green");
        break;
    case "Orange":
        Trace.WriteLine("Pay attention");
        break;
    default:
        Trace.WriteLine("Stop");
        break ;

}
