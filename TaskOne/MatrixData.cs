using System;

namespace TaskOne
{
    public partial class MyMatrix
    {
        // USE EXCEPTIONS TO AVOID PROGRAM CRASHING

        // ---FIELDS---

        // field "matrix" to store the data
        private double[,] matrix;

        // ---CONSTRUCTORS---

        // constructor of copying
        public MyMatrix(MyMatrix matrixCopyFrom)
        {
            this.matrix = matrixCopyFrom.matrix; // why does it work? // or fill this.matrix using indexer of matrixCopyFrom?
        }

        // constructor from double[,]
        public MyMatrix(double[,] passedMatrixData)
        {
            this.matrix = passedMatrixData;
        }

        // constructor from double[][] if it is a rectangle
        public MyMatrix(double[][] passedMatrixData)
        {
            int columnLengthCheckUp = passedMatrixData[0].Length;
            bool columnLengthDiffers = false;
            for (int row = 0; row < passedMatrixData.Length & !columnLengthDiffers; row++)
            {
                if (passedMatrixData[row].Length != columnLengthCheckUp)
                {
                    columnLengthDiffers = true;
                }
            }

            if (!columnLengthDiffers)
            {
                for (int row = 0; row < passedMatrixData.Length; row++)
                {
                    for (int column = 0; column < passedMatrixData[row].Length; column++)
                    {
                        this.matrix[row, column] = passedMatrixData[row][column];
                    }
                }
            }
            else
            {
                throw new Exception("Passed jagged array is not rectangular");
            }
        }

        // constructor from string[] if every row has the same length (it is a rectangle)
        public MyMatrix(string[] passedMatrixData)
        {
            string[] currentRowRawData = passedMatrixData[0].Replace('\t', ' ').Trim().Split();
            int columnLengthCheckUp = currentRowRawData.Length;

            bool columnLengthDiffers = false;

            for (int row = 1; row < passedMatrixData.Length & !columnLengthDiffers; row++)
            {
                currentRowRawData = passedMatrixData[row].Replace('\t', ' ').Trim().Split();

                if (currentRowRawData.Length != columnLengthCheckUp)
                {
                    columnLengthDiffers = true;
                }
            }

            if (!columnLengthDiffers)
            {
                for (int row = 0; row < passedMatrixData.Length; row++)
                {
                    currentRowRawData = passedMatrixData[row].Replace('\t', ' ').Trim().Split();

                    for (int column = 0; column < currentRowRawData.Length; column++)
                    {
                        this.matrix[row, column] = int.Parse(currentRowRawData[column].Trim());
                    }
                }
            }
            else
            {
                throw new Exception("Passed string array represents non-rectangular matrix");
            }
        }

        // constructor from string if it creates (using rules of ' ' | 't/' | 'n/') a rectangular matrix
        public MyMatrix(string passedMatrixData) : this(passedMatrixData.Split('\n')) { } // call constructor for string[]

        // ---PROPERTIES---

        // propertie "Height" to get only
        public int Height
        {
            get { return this.matrix.GetLength(0); }
        }

        // propertie "Width" to get only
        public int Width
        {
            get { return this.matrix.GetLength(1); }
        }

        // ---JAVA-STYLE GETTERS---

        // method "getHeight"
        public int GetHeight()
        {
            return this.matrix.GetLength(0);
        }

        // method "getWidth"
        public int GetWidth()
        {
            return this.matrix.GetLength(1);
        }

        // ---INDEXER---

        // get or set every cell of the matrix (use Exception if needed)
        public double this[int row, int column]
        {
            get 
            {
                if (row < 0 || row >= this.matrix.GetLength(0))
                {
                    throw new Exception("Row index is out of range");
                }
                else if (column < 0 || column >= this.matrix.GetLength(1))
                {
                    throw new Exception("Column index is out of range");
                }
                else
                {
                    return this.matrix[row, column];
                }
            }
            set
            {
                if (row < 0 || row >= this.matrix.GetLength(0))
                {
                    throw new Exception("Row index is out of range");
                }
                else if (column < 0 || column >= this.matrix.GetLength(1))
                {
                    throw new Exception("Column index is out of range");
                }
                else
                {
                    this.matrix[row, column] = value;
                }
            }
        }

        // ---JAVA-STYLE GETTERS AND SETTERS---

        // method to get cell value (param-s: row, column)
        public double GetCellValue(int row, int column)
        {
            if (row < 0 || row >= this.matrix.GetLength(0))
            {
                throw new Exception("Row index is out of range");
            }
            else if (column < 0 || column >= this.matrix.GetLength(1))
            {
                throw new Exception("Column index is out of range");
            }
            else
            {
                return this.matrix[row, column];
            }
        }

        // method to set cell value (param-s: row, column, value)
        public void SetCellValue(int row, int column, double value)
        {
            if (row < 0 || row >= this.matrix.GetLength(0))
            {
                throw new Exception("Row index is out of range");
            }
            else if (column < 0 || column >= this.matrix.GetLength(1))
            {
                throw new Exception("Column index is out of range");
            }
            else
            {
                this.matrix[row, column] = value;
            }
        }

        // ---OVERRIDE TOSTRING---

        // override ToString() method to display matrix in console
        public override string ToString()
        {
            string output = "";
            int[] maxIntPartLengthInColumn = new int[matrix.GetLength(1)];

            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    int currentIntPartLength = ((int)matrix[row, column].ToString().Length);
                    if (currentIntPartLength > maxIntPartLengthInColumn[column])
                    {
                        maxIntPartLengthInColumn[column] = currentIntPartLength;
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    output += String.Format(" {0}{1:#.###}", 
                        new string(' ', maxIntPartLengthInColumn[column] - ((int)matrix[row, column].ToString().Length)),
                        matrix[row, column]);
                }

                output += '\n';
            }

            return output;
        }
    }
}
