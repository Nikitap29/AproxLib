using AproxLib;
using System;

namespace TestApproximation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var X = new double[] { 1.2, 2.3, 3.4, 4.5, 5.6 };
            foreach (var x in X)
                Console.Write($"{x}, ");
            Console.WriteLine();
            var Y = new double[] { 2.7, 3.8, 4.9, 5.1, 6.2 };
            foreach (var y in Y)
                Console.Write($"{y}, ");
            Console.WriteLine();
            var a = new Approx();
            var mes = a.CalcCoefs2(X, Y);
            Console.WriteLine(mes);
            foreach (var w in a.coefs)
                Console.Write($"{w}, ");
            Console.WriteLine();
            var Z = a.CalcValues(X);
            foreach (var z in Z)
                Console.Write($"{z}, ");
            Console.WriteLine();
            Console.WriteLine("Press Enter");
            Console.ReadLine();
        }
    }
}
