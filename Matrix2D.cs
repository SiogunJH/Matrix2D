using System;
using System.Collections.Generic;

namespace Matrix2D
{
    public sealed class Matrix2D : IEquatable<Matrix2D>
    {
        // --==## FIELDS & PROPERTIES ##==--
        public readonly double[,] matrixValues = new double[2, 2];

        // --==## TO STRING ##==--
        public override string ToString() => string.Format("[[{0},{1}],[{2},{3}]]", matrixValues[0, 0], matrixValues[0, 1], matrixValues[1, 0], matrixValues[1, 1]);

        // --==## OTHER ##==--
        public override int GetHashCode()
        {
            return HashCode.Combine(matrixValues);
        }

        // --==## METHODS ##==--
        public override bool Equals(object obj)
        {
            // Check for null
            if (obj is null) return false;

            // Test if referencing the same object
            if (Object.ReferenceEquals(this, obj)) return true;

            if (obj is Matrix2D)
                return Equals((Matrix2D)obj);
            return false;
        }

        public bool Equals(Matrix2D other)
        {
            // Check for null
            if (other is null) return false;

            // Compare matrix values
            return (
                this.matrixValues[0, 0] == other.matrixValues[0, 0] &&
                this.matrixValues[1, 0] == other.matrixValues[1, 0] &&
                this.matrixValues[0, 1] == other.matrixValues[0, 1] &&
                this.matrixValues[1, 1] == other.matrixValues[1, 1]
                );
        }

        public Matrix2D Parse(string matrix)
        {
            // Split string
            string[] values = matrix.Split(','); // [[{0},{1}],[{2},{3}]]

            // Discrad if string[] does not match expectations
            if (values.Length != 4) throw new FormatException();
            if (values[0].Length < 3 || values[1].Length < 2 || values[2].Length < 2 || values[3].Length < 3) throw new FormatException();

            //Create double[] of values
            double[] matrixValues = new double[4];
            matrixValues[0] = double.Parse(values[0].Substring(2));
            matrixValues[0] = double.Parse(values[0].Substring(2));
            matrixValues[0] = double.Parse(values[0].Substring(2));
            matrixValues[0] = double.Parse(values[0].Substring(2));

            // Create new matrix 
            return new Matrix2D();
        }

        // --==## OPERATORS ##==--
        public static bool operator !=(Matrix2D matrix1, Matrix2D matrix2)
        {
            return !(
                matrix1.matrixValues[0, 0] == matrix2.matrixValues[0, 0] &&
                matrix1.matrixValues[1, 0] == matrix2.matrixValues[1, 0] &&
                matrix1.matrixValues[0, 1] == matrix2.matrixValues[0, 1] &&
                matrix1.matrixValues[1, 1] == matrix2.matrixValues[1, 1]
                );
        }
        public static bool operator ==(Matrix2D matrix1, Matrix2D matrix2)
        {
            return (
                matrix1.matrixValues[0, 0] == matrix2.matrixValues[0, 0] &&
                matrix1.matrixValues[1, 0] == matrix2.matrixValues[1, 0] &&
                matrix1.matrixValues[0, 1] == matrix2.matrixValues[0, 1] &&
                matrix1.matrixValues[1, 1] == matrix2.matrixValues[1, 1]
                );
        }
        public static Matrix2D operator *(Matrix2D matrix1, Matrix2D matrix2)
        {
            return new Matrix2D(
                matrix1.matrixValues[0, 0] * matrix2.matrixValues[0, 0] + matrix1.matrixValues[0, 1] * matrix2.matrixValues[1, 0],
                matrix1.matrixValues[0, 0] * matrix2.matrixValues[0, 1] + matrix1.matrixValues[0, 1] * matrix2.matrixValues[1, 1],
                matrix1.matrixValues[1, 0] * matrix2.matrixValues[0, 0] + matrix1.matrixValues[1, 1] * matrix2.matrixValues[1, 0],
                matrix1.matrixValues[1, 0] * matrix2.matrixValues[0, 1] + matrix1.matrixValues[1, 1] * matrix2.matrixValues[1, 1]
            );
        }
        public static Matrix2D operator *(double k, Matrix2D matrix)
        {
            return new Matrix2D(
                matrix.matrixValues[0, 0] * k,
                matrix.matrixValues[0, 1] * k,
                matrix.matrixValues[1, 0] * k,
                matrix.matrixValues[1, 1] * k
            );
        }
        public static Matrix2D operator *(Matrix2D matrix, double k)
        {
            return new Matrix2D(
                matrix.matrixValues[0, 0] * k,
                matrix.matrixValues[0, 1] * k,
                matrix.matrixValues[1, 0] * k,
                matrix.matrixValues[1, 1] * k
            );
        }
        public static Matrix2D operator +(Matrix2D matrix1, Matrix2D matrix2)
        {
            return new Matrix2D(
                matrix1.matrixValues[0, 0] + matrix2.matrixValues[0, 0],
                matrix1.matrixValues[0, 1] + matrix2.matrixValues[0, 1],
                matrix1.matrixValues[1, 0] + matrix2.matrixValues[1, 0],
                matrix1.matrixValues[1, 1] + matrix2.matrixValues[1, 1]
            );
        }
        public static Matrix2D operator -(Matrix2D matrix1, Matrix2D matrix2)
        {
            return new Matrix2D(
                matrix1.matrixValues[0, 0] - matrix2.matrixValues[0, 0],
                matrix1.matrixValues[0, 1] - matrix2.matrixValues[0, 1],
                matrix1.matrixValues[1, 0] - matrix2.matrixValues[1, 0],
                matrix1.matrixValues[1, 1] - matrix2.matrixValues[1, 1]
            );
        }
        public static Matrix2D operator -(Matrix2D matrix)
        {
            return new Matrix2D(
                -matrix.matrixValues[0, 0],
                -matrix.matrixValues[0, 1],
                -matrix.matrixValues[1, 0],
                -matrix.matrixValues[1, 1]
            );
        }

        // --==## CONVERSIONS ##==--
        public static explicit operator double[,](Matrix2D matrix)
        {
            return matrix.matrixValues;
        }

        // --==## CONSTRUCTORS ##==--
        public Matrix2D() : this(1, 0, 0, 1) { }
        public Matrix2D(double a, double b, double c, double d)
        {
            // Assign variables
            matrixValues[0, 0] = a;
            matrixValues[0, 1] = b;
            matrixValues[1, 0] = c;
            matrixValues[1, 1] = d;
        }
    }
}