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

            //Console.WriteLine("Please enter your list of courses");
            //string userInput = Console.ReadLine();

            var splitCourses = CourseSplit(test);
            List<string> finalOrder = new List<string>();
            foreach (string[] course in splitCourses)
            {
                GetPrerequisite(splitCourses, course[0]);
            }
        }

        public static string[][] CourseSplit(string input)
        {
            return Regex.Split(input, "\r\n").Select(t => Regex.Split(t, ": ")).ToArray();
            //List<string> courseGroup = new List<string>(courses);
        }

        public static string GetPrerequisite(string[][] courses, string course)
        {
            string prerequisite = "";
            foreach (string[] item in courses)
            {
                if (item[0] == course && item[1] != "")
                {
                    prerequisite = item[1];
                }
            }
            return prerequisite;
        }
    }
}