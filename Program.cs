using System;
using System.Text;

namespace Lab06
{
    public class DifferentMatrixSizesException : Exception
    {
        public DifferentMatrixSizesException()
        {
        }

        public DifferentMatrixSizesException(string message)
            : base(message)
        {
        }

        public DifferentMatrixSizesException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    public class SquareMatrix : IComparable, ICloneable
    {
        public int size { get; set; }
        public double[,] matrix;

        public SquareMatrix(int size)
        {
            this.size = size;
            matrix = new double[this.size, this.size];
            RandomMatrix();
        }

        public SquareMatrix(int size, double[,] twoDimensionalArray)
        {
            this.size = size;
            matrix = twoDimensionalArray;
        }

        public void RandomMatrix()
        {
            Random RandomNumber = new Random();
            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    matrix[rowIndex, columnIndex] = RandomNumber.Next(-10, 10);
                }
            }
        }
        public void NullMatrix()
        {
            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    matrix[rowIndex, columnIndex] = 0;
                }
            }
        }

        public override bool Equals(object other)
        {
            if (other is SquareMatrix)
            {
                var comparedMatrix = other as SquareMatrix;
                if (size != comparedMatrix.size)
                {
                    return false;
                }
                for (int rowIndex = 0; rowIndex < size; ++rowIndex)
                {
                    for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                    {
                        if (matrix[rowIndex, columnIndex] != comparedMatrix.matrix[rowIndex, columnIndex])
                        {
                            return false;
                        }
                    }
                }
                return true;

            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public int CompareTo(object other)
        {
            if (other is SquareMatrix)
            {
                SquareMatrix comparedMatrix = other as SquareMatrix;
                double thisMatrixWeight, comparedMatrixWeight;
                thisMatrixWeight = 0;
                comparedMatrixWeight = 0;
                for (int rowIndex = 0; rowIndex < size; ++rowIndex)
                {
                    for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                    {
                        thisMatrixWeight += matrix[rowIndex, columnIndex];
                    }
                }
                for (int rowIndex = 0; rowIndex < comparedMatrix.size; ++rowIndex)
                {
                    for (int columnIndex = 0; columnIndex < comparedMatrix.size; ++columnIndex)
                    {
                        comparedMatrixWeight += comparedMatrix.matrix[rowIndex, columnIndex];
                    }
                }
                if (thisMatrixWeight == comparedMatrixWeight)
                {
                    return 0;
                }
                else if (thisMatrixWeight < comparedMatrixWeight)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            return -1;
        }

        public static SquareMatrix operator +(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            if (firstMatrix.size != secondMatrix.size)
            {
                throw new DifferentMatrixSizesException("Матрицы не соразмерны");
            }

            int size = firstMatrix.size;
            SquareMatrix resultMatrix = new SquareMatrix(size);
            resultMatrix.NullMatrix();

            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    resultMatrix.matrix[rowIndex, columnIndex] = firstMatrix.matrix[rowIndex, columnIndex] + secondMatrix.matrix[rowIndex, columnIndex];
                }
            }
            return resultMatrix;
        }

        public static SquareMatrix operator -(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            if (firstMatrix.size != secondMatrix.size)
            {
                throw new DifferentMatrixSizesException("Матрицы не соразмерны");
            }

            int size = firstMatrix.size;
            SquareMatrix resultMatrix = new SquareMatrix(size);
            resultMatrix.NullMatrix();

            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    resultMatrix.matrix[rowIndex, columnIndex] = firstMatrix.matrix[rowIndex, columnIndex] - secondMatrix.matrix[rowIndex, columnIndex];
                }
            }
            return resultMatrix;
        }

        public static SquareMatrix operator *(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            if (firstMatrix.size != secondMatrix.size)
            {
                throw new DifferentMatrixSizesException("Матрицы не соразмерны");
            }

            int size = firstMatrix.size;
            SquareMatrix resultMatrix = new SquareMatrix(size);
            resultMatrix.NullMatrix();

            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    resultMatrix.matrix[rowIndex, columnIndex] = firstMatrix.matrix[rowIndex, columnIndex] * secondMatrix.matrix[rowIndex, columnIndex];
                }
            }
            return resultMatrix;
        }

        public static bool operator <(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            int size = firstMatrix.size;
            double firstMatrixWeight = 0, secondMatrixWeight = 0;

            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    firstMatrixWeight += firstMatrix.matrix[rowIndex, columnIndex];
                    secondMatrixWeight += secondMatrix.matrix[rowIndex, columnIndex];
                }
            }

            if (firstMatrixWeight < secondMatrixWeight)
            {
                return true;
            }
            return false;
        }

        public static bool operator >(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            int size = firstMatrix.size;
            double firstMatrixWeight = 0, secondMatrixWeight = 0;

            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    firstMatrixWeight += firstMatrix.matrix[rowIndex, columnIndex];
                    secondMatrixWeight += secondMatrix.matrix[rowIndex, columnIndex];
                }
            }

            if (firstMatrixWeight > secondMatrixWeight)
            {
                return true;
            }
            return false;
        }

        public static bool operator <=(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            int size = firstMatrix.size;
            double firstMatrixWeight = 0, secondMatrixWeight = 0;

            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    firstMatrixWeight += firstMatrix.matrix[rowIndex, columnIndex];
                    secondMatrixWeight += secondMatrix.matrix[rowIndex, columnIndex];
                }
            }

            if (firstMatrixWeight <= secondMatrixWeight)
            {
                return true;
            }
            return false;
        }

        public static bool operator >=(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            int size = firstMatrix.size;
            double firstMatrixWeight = 0, secondMatrixWeight = 0;

            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    firstMatrixWeight += firstMatrix.matrix[rowIndex, columnIndex];
                    secondMatrixWeight += secondMatrix.matrix[rowIndex, columnIndex];
                }
            }

            if (firstMatrixWeight >= secondMatrixWeight)
            {
                return true;
            }
            return false;
        }

        public static bool operator ==(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            int size = firstMatrix.size;
            double firstMatrixWeight = 0, secondMatrixWeight = 0;

            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    firstMatrixWeight += firstMatrix.matrix[rowIndex, columnIndex];
                    secondMatrixWeight += secondMatrix.matrix[rowIndex, columnIndex];
                }
            }

            if (firstMatrixWeight == secondMatrixWeight)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            int size = firstMatrix.size;
            double firstMatrixWeight = 0, secondMatrixWeight = 0;

            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    firstMatrixWeight += firstMatrix.matrix[rowIndex, columnIndex];
                    secondMatrixWeight += secondMatrix.matrix[rowIndex, columnIndex];
                }
            }

            if (firstMatrixWeight != secondMatrixWeight)
            {
                return true;
            }
            return false;
        }

        public static bool operator true(SquareMatrix squareMatrix)
        {
            if (squareMatrix.size != 0)
            {
                return true;
            }
            return false;
        }

        public static bool operator false(SquareMatrix squareMatrix)
        {
            if (squareMatrix.size != 0)
            {
                return false;
            }
            return true;
        }

        public SquareMatrix GetSubMatrix(int columnFromMatrix, SquareMatrix mainMatrix)
        {
            SquareMatrix subMatrix = new SquareMatrix(mainMatrix.size - 1);
            for (int rowIndex = 0; rowIndex < subMatrix.size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < columnFromMatrix; ++columnIndex)
                {
                    subMatrix.matrix[rowIndex, columnIndex] = mainMatrix.matrix[rowIndex + 1, columnIndex + 1];
                }
            }
            return subMatrix;
        }


        public double Determinate(SquareMatrix squareMatrix)
        {
            double realDeterminant = 0;
            Random randNumber = new Random();
            double randomNumber = Convert.ToDouble(randNumber);

            if (squareMatrix.size == 1)
            {
                realDeterminant = squareMatrix.matrix[0, 0];
            }
            else if (squareMatrix.size == 2)
            {
                realDeterminant = squareMatrix.matrix[0, 0] * squareMatrix.matrix[1, 1] - squareMatrix.matrix[0, 1] * squareMatrix.matrix[1, 0];
            }
            else
            {
                for (int columnIndex = 0; columnIndex < squareMatrix.size; ++columnIndex)
                {
                    double minor = Convert.ToDouble(Math.Pow(-1, columnIndex));
                    double ColumnNumber = minor * squareMatrix.matrix[0, columnIndex];
                    SquareMatrix SubMatrix = GetSubMatrix(columnIndex, squareMatrix);

                    realDeterminant += ColumnNumber * Determinate(SubMatrix);
                }
            }

            while (randomNumber != realDeterminant)
            {
                Random newNumber = new Random();
                if (randomNumber == realDeterminant)
                {
                    break;
                }
                else
                {
                    randomNumber += Convert.ToDouble(newNumber);
                }
            }
            return realDeterminant;
        }

        public override string ToString()
        {
            StringBuilder matrixStringBuilder = new StringBuilder();
            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    matrixStringBuilder.AppendFormat("{0, 4} ", matrix[rowIndex, columnIndex]);
                }
                matrixStringBuilder.Append('\n');
            }
            return matrixStringBuilder.ToString();
        }

        public object Clone()
        {
            SquareMatrix clonedMatrix = new SquareMatrix(size);
            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    clonedMatrix.matrix[rowIndex, columnIndex] = matrix[rowIndex, columnIndex];
                }
            }
            return clonedMatrix;
        }

        public SquareMatrix ReverseMatrix()
        {
            double realDeterminant = Determinate(this);
            SquareMatrix reversedMatrix = Clone() as SquareMatrix;
            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    reversedMatrix.matrix[rowIndex, columnIndex] = matrix[rowIndex, columnIndex] * realDeterminant;
                }
            }
            return reversedMatrix;
        }
    }

    public static class ExtensionsMethods
    {
        public static SquareMatrix Transpose(this SquareMatrix squareMatrix, int size)
        {
            SquareMatrix transponatedMatrix = new SquareMatrix(size);
            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    transponatedMatrix.matrix[rowIndex, columnIndex] = squareMatrix.matrix[columnIndex, rowIndex];
                }
            }
            return transponatedMatrix;
        }
        public static double Trace(this SquareMatrix squareMatrix, int size)
        {
            double trace = 0;
            for (int rowAndColumnIndex = 0; rowAndColumnIndex < size; ++rowAndColumnIndex)
            {
                trace += squareMatrix.matrix[rowAndColumnIndex, rowAndColumnIndex];
            }
            return trace;
        }

        public static SquareMatrix ToDiagonalize(this SquareMatrix squareMatrix, int size)
        {
            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    if (rowIndex != columnIndex)
                    {
                        squareMatrix.matrix[rowIndex, columnIndex] = 0;
                    }
                }
            }
            return squareMatrix;
        }
        public static SquareMatrix ToDiagonalizeMatrix(this SquareMatrix squareMatrix, int size)
        {
            DiagonalMatrix diagonalMatrix = delegate (SquareMatrix matrix)
            {
                squareMatrix.ToDiagonalize(size);
            };
            return squareMatrix;
        }
    }

    public delegate void DiagonalMatrix(SquareMatrix matrix);

    class Program
    {
        public static void Main()
        {
            bool isWorking = true;
            string usersChoice;
            int sizeOfMatrix;
            
            do
            {
                Console.WriteLine("Введите команду: '+' - сложить две матрицы, '-' - вычесть одну матрицу из другой, '*' - умножить одну матрицу на другую, " +
                    "'<', '>', '<=', '>=', '=' и '!=' - сравнить две матрицы, 'подматр' - получить подматрицу, 'детерм' - детерминировать матрицу, " +
                    "'инверт' - инвертировать матрицу, 'транспон' - транспонировать матрицу, 'след' - получить след матрицы, 'диагон' - диагонализировать матрицу, 'выход' - выход из программы");
                usersChoice = Console.ReadLine();

                switch (usersChoice)
                {
                    case "+":
                        Console.WriteLine("Введите размер матриц:");
                        sizeOfMatrix = Convert.ToInt32(Console.ReadLine());

                        double[,] valuesInFirstMatrix = new double[sizeOfMatrix, sizeOfMatrix];
                        double[,] valuesInSecondMatrix = new double[sizeOfMatrix, sizeOfMatrix];

                        Console.WriteLine("Введите значения первой матрицы");
                        for(int row = 0; row < sizeOfMatrix; ++row)
                        {
                            for (int column = 0; column < Math.Pow(sizeOfMatrix, 2); ++column)
                            {
                                valuesInFirstMatrix[row, column] = Convert.ToDouble(Console.ReadLine());
                            }
                        }
                        
                        Console.WriteLine("Введите значения второй матрицы");
                        for (int row = 0; row < sizeOfMatrix; ++row)
                        {
                            for (int column = 0; column < Math.Pow(sizeOfMatrix, 2); ++column)
                            {
                                valuesInSecondMatrix[row, column] = Convert.ToDouble(Console.ReadLine());
                            }
                        }
                        
                        SquareMatrix firstMatrix = new SquareMatrix(sizeOfMatrix, valuesInFirstMatrix);
                        SquareMatrix secondMatrix = new SquareMatrix(sizeOfMatrix, valuesInSecondMatrix);

                        Console.WriteLine(firstMatrix + secondMatrix);
                        break;
                    case "-":
                        Console.WriteLine("Введите размер матриц:");
                        sizeOfMatrix = Convert.ToInt32(Console.ReadLine());

                        valuesInFirstMatrix = new double[sizeOfMatrix, sizeOfMatrix];
                        valuesInSecondMatrix = new double[sizeOfMatrix, sizeOfMatrix];

                        Console.WriteLine("Введите значения первой матрицы");
                        for (int row = 0; row < sizeOfMatrix; ++row)
                        {
                            for (int column = 0; column < Math.Pow(sizeOfMatrix, 2); ++column)
                            {
                                valuesInFirstMatrix[row, column] = Convert.ToDouble(Console.ReadLine());
                            }
                        }

                        Console.WriteLine("Введите значения второй матрицы");
                        for (int row = 0; row < sizeOfMatrix; ++row)
                        {
                            for (int column = 0; column < Math.Pow(sizeOfMatrix, 2); ++column)
                            {
                                valuesInSecondMatrix[row, column] = Convert.ToDouble(Console.ReadLine());
                            }
                        }

                        firstMatrix = new SquareMatrix(sizeOfMatrix, valuesInFirstMatrix);
                        secondMatrix = new SquareMatrix(sizeOfMatrix, valuesInSecondMatrix);

                        Console.WriteLine(firstMatrix - secondMatrix);
                        break;
                    case "*":
                        Console.WriteLine("Введите размер матриц:");
                        sizeOfMatrix = Convert.ToInt32(Console.ReadLine());

                        valuesInFirstMatrix = new double[sizeOfMatrix, sizeOfMatrix];
                        valuesInSecondMatrix = new double[sizeOfMatrix, sizeOfMatrix];

                        Console.WriteLine("Введите значения первой матрицы");
                        for (int row = 0; row < sizeOfMatrix; ++row)
                        {
                            for (int column = 0; column < Math.Pow(sizeOfMatrix, 2); ++column)
                            {
                                valuesInFirstMatrix[row, column] = Convert.ToDouble(Console.ReadLine());
                            }
                        }

                        Console.WriteLine("Введите значения второй матрицы");
                        for (int row = 0; row < sizeOfMatrix; ++row)
                        {
                            for (int column = 0; column < Math.Pow(sizeOfMatrix, 2); ++column)
                            {
                                valuesInSecondMatrix[row, column] = Convert.ToDouble(Console.ReadLine());
                            }
                        }

                        firstMatrix = new SquareMatrix(sizeOfMatrix, valuesInFirstMatrix);
                        secondMatrix = new SquareMatrix(sizeOfMatrix, valuesInSecondMatrix);

                        Console.WriteLine(firstMatrix * secondMatrix);
                        break;
                    case ">":
                        Console.WriteLine("Введите размер матриц:");
                        sizeOfMatrix = Convert.ToInt32(Console.ReadLine());

                        valuesInFirstMatrix = new double[sizeOfMatrix, sizeOfMatrix];
                        valuesInSecondMatrix = new double[sizeOfMatrix, sizeOfMatrix];

                        Console.WriteLine("Введите значения первой матрицы");
                        for (int row = 0; row < sizeOfMatrix; ++row)
                        {
                            for (int column = 0; column < Math.Pow(sizeOfMatrix, 2); ++column)
                            {
                                valuesInFirstMatrix[row, column] = Convert.ToDouble(Console.ReadLine());
                            }
                        }

                        Console.WriteLine("Введите значения второй матрицы");
                        for (int row = 0; row < sizeOfMatrix; ++row)
                        {
                            for (int column = 0; column < Math.Pow(sizeOfMatrix, 2); ++column)
                            {
                                valuesInSecondMatrix[row, column] = Convert.ToDouble(Console.ReadLine());
                            }
                        }

                        firstMatrix = new SquareMatrix(sizeOfMatrix, valuesInFirstMatrix);
                        secondMatrix = new SquareMatrix(sizeOfMatrix, valuesInSecondMatrix);

                        Console.WriteLine(firstMatrix > secondMatrix);
                        break;
                    case "<":
                        Console.WriteLine("Введите размер матриц:");
                        sizeOfMatrix = Convert.ToInt32(Console.ReadLine());

                        valuesInFirstMatrix = new double[sizeOfMatrix, sizeOfMatrix];
                        valuesInSecondMatrix = new double[sizeOfMatrix, sizeOfMatrix];

                        Console.WriteLine("Введите значения первой матрицы");
                        for (int row = 0; row < sizeOfMatrix; ++row)
                        {
                            for (int column = 0; column < Math.Pow(sizeOfMatrix, 2); ++column)
                            {
                                valuesInFirstMatrix[row, column] = Convert.ToDouble(Console.ReadLine());
                            }
                        }

                        Console.WriteLine("Введите значения второй матрицы");
                        for (int row = 0; row < sizeOfMatrix; ++row)
                        {
                            for (int column = 0; column < Math.Pow(sizeOfMatrix, 2); ++column)
                            {
                                valuesInSecondMatrix[row, column] = Convert.ToDouble(Console.ReadLine());
                            }
                        }

                        firstMatrix = new SquareMatrix(sizeOfMatrix, valuesInFirstMatrix);
                        secondMatrix = new SquareMatrix(sizeOfMatrix, valuesInSecondMatrix);

                        Console.WriteLine(firstMatrix < secondMatrix);
                        break;
                    case "<=":
                        Console.WriteLine("Введите размер матриц:");
                        sizeOfMatrix = Convert.ToInt32(Console.ReadLine());

                        valuesInFirstMatrix = new double[sizeOfMatrix, sizeOfMatrix];
                        valuesInSecondMatrix = new double[sizeOfMatrix, sizeOfMatrix];

                        Console.WriteLine("Введите значения первой матрицы");
                        for (int row = 0; row < sizeOfMatrix; ++row)
                        {
                            for (int column = 0; column < Math.Pow(sizeOfMatrix, 2); ++column)
                            {
                                valuesInFirstMatrix[row, column] = Convert.ToDouble(Console.ReadLine());
                            }
                        }

                        Console.WriteLine("Введите значения второй матрицы");
                        for (int row = 0; row < sizeOfMatrix; ++row)
                        {
                            for (int column = 0; column < Math.Pow(sizeOfMatrix, 2); ++column)
                            {
                                valuesInSecondMatrix[row, column] = Convert.ToDouble(Console.ReadLine());
                            }
                        }

                        firstMatrix = new SquareMatrix(sizeOfMatrix, valuesInFirstMatrix);
                        secondMatrix = new SquareMatrix(sizeOfMatrix, valuesInSecondMatrix);

                        Console.WriteLine(firstMatrix <= secondMatrix);
                        break;
                    case ">=":
                        Console.WriteLine("Введите размер матриц:");
                        sizeOfMatrix = Convert.ToInt32(Console.ReadLine());

                        valuesInFirstMatrix = new double[sizeOfMatrix, sizeOfMatrix];
                        valuesInSecondMatrix = new double[sizeOfMatrix, sizeOfMatrix];

                        Console.WriteLine("Введите значения первой матрицы");
                        for (int row = 0; row < sizeOfMatrix; ++row)
                        {
                            for (int column = 0; column < Math.Pow(sizeOfMatrix, 2); ++column)
                            {
                                valuesInFirstMatrix[row, column] = Convert.ToDouble(Console.ReadLine());
                            }
                        }

                        Console.WriteLine("Введите значения второй матрицы");
                        for (int row = 0; row < sizeOfMatrix; ++row)
                        {
                            for (int column = 0; column < Math.Pow(sizeOfMatrix, 2); ++column)
                            {
                                valuesInSecondMatrix[row, column] = Convert.ToDouble(Console.ReadLine());
                            }
                        }

                        firstMatrix = new SquareMatrix(sizeOfMatrix, valuesInFirstMatrix);
                        secondMatrix = new SquareMatrix(sizeOfMatrix, valuesInSecondMatrix);

                        Console.WriteLine(firstMatrix >= secondMatrix);
                        break;
                    case "=":
                        Console.WriteLine("Введите размер матриц:");
                        sizeOfMatrix = Convert.ToInt32(Console.ReadLine());

                        valuesInFirstMatrix = new double[sizeOfMatrix, sizeOfMatrix];
                        valuesInSecondMatrix = new double[sizeOfMatrix, sizeOfMatrix];

                        Console.WriteLine("Введите значения первой матрицы");
                        for (int row = 0; row < sizeOfMatrix; ++row)
                        {
                            for (int column = 0; column < Math.Pow(sizeOfMatrix, 2); ++column)
                            {
                                valuesInFirstMatrix[row, column] = Convert.ToDouble(Console.ReadLine());
                            }
                        }

                        Console.WriteLine("Введите значения второй матрицы");
                        for (int row = 0; row < sizeOfMatrix; ++row)
                        {
                            for (int column = 0; column < Math.Pow(sizeOfMatrix, 2); ++column)
                            {
                                valuesInSecondMatrix[row, column] = Convert.ToDouble(Console.ReadLine());
                            }
                        }

                        firstMatrix = new SquareMatrix(sizeOfMatrix, valuesInFirstMatrix);
                        secondMatrix = new SquareMatrix(sizeOfMatrix, valuesInSecondMatrix);

                        Console.WriteLine(firstMatrix == secondMatrix);
                        break;
                    case "!=":
                        Console.WriteLine("Введите размер матриц:");
                        sizeOfMatrix = Convert.ToInt32(Console.ReadLine());

                        valuesInFirstMatrix = new double[sizeOfMatrix, sizeOfMatrix];
                        valuesInSecondMatrix = new double[sizeOfMatrix, sizeOfMatrix];

                        Console.WriteLine("Введите значения первой матрицы");
                        for (int row = 0; row < sizeOfMatrix; ++row)
                        {
                            for (int column = 0; column < Math.Pow(sizeOfMatrix, 2); ++column)
                            {
                                valuesInFirstMatrix[row, column] = Convert.ToDouble(Console.ReadLine());
                            }
                        }

                        Console.WriteLine("Введите значения второй матрицы");
                        for (int row = 0; row < sizeOfMatrix; ++row)
                        {
                            for (int column = 0; column < Math.Pow(sizeOfMatrix, 2); ++column)
                            {
                                valuesInSecondMatrix[row, column] = Convert.ToDouble(Console.ReadLine());
                            }
                        }

                        firstMatrix = new SquareMatrix(sizeOfMatrix, valuesInFirstMatrix);
                        secondMatrix = new SquareMatrix(sizeOfMatrix, valuesInSecondMatrix);

                        Console.WriteLine(firstMatrix != secondMatrix);
                        break;
                    case "подматр":
                        Console.WriteLine("Введите размер матрицы:");
                        sizeOfMatrix = Convert.ToInt32(Console.ReadLine());

                        double [,] valuesInMatrix = new double[sizeOfMatrix, sizeOfMatrix];

                        Console.WriteLine("Введите размер подматрицы:");
                        int sizeOfSubmatrix = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Введите значения матрицы");
                        for (int row = 0; row < sizeOfMatrix; ++row)
                        {
                            for (int column = 0; column < Math.Pow(sizeOfMatrix, 2); ++column)
                            {
                                valuesInMatrix[row, column] = Convert.ToDouble(Console.ReadLine());
                            }
                        }
                        SquareMatrix matrix = new SquareMatrix(sizeOfMatrix, valuesInMatrix);

                        Console.WriteLine(matrix.GetSubMatrix(sizeOfSubmatrix, matrix));
                        break;
                    case "детерм":
                        Console.WriteLine("Введите размер матрицы:");
                        sizeOfMatrix = Convert.ToInt32(Console.ReadLine());

                        valuesInMatrix = new double[sizeOfMatrix, sizeOfMatrix];

                        Console.WriteLine("Введите значения матрицы");
                        for (int row = 0; row < sizeOfMatrix; ++row)
                        {
                            for (int column = 0; column < Math.Pow(sizeOfMatrix, 2); ++column)
                            {
                                valuesInMatrix[row, column] = Convert.ToDouble(Console.ReadLine());
                            }
                        }
                        matrix = new SquareMatrix(sizeOfMatrix, valuesInMatrix);

                        Console.WriteLine(matrix.Determinate(matrix));
                        break;
                    case "инверт":
                        Console.WriteLine("Введите размер матрицы:");
                        sizeOfMatrix = Convert.ToInt32(Console.ReadLine());

                        valuesInMatrix = new double[sizeOfMatrix, sizeOfMatrix];

                        Console.WriteLine("Введите значения матрицы");
                        for (int row = 0; row < sizeOfMatrix; ++row)
                        {
                            for (int column = 0; column < Math.Pow(sizeOfMatrix, 2); ++column)
                            {
                                valuesInMatrix[row, column] = Convert.ToDouble(Console.ReadLine());
                            }
                        }
                        matrix = new SquareMatrix(sizeOfMatrix, valuesInMatrix);

                        Console.WriteLine(matrix.ReverseMatrix());
                        break;
                    case "транспон":
                        Console.WriteLine("Введите размер матрицы:");
                        sizeOfMatrix = Convert.ToInt32(Console.ReadLine());

                        valuesInMatrix = new double[sizeOfMatrix, sizeOfMatrix];

                        Console.WriteLine("Введите значения матрицы");
                        for (int row = 0; row < sizeOfMatrix; ++row)
                        {
                            for (int column = 0; column < Math.Pow(sizeOfMatrix, 2); ++column)
                            {
                                valuesInMatrix[row, column] = Convert.ToDouble(Console.ReadLine());
                            }
                        }
                        matrix = new SquareMatrix(sizeOfMatrix, valuesInMatrix);

                        Console.WriteLine(matrix.Transpose(sizeOfMatrix));
                        break;
                    case "диагон":
                        Console.WriteLine("Введите размер матрицы:");
                        sizeOfMatrix = Convert.ToInt32(Console.ReadLine());

                        valuesInMatrix = new double[sizeOfMatrix, sizeOfMatrix];

                        Console.WriteLine("Введите значения матрицы");
                        for (int row = 0; row < sizeOfMatrix; ++row)
                        {
                            for (int column = 0; column < Math.Pow(sizeOfMatrix, 2); ++column)
                            {
                                valuesInMatrix[row, column] = Convert.ToDouble(Console.ReadLine());
                            }
                        }
                        matrix = new SquareMatrix(sizeOfMatrix, valuesInMatrix);

                        Console.WriteLine(matrix.ToDiagonalizeMatrix(sizeOfMatrix));
                        break;
                    case "след":
                        Console.WriteLine("Введите размер матрицы:");
                        sizeOfMatrix = Convert.ToInt32(Console.ReadLine());

                        valuesInMatrix = new double[sizeOfMatrix, sizeOfMatrix];

                        Console.WriteLine("Введите значения матрицы");
                        for (int row = 0; row < sizeOfMatrix; ++row)
                        {
                            for (int column = 0; column < Math.Pow(sizeOfMatrix, 2); ++column)
                            {
                                valuesInMatrix[row, column] = Convert.ToDouble(Console.ReadLine());
                            }
                        }
                        matrix = new SquareMatrix(sizeOfMatrix, valuesInMatrix);

                        Console.WriteLine(matrix.Trace(sizeOfMatrix));
                        break;
                    case "выход":
                        Console.WriteLine("Вы точно хотите выйти? Напишите 'Да' для выхода");
                        if (Console.ReadLine() == "Да"){
                            isWorking = false;
                        }
                        break;
                    default:
                        Console.WriteLine("Неверная команда. Повторите ввод");
                        break;
                }

            } while (isWorking);
        }
    }
}
