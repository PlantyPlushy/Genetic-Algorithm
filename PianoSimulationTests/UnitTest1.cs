using Microsoft.VisualStudio.TestTools.UnitTesting;
using PianoSimulator;
using System;
namespace PianoSimulationTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void fillTest()
        {
            CircularArray ca = new CircularArray(5);
            double[] darr = {1,2,3,4,5};
            ca.Fill(darr);
            for (int i = 0; i < darr.Length; i++)
            {
                Assert.AreEqual(darr[i], ca[i]);
            }
        }
         
         [TestMethod]
         public void fillExceptionTest(){
            CircularArray ca = new CircularArray(5);
            double[] darr = {1,2,3,4};
            Assert.ThrowsException<IndexOutOfRangeException>(() => ca.Fill(darr));
         }
        [TestMethod]
        public void shiftRemovedTest(){
            CircularArray ca = new CircularArray(5);
            double[] darr = {1,2,3,4,5};
            ca.Fill(darr);
            double removedd = ca.Shift(10);
            Assert.AreEqual(1, removedd);
        }
        [TestMethod]
        public void shiftFrontOfArrTest(){
            CircularArray ca = new CircularArray(5);
            double[] darr = {1,2,3,4,5};
            ca.Fill(darr);
            double removedd = ca.Shift(10);
            Assert.AreEqual(2, ca[0]);
        }
        [TestMethod]
        public void shiftEndOfArrTest(){
            CircularArray ca = new CircularArray(5);
            double[] darr = {1,2,3,4,5};
            ca.Fill(darr);
            double removedd = ca.Shift(10);
            Assert.AreEqual(10, ca[4]);
        }
        [TestMethod]
        public void shiftFrontOfArrOverflowTest(){
            CircularArray ca = new CircularArray(5);
            double[] darr = {1,2,3,4,5};
            ca.Fill(darr);
            ca.Shift(10);
            ca.Shift(10);
            ca.Shift(10);
            ca.Shift(10);
            ca.Shift(10);
            ca.Shift(10);
        }
    }
}
