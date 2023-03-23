using Matrices = Matrix2D;
using System;
namespace Program
{
    class Program
    {
        static void Main()
        {
            var m1 = new Matrices.Matrix2D();
            var m2 = new Matrices.Matrix2D(7, 5, 6, 3);
            var m3 = new Matrices.Matrix2D(2, 1, 5, 1);

            Console.WriteLine(m2 * m3);
        }
    }
}