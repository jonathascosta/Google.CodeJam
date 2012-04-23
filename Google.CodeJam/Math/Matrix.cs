using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Google.CodeJam.MathExtensions
{
    public class Matrix
    {
        private BigInteger[,] matrix;
        public int RowCount { get; private set; }
        public int ColumnCount { get; private set; }

        public Matrix(int rows, int columns)            
        {
            this.RowCount = rows;
            this.ColumnCount = columns;
            this.matrix = new BigInteger[rows, columns];
        }

        public Matrix(BigInteger[,] matrix)
        {
            this.RowCount = matrix.GetLength(0);
            this.ColumnCount = matrix.GetLength(1);
            this.matrix = matrix;
        }

        public BigInteger this[int a, int b]
        {
            get
            {
                return this.matrix[a, b];
            }
            set
            {
                this.matrix[a, b] = value;
            }
        }

        public static Matrix operator *(Matrix A, Matrix B)
        {
            if (B.RowCount != A.ColumnCount)
                throw new InvalidOperationException();

            var C = new Matrix(A.RowCount, B.ColumnCount);
            for (int i = 0; i < A.RowCount; i++)
                for (int j = 0; j < B.ColumnCount; j++)
                    for (int k = 0; k < B.RowCount; k++)
                        C[i, j] += A[i, k] * B[k, j];

            return C;
        }

        public static Matrix Pow(Matrix A, int n)
        {
            if (n == 1)
                return A;
            else
            {
                var B = Pow(A, n / 2);
                if (n % 2 == 0)
                    return B * B;
                else
                    return B * B * A;
            }
        }
    }
}
