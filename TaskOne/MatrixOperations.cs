using System;

namespace TaskOne
{
    public partial class MyMatrix
    {
        // USE EXCEPTIONS TO AVOID PROGRAM CRASHING

        // ---OPERATORS---

        // operator + (sum only if the same length)
        public static MyMatrix operator +(MyMatrix matrix1, MyMatrix matrix2)
        {
            if (matrix1.Height == matrix2.Height &&
                matrix1.Width == matrix2.Width)
            {
                double[,] matrixFinal = new double[matrix1.Height, matrix1.Width];

                for (int row = 0; row < matrix1.Height; row++)
                {
                    for (int column = 0; column < matrix1.Width; column++)
                    {
                        matrixFinal[row, column] = matrix1[row, column] + matrix2[row, column];
                    }
                }

                return new MyMatrix(matrixFinal);
            }
            else
            {
                throw new Exception("Impossible to sum matrices of different dimensions");
            }
        }

        // operator * (multiply only if the same 1st_columns and 2nd_rows length)
        public static MyMatrix operator *(MyMatrix matrix1, MyMatrix matrix2)
        {
            if(matrix1.Width == matrix2.Height)
            {
                double[,] matrixFinal = new double[matrix1.Height, matrix2.Width];

                for (int row = 0; row < matrix1.Height; row++)
                {
                    for (int column = 0; column < matrix2.Width; column++)
                    {
                        int localRow = 0;
                        int localColumn = 0;
                        double cellValue = 0;

                        while (localColumn < matrix1.Width)
                        {
                            cellValue += matrix1[row, localColumn] * matrix2[localRow, column];

                            localRow++;
                            localColumn++;
                        }

                        matrixFinal[row, column] = cellValue;
                    }
                }

                return new MyMatrix(matrixFinal);
            }
            else
            {
                throw new Exception("Impossible to multiply given matrices because of different 1st matrix row / 2nd matrix column dimensions");
            }
        }

        // ---METHODS---

        // method GetTransponedArray() return new double[,]
        private double[,] GetTransponedArray()
        {
            double[,] matrixTransponed = new double[this.matrix.GetLength(1), this.matrix.GetLength(0)];

            for (int row = 0; row < matrixTransponed.GetLength(0); row++)
            {
                for (int column = 0; column < matrixTransponed.GetLength(1); column++)
                {
                    matrixTransponed[row, column] = this.matrix[column, row];
                }
            }
            
            return matrixTransponed;
        }

        // method GetTransponedCopy() return new MyMatrix() (use GetTranspnedArray() inside)
        public MyMatrix GetTransponedCopy()
        {
            return new MyMatrix(this.GetTransponedArray());
        }

        // method void TransponedMe() transpones its matrix field (use GetTranspnedArray() inside)
        public void TransponedMe()
        {
            this.matrix = GetTransponedArray();
        }

        // ---BONUS---

        // method CalcDeterminant() only for square matrix

        public double CalcDeterminant()
        {
            if (this.matrix.GetLength(0) == this.matrix.GetLength(1))
            {
                double determinant = MatrixDeterminantSub(this.matrix);

                return determinant;
            }
            else
            {
                throw new Exception("Impossible to calculate determinant of non-rectangular matrix");
            }
        }
        private double MatrixDeterminantSub(double[,] matrixGiven)
        {
            if (matrixGiven.GetLength(0) == 1)
            {
                return matrixGiven[0, 0];
            }
            else if (matrixGiven.GetLength(0) == 2)
            {
                return matrixGiven[0, 0] * matrixGiven[1, 1] - matrixGiven[0, 1] * matrixGiven[1, 0];
            }
            else
            {
                double currentMatrixDeterminant = 0;

                for (int column = 0; column < matrixGiven.GetLength(0); column++)
                {
                    double[,] matrixGivenSub = new double[matrixGiven.GetLength(0) - 1, matrixGiven.GetLength(0) - 1];

                    for (int rowLocal = 1; rowLocal < matrixGiven.GetLength(0) - 1; rowLocal++)
                    {
                        for (int columnLocal = 0; columnLocal < column; columnLocal++)
                        {
                            matrixGivenSub[rowLocal, columnLocal] = matrixGiven[rowLocal, columnLocal];
                        }

                        for (int columnLocal = column + 1; columnLocal < matrixGiven.GetLength(0); columnLocal++)
                        {
                            matrixGivenSub[rowLocal, columnLocal - 1] = matrixGiven[rowLocal, columnLocal];
                        }
                    }

                    currentMatrixDeterminant += matrixGiven[0, column] * Math.Pow(-1, 1 + (column + 1)) * MatrixDeterminantSub(matrixGivenSub);
                }

                return currentMatrixDeterminant;
            }
        }
    }
}
