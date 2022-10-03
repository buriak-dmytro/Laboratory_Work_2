using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TaskOne;

namespace TaskOne_UnitTesting
{
    [TestClass]
    public class TaskOne_UnitTesting
    {
        [TestMethod]
        public void CalcDeterminant_ShouldCalculateAsExpected1()
        {
            // arrange
            double[,] data =
            {
                { 17, -8, 13, 20 },
                { -1, 58, -30, 5 },
                { 3, 7, 19, -9 },
                { 87, -56, 3, 12 },
            };
            MyMatrix matrix = new MyMatrix(data);
            double expected = -2755896;

            // act
            double actual = matrix.CalcDeterminant();

            // assert
            Assert.AreEqual(expected, actual);

        }
    }
}
