using System;
using System.Collections.Generic;
using CourseOrder;
using NUnit.Framework;

namespace CoursePrereqOrderTests
{
    [TestFixture]
    public class CoursePrereqOrderTests
    {
        [Test]
        public void GetPrerequisitesTests()
        {
            string[][] test = new string[4][];
            test[0] = new string[2];
            test[1] = new string[2];
            test[2] = new string[2];
            test[3] = new string[2];
            test[0][0] = "a";
            test[0][1] = "b";
            test[1][0] = "b";
            test[1][1] = "c";
            test[2][0] = "z";
            test[2][1] = "y";
            test[3][0] = "y";
            test[3][1] = "z";
            Assert.AreEqual("b", CoursePrereqOrder.GetPrerequisites(test, test[0][0]));
            Assert.AreEqual("c", CoursePrereqOrder.GetPrerequisites(test, test[0][1]));
            Assert.AreEqual("c", CoursePrereqOrder.GetPrerequisites(test, test[1][0]));
            Assert.AreEqual("", CoursePrereqOrder.GetPrerequisites(test, test[1][1]));

            try
            {
                CoursePrereqOrder.GetPrerequisites(test, test[2][0]);
                Assert.Fail();
            }
            catch (Exception e)
            {

            }
        }

        [Test]
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

        [Test]
        public void TestCreateFinalOutputString()
        {
            List<string> testList = new List<string>() { "string1", "string2", "string3", "string4" };
        }
    }
}