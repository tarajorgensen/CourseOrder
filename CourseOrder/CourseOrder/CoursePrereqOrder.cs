using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace CourseOrder
{
    public static class CoursePrereqOrder
    {
        public static int count = 0;
        public static void Main()
        {

            //      string test = @"Introduction to Paper Airplanes: 
            //Advanced Throwing Techniques: Introduction to Paper Airplanes
            //History of Cubicle Siege Engines: Rubber Band Catapults 101
            //Advanced Office Warfare: History of Cubicle Siege Engines
            //Rubber Band Catapults 101: 
            //Paper Jet Engines: Introduction to Paper Airplanes";

            //      string testTwo = @"Intro to Arguing on the Internet: Godwin’s Law
            //Understanding Circular Logic: Intro to Arguing on the Internet
            //Godwin’s Law: Understanding Circular Logic";



            Console.WriteLine("Please enter your list of courses");
            string userInput = Console.ReadLine();

            try
            {
                var splitCourses = CourseSplit(userInput);
                List<string> finalOrderDuplicates = new List<string>();

                foreach (string[] course in splitCourses)
                {
                    string prerequisite = GetPrerequisites(splitCourses, course[0]);
                    if (prerequisite != "")
                    {
                        finalOrderDuplicates.Add(prerequisite);
                        finalOrderDuplicates.Add(course[0]);
                    }
                    else
                    {
                        finalOrderDuplicates.Insert(0, course[0]);
                    }
                }

                List<string> FinalOrderNoDuplicates = finalOrderDuplicates.Distinct().ToList();
                string finalListToPrint = CreateFinalOutputString(FinalOrderNoDuplicates, ", ");
                Console.WriteLine("The classes you should take, in order are: \n" + finalListToPrint);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        public static string[][] CourseSplit(string input)
        {
            return Regex.Split(input, "\r\n").Select(t => Regex.Split(t, ": ")).ToArray();
        }
        public static string CreateFinalOutputString(this List<string> source, string separator)
        {
            return string.Join(separator, source);
        }

        public static string GetPrerequisites(string[][] courses, string course)
        {
            string prerequisite = "";


            foreach (string[] item in courses)
            {
                if (item[0] == course && item[1] != "")
                {
                    prerequisite = item[1];
                    count++;
                    if (count > courses.Length + 1)
                    {
                        throw new Exception("Error: Circular Dependencies found (Invalid Input).");
                    }
                    GetPrerequisites(courses, prerequisite);
                }
            }
            return prerequisite;
        }
    }
}