
using NUnit.Framework;
using CourseOrder;


namespace CoursePrereqOrderTests
{
    [TestFixture]
    public class OrderTests
    {
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

        //[Test]
        //public void TestSwap()
        //{
        //    string[] test = new string[2];
        //    test[0] = "a";
        //    test[1] = "b";
        //    CoursePrereqOrder.Swap(ref test[0], ref test[1]);
        //    Assert.AreEqual("a", test[1]);
        //    Assert.AreEqual("b", test[0]);
        //}
        [Test]
        public void TestHasPrerequisite()
        {
            string[][] test = new string[2][];
            test[0][0] = "a";
            test[0][1] = "b";
            Assert.AreEqual(false, CoursePrereqOrder.HasPrerequisite(test , test[0][1]));
            Assert.AreEqual(true, CoursePrereqOrder.HasPrerequisite(test, test[0][0]));
        }
    }
}
