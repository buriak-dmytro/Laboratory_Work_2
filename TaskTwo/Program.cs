using System;

namespace TaskTwo
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter numerator of first fraction: ");
            long nom1 = long.Parse(Console.ReadLine());
            Console.Write("Enter denominator of first fraction: ");
            long denom1 = long.Parse(Console.ReadLine());
            MyFrac frac1 = new MyFrac(nom1, denom1);

            Console.WriteLine();

            Console.Write("Enter numerator of second fraction: ");
            long nom2 = long.Parse(Console.ReadLine());
            Console.Write("Enter denominator of second fraction: ");
            long denom2 = long.Parse(Console.ReadLine());
            MyFrac frac2 = new MyFrac(nom2, denom2);

            Console.WriteLine();

            Console.WriteLine($"First fraction: {frac1}");
            Console.WriteLine($"Second fraction: {frac2}");

            Console.WriteLine();

            Console.WriteLine($"First fraction with separated integer part: {frac1.ToStringWithIntegerPart()}");
            Console.WriteLine($"Second fraction with separated integer part: {frac2.ToStringWithIntegerPart()}");

            Console.WriteLine();

            Console.WriteLine($"Double value of first fraction: {frac1.DoubleValue()}");
            Console.WriteLine($"Double value of second fraction: {frac2.DoubleValue()}");

            Console.WriteLine();

            Console.WriteLine($"frac1 + frac2: {frac1 + frac2}");
            Console.WriteLine($"frac1 - frac2: {frac1 - frac2}");
            Console.WriteLine($"frac1 * frac2: {frac1 * frac2}");
            Console.WriteLine($"frac1 / frac2: {frac1 / frac2}");

            Console.WriteLine();

            Console.Write("Enter n (number of iterations): ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Calculate defined sum: {MyFrac.CalcDefinedSum(n)}");
            Console.WriteLine($"Calculate defined product: {MyFrac.CalcDefinedProduct(n)}");

            Console.ReadLine();
        }
    }
}
