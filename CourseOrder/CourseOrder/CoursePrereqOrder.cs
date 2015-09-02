using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



namespace CourseOrder
{
    public class CoursePrereqOrder
    {
        public static void Main()
        {
            string test = @"Introduction to Paper Airplanes: 
Advanced Throwing Techniques: Introduction to Paper Airplanes
History of Cubicle Siege Engines: Rubber Band Catapults 101
Advanced Office Warfare: History of Cubicle Siege Engines 
Rubber Band Catapults 101: 
Paper Jet Engines: Introduction to Paper Airplanes";

            //test = test.Replace("\n", "");
            //Console.WriteLine("Please enter your list of courses");
            //string userInput = Console.ReadLine();
            var splitCourses = CourseSplit(test);
            foreach (string[] course in splitCourses)
            {
                Swap(ref course[0], ref course[1]);
            }
        }

        public static string[][] CourseSplit(string input)
        {
            return Regex.Split(input, "\r\n").Select(t => Regex.Split(t, ": ")).ToArray();
            //List<string> courseGroup = new List<string>(courses);
        }

        public static void Swap(ref string a, ref string b)
        {
            string temp = a;
            a = b;
            b = temp;
        }

        public static bool HasPrerequisite(ref string course)
        {
            throw new NotImplementedException();
        }
    }
}




//  foreach (string n in s)
//  {
//    Console.WriteLine(n + ',');

//  }
//  Console.WriteLine(s);
//}
//return String.Empty;