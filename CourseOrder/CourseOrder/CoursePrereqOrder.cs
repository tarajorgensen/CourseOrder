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
TestOne: Introduction to Paper Airplanes
TestTwo: TestOne
History of Cubicle Siege Engines: Rubber Band Catapults 101
Advanced Office Warfare: History of Cubicle Siege Engines
Rubber Band Catapults 101: 
Paper Jet Engines: Introduction to Paper Airplanes";

            //Console.WriteLine("Please enter your list of courses");
            //string userInput = Console.ReadLine();

            var splitCourses = CourseSplit(test);
            List<string> finalOrderDuplicates = new List<string>();
            foreach(string[] course in splitCourses)
            {
                string prerequisite = GetPrerequisite(splitCourses, course[0]);
                if (prerequisite != "")
                {
                    finalOrderDuplicates.Add(prerequisite);
                    finalOrderDuplicates.Add(course[0]);
                }
                else
                {
                    finalOrderDuplicates.Insert(0,course[0]);
                }
            }
            List<string> FinalOrdernoDuplicates = finalOrderDuplicates.Distinct().ToList();
        Console.ReadLine();
        }
  

        public static string[][] CourseSplit(string input)
        {
            return Regex.Split(input, "\r\n").Select(t => Regex.Split(t, ": ")).ToArray();
        }

        public static string GetPrerequisite(string[][] courses, string course)
        {
            string prerequisite = "";
            foreach (string[] item in courses)
            {
                if (item[0] == course && item[1] != "")
                {
                    prerequisite = item[1];
                    GetPrerequisite(courses, prerequisite);
                }
            }
            if(course == prerequisite)
            {
                throw new Exception();
            }
            return prerequisite;
        }
    }
}