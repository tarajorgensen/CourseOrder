﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseOrder.Tests
{
    [TestClass()]
    public class CoursePrereqOrderTests
    {

        //[TestMethod()]
        //public void circularDependenciesTest()
        //{
        //    string[][] test = new string[3][];
        //    test[0] = new string[2];
        //    test[1] = new string[2];
        //    test[2] = new string[2];
        //    test[0][0] = "a";
        //    test[0][1] = "b";
        //    test[1][0] = "b";
        //    test[1][1] = "a";
        //    Assert.("", CoursePrereqOrder.GetPrerequisite(test, test[0][0]));

        //}

        [TestMethod()]
        public void GetPrerequisiteTest()
        {
            string[][] test = new string[4][];
            test[0] = new string[2];
            test[1] = new string[2];
            test[2] = new string[2];
            test[3] = new string[2];


            test[0][0] = "a";
            test[0][1] = "b";
            test[1][0] = "c";
            test[1][1] = "d";
            test[2][0] = "z";
            test[2][1] = "y";
            test[3][0] = "y";
            test[3][1] = "z";
            Assert.AreEqual("b", CoursePrereqOrder.GetPrerequisite(test, test[0][0]));
            Assert.AreEqual("", CoursePrereqOrder.GetPrerequisite(test, test[0][1]));
            Assert.AreEqual("d", CoursePrereqOrder.GetPrerequisite(test, test[1][0]));
            Assert.AreEqual("", CoursePrereqOrder.GetPrerequisite(test, test[1][1]));
            Assert.AreEqual("Invalid Input", CoursePrereqOrder.GetPrerequisite(test, test[2][0]));
        }

        [TestMethod()]
        public void TestCourseSplit()
        {
            string test = @"Introduction to Paper Airplanes: 
Advanced Throwing Techniques: Introduction to Paper Airplanes";
            string[][] array = CoursePrereqOrder.CourseSplit(test);
            Assert.AreEqual(array[0][0], "Introduction to Paper Airplanes");
            Assert.AreEqual(array[0][1], "");
            Assert.AreEqual(array[1][0], "Advanced Throwing Techniques");

            Assert.AreEqual(array[1][1], "Introduction to Paper Airplanes");
        }

        [TestMethod()]
        public void TestCreateFinalOutputString()
        {
            List<string> testList = new List<string>() { "string1", "string2", "string3", "string4" };
        }
    }
}