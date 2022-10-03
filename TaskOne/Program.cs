using System;

namespace TaskOne
{
    class Program
    {
        static void Main()
        {
            double[,] data1 = new double[5, 5] 
            {
                { 0, 1, 2, 3, 4 },
                { 5, 6, 7, 8, 9 },
                { 10, 11, 12, 13, 14 },
                { 15, 16, 17, 18, 19 },
                { 20, 21, 22, 23, 24 }
            };
            double[,] data2 = new double[4, 5]
            {
                { 0, 1, 2, 3, 4 },
                { 5, 6, 7, 8, 9 },
                { 10, 11, 12, 13, 14 },
                { 15, 16, 17, 18, 19 }
            };
            double[][] data3 = new double[5][]
            { 
                new double[5] { 0, 1, 2, 3, 4 },
                new double[5] { 5, 6, 7, 8, 9 },
                new double[5] { 10, 11, 12, 13, 14 },
                new double[5] { 15, 16, 17, 18, 19 },
                new double[5] { 20, 21, 22, 23, 24 }
            };
            double[][] data4 = new double[5][]
            {
                new double[5] { 0, 1, 2, 3, 4 },
                new double[4] { 5, 6, 7, 8 },
                new double[5] { 9, 10, 11, 12, 13 },
                new double[3] { 14, 15, 16 },
                new double[5] { 17, 18, 19, 20, 21 }
            };
            string[] data5 = new string[5]
            {
                new string("0 1 2 3 4"),
                new string("5 6 7 8 9"),
                new string("10 11 12 13 14"),
                new string("15 16 17 18 19"),
                new string("20 21 22 23 24")
            };
            string data6 = 
                "0 1 2 3 4 \n" +
                "5 6 7 8 9 \n" +
                "10 11 12 13 14 \n" +
                "15 16 17 18 19 \n" +
                "20 21 22 23 24";
            string[] data7 = new string[5]
            {
                new string("0 1 2 3 4"),
                new string("5 6 7 8"),
                new string("9 10 11 12 13"),
                new string("14 15 16"),
                new string("17 18 19 20 21")
            };
            string data8 =
                "0 1 2 3 4 \n" +
                "5 6 7 8 \n" +
                "9 10 11 12 13 \n" +
                "14 15 16 \n" +
                "17 18 19 20 21";

            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("MatrixData.cs test:");
                    Console.WriteLine();
                    MyMatrix matrix1 = new MyMatrix(data1);
                    Console.WriteLine("Matrix created:");
                    Console.WriteLine(matrix1);
                    Console.WriteLine();
                    Console.WriteLine($"Matrix Height property: {matrix1.Height}");
                    Console.WriteLine($"Matrix Width property: {matrix1.Width}");
                    Console.WriteLine();
                    Console.WriteLine($"Matrix GetHeight() method: {matrix1.GetHeight()}");
                    Console.WriteLine($"Matrix GetWidth() method: {matrix1.GetWidth()}");
                    Console.WriteLine();
                    Console.WriteLine("Change / check Matrix[3, 2] cell to value \"33\" using indexer:");
                    Console.WriteLine($"Matrix[3, 2] now: {matrix1[3, 2]}");
                    matrix1[3, 2] = 33;
                    Console.WriteLine("Matrix[3, 2] cell changed");
                    Console.WriteLine($"Matrix[3, 2] now: {matrix1[3, 2]}");
                    Console.WriteLine();
                    Console.WriteLine("Change / check Matrix[3, 2] cell to value \"44\" using SetCellValue() / GetCellValue() methods:");
                    Console.WriteLine($"Matrix[3, 2] now: {matrix1.GetCellValue(3, 2)}");
                    matrix1.SetCellValue(3, 2, 44);
                    Console.WriteLine("Matrix[3, 2] cell changed");
                    Console.WriteLine($"Matrix[3, 2] now: {matrix1.GetCellValue(3, 2)}");
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("MatrixOperations.cs test:");
                    Console.WriteLine();
                    MyMatrix matrix2 = new MyMatrix(data1);
                    Console.WriteLine("First Matrix created:");
                    Console.WriteLine(matrix2);
                    Console.WriteLine();
                    MyMatrix matrix3 = new MyMatrix(data3);
                    Console.WriteLine("Second Matrix created:");
                    Console.WriteLine(matrix3);
                    Console.WriteLine();
                    Console.WriteLine("Sum matrices:");
                    Console.WriteLine(matrix2 + matrix3);
                    Console.WriteLine();
                    Console.WriteLine("Multiply matrices:");
                    Console.WriteLine(matrix2 * matrix3);
                    Console.WriteLine();
                    Console.WriteLine("Transpose first Matrix using GetTransponedCopy() method:");
                    Console.WriteLine(matrix2.GetTransponedCopy());
                    Console.WriteLine();
                    Console.WriteLine("Transpose first Matrix using TransponedMe() method:");
                    matrix3.TransponedMe();
                    Console.WriteLine(matrix3);
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("CalcDeterminant() method test:");
                    Console.WriteLine();
                    MyMatrix matrix4 = new MyMatrix(data6);
                    Console.WriteLine("Matrix created:");
                    Console.WriteLine(matrix4);
                    Console.WriteLine();
                    Console.WriteLine("Calculate Matrix determinant:");
                    Console.WriteLine(matrix4.CalcDeterminant());
                    break;
            }

            Console.ReadLine();
        }
    }
}
