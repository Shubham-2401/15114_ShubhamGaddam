using System;
using NUnit.Framework;
using NUnitDemoLib;

namespace NUnitTestLib
{
    [TestFixture]
    public class CalculatorTest
    {

        //Setup    - Runs before every test method
        //Teardown - Runs after every test method

        Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [TearDown]
        public void Teardown()
        {
            //write code which runs after every test method
        }

        [Test]
        public void Test_Addition_with_Valid_integers()
        {
            Calculator calculator = new Calculator();
            int result = calculator.Addition(5, 8);
            //Assert.AreEqual(expected, actual)
            Assert.AreEqual(13, result);
        }

        //batch testing
        [TestCase(1,2,3)]
        [TestCase(0,0,0)]
        [TestCase(-1,-1,-2)]
        public void Test_Addition_multiple(int first, int second, int expected)
        {
            Calculator calculator = new Calculator();
            int result = calculator.Addition(first, second);
            Assert.AreEqual(expected, result);
        }

        //exception test
        [Test]
        public void Test_Subtraction_ArgumentException()
        {
            Calculator calculator = new Calculator();
            //sub class instance is allowed
            //Assert.Catch<SystemException>(() => calculator.Subtraction(3, 5));

            //exact exception match
            //Assert.Throws<SystemException>(() => calculator.Subtraction(3,5));

            Assert.Throws<ArgumentException>(() => calculator.Subtraction(3, 5));
        }
    }
}
