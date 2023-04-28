using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using UnitTesting;

namespace UnitTestProject
{
    //не нашла аналоги: all, Contains, DoesNotContain, Matches, DoesNotMatch
    [TestClass]
    public class UnitTest1
    {
        //Подтврждениt, что полученное соответсвует ожидаемому. 
        //С помощью длины т.к. массивы можно проверить только с помощью определенного метода.
        [TestMethod]
        public void EqualTestMethod()
        {
            TimeSpan[] startTimes = new TimeSpan[] { new TimeSpan(9, 0, 0), new TimeSpan(10, 0, 0) };
            int[] durations = new int[] { 20, 30 };
            string[] result = Calculations.AvailablePeriods(startTimes, durations, new TimeSpan(8, 0, 0), new TimeSpan(12, 0, 0), 30);
            string[] waitResult = new string[] {"08:00-08:30", "08:30-09:00","09:20-09:50",
                                                "10:30-11:00","11:00-11:30","11:30-12:00" };
            Assert.AreEqual(waitResult.Length, result.Length);
        }

        //Проверка, что если есть занятая консультация в начале рабочего дня, то расписание составляется от ее окончания
        [TestMethod]
        public void AreNotEqualTestMethod()
        {
            TimeSpan[] startTimes = new TimeSpan[] { new TimeSpan(8, 0, 0), new TimeSpan(10, 0, 0) };
            int[] durations = new int[] { 20, 30 };
            string[] result = Calculations.AvailablePeriods(startTimes, durations, new TimeSpan(8, 0, 0), new TimeSpan(12, 0, 0), 30);
            Assert.AreNotEqual(("08:00-08:30"), result[0]);
        }
        //Проверка соотвтсвия полученного ожидаемому с помощью специального метода
        [TestMethod]
        public void TrueTestMethod()
        {
            TimeSpan[] startTimes = new TimeSpan[] { new TimeSpan(9, 0, 0), new TimeSpan(10, 0, 0) };
            int[] durations = new int[] { 20, 30 };
            string[] result = Calculations.AvailablePeriods(startTimes, durations, new TimeSpan(8, 0, 0), new TimeSpan(12, 0, 0), 30);
            string[] waitResult = new string[] {"08:00-08:30", "08:30-09:00","09:20-09:50",
                                                "10:30-11:00","11:00-11:30","11:30-12:00" };

            Assert.IsTrue(result.SequenceEqual(waitResult));
        }

        //Проверка, что есть занятая консультация в конце рабочего дня и она не внесена в 
        [TestMethod]
        public void FalseTestMethod()
        {
            TimeSpan[] startTimes = new TimeSpan[] { new TimeSpan(11, 30, 0)};
            int[] durations = new int[] { 20 };
            string[] result = Calculations.AvailablePeriods(startTimes, durations, new TimeSpan(8, 0, 0), new TimeSpan(12, 0, 0), 30);
            Assert.IsFalse("11:30-12:00" == result[result.Length-1]);
        }

        //Проверка, что возвращается массив строк 
        [TestMethod]
        public void IsInstanceOfTypeTestMethod()
        {
            TimeSpan[] startTimes = new TimeSpan[] { new TimeSpan(9, 0, 0), new TimeSpan(10, 0, 0) };
            int[] durations = new int[] { 20, 30 };
            object result = Calculations.AvailablePeriods(startTimes, durations, new TimeSpan(8, 0, 0), new TimeSpan(12, 0, 0), 30);
            Assert.IsInstanceOfType(result, typeof(string[]));
        }

        //Проверка, что возвращается не просто строка
        [TestMethod]
        public void IsNotInstanceOfTypeTestMethod()
        {
            TimeSpan[] startTimes = new TimeSpan[] { new TimeSpan(9, 0, 0), new TimeSpan(10, 0, 0) };
            int[] durations = new int[] { 20, 30 };
            string[] result = Calculations.AvailablePeriods(startTimes, durations, new TimeSpan(8, 0, 0), new TimeSpan(12, 0, 0), 30);
            Assert.IsNotInstanceOfType(result, typeof(string));
        }


        //Проверка, что что метод не работает, когда время консультаций представлено не по порядку
        [TestMethod]
        public void IsNullTestMethod()
        {
            TimeSpan[] startTimes = new TimeSpan[] { new TimeSpan(10, 0, 0) , new TimeSpan(8, 0, 0) };
            int[] durations = new int[] { 60, 30 };
            string[] result = Calculations.AvailablePeriods(startTimes, durations, new TimeSpan(8, 0, 0), new TimeSpan(12, 0, 0), 30);
            Assert.IsNull(result.Length);
        }

        //Проверка, что что метод в принципе запускается
        [TestMethod]
        public void IsNotNullTestMethod()
        {
            TimeSpan[] startTimes = new TimeSpan[] { new TimeSpan(8, 0, 0), new TimeSpan(10, 0, 0) };
            int[] durations = new int[] { 60, 30 };
            string[] result = Calculations.AvailablePeriods(startTimes, durations, new TimeSpan(8, 0, 0), new TimeSpan(12, 0, 0), 30);
            Assert.IsNotNull(result);
        }

        //Честно, не знаю что он может проверять в данной ситуации
        [TestMethod]
        public void SameTestTestMethod()
        {
            TimeSpan[] startTimes = new TimeSpan[] { new TimeSpan(8, 0, 0), new TimeSpan(10, 0, 0) };
            int[] durations = new int[] { 60, 30 };
            string[] result = Calculations.AvailablePeriods(startTimes, durations, new TimeSpan(8, 0, 0), new TimeSpan(12, 0, 0), 30);
            Assert.AreSame(result, Calculations.AvailablePeriods(startTimes, durations, new TimeSpan(8, 0, 0), new TimeSpan(12, 0, 0), 30));
        }

        //Честно, не знаю что он может проверять в данной ситуации
        [TestMethod]
        public void NotSameTestTestMethod()
        {
            TimeSpan[] startTimes = new TimeSpan[] { new TimeSpan(9, 0, 0), new TimeSpan(10, 0, 0) };
            int[] durations = new int[] { 20, 30 };
            string[] result = Calculations.AvailablePeriods(startTimes, durations, new TimeSpan(8, 0, 0), new TimeSpan(12, 0, 0), 30);
            Assert.AreNotSame(result, Calculations.AvailablePeriods(startTimes, durations, new TimeSpan(8, 0, 0), new TimeSpan(12, 0, 0), 30));
        }

        //Проверка, что вызывается исключение индексации при определенных условиях
        [TestMethod]
        public void ThrowsExceptionTestTestMethod()
        {
            TimeSpan[] startTimes = new TimeSpan[] { new TimeSpan(8, 0, 0), new TimeSpan(10, 0, 0) };
            int[] durations = new int[] { 60, 30 };
            //string[] result = Calculations.AvailablePeriods(startTimes, durations, new TimeSpan(8, 0, 0), new TimeSpan(12, 0, 0), 30);
            Assert.ThrowsException<IndexOutOfRangeException>(() => Calculations.AvailablePeriods(startTimes, durations, new TimeSpan(8, 0, 0), new TimeSpan(12, 0, 0), 30));
        }
    }
}
