namespace MatrixPositions {
    class Program {
        static void Main(string[] args) {
            int rows, columns;

            do {
                Console.Write("Enter Matrix rows: ");
                int.TryParse(Console.ReadLine(), out rows);
                Console.Write("Enter Matrix columns: ");
                int.TryParse(Console.ReadLine(), out columns);

                if (rows <= 1) {
                    Console.WriteLine("The row must be a number greater than 1");
                }
                if (columns <= 1) {
                    Console.WriteLine("The column must be a number greater than 1");
                }
            } while (rows <= 1 || columns <= 1);

            string[] values;
            int[,] matrix = new int[rows, columns];

            for (int i = 1; i <= matrix.GetLength(0); i++) {
                do {
                    Console.Write($"Enter {columns} values separated by space (line #{i}): ");
                    values = Console.ReadLine().Split(" ");

                    if (values.Any(x => x.Any(char.IsLetter)) || values.Any(x => x.Any(y => char.IsPunctuation(y) && y != '-')) || values.Any(x => x.Any(char.IsSymbol))) {
                        Console.WriteLine("Enter numbers only.");
                        continue;
                    }
                    if (values.Any(x => x[0] == '-' && (x.Length == 1 || !x.Skip(1).All(char.IsDigit)))) {
                        Console.WriteLine("Invalid number.");
                        continue;
                    }
                    if (values.Length != columns) {
                        Console.WriteLine($"You must enter {columns} values.");
                    }

                } while (values.Length != columns || values.Any(x => x.Any(char.IsLetter)) || values.Any(x => x.Any(y => char.IsPunctuation(y) && y != '-')) || values.Any(x => x.Any(char.IsSymbol)) || values.Any(x => x[0] == '-' && (x.Length == 1 || !x.Skip(1).All(char.IsDigit))));

                for(int j = 0; j < matrix.GetLength(1); j++) {
                    matrix[i - 1, j] = int.Parse(values[j]);
                }
            }

            Console.WriteLine("------------------------------");
            Console.Write("Matrix: ");
            for (int i = 0; i < matrix.GetLength(0); i++) {
                Console.WriteLine("");
                for (int j = 0; j < matrix.GetLength(1); j++) {
                    Console.Write($"{matrix[i, j]} ");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            int number;

            do {
                Console.Write("Enter a number from the matrix: ");
                int.TryParse(Console.ReadLine(), out number);
                for (int i = 0; i < matrix.GetLength(0); i++) {
                    for (int j = 0; j < matrix.GetLength(1); j++) {
                        if (matrix[i , j] == number) {
                            Console.WriteLine($"Position: {i},{j}");
                            if (j > matrix.GetLowerBound(1)) {
                                Console.WriteLine($"Left: {matrix[i , j - 1]}");
                            }
                            if (j < matrix.GetUpperBound(1)) {
                                Console.WriteLine($"Right: {matrix[i , j + 1]}");
                            }
                            if(i > matrix.GetLowerBound(0)) {
                                Console.WriteLine($"Up: {matrix[i - 1 , j]}");
                            }
                            if(i < matrix.GetUpperBound(0)) {
                                Console.WriteLine($"Down: {matrix[i + 1 , j]}");
                            }
                        }
                    }
                }

                if(!IsInMatrix(matrix, number)) {
                    Console.WriteLine($"There's no {number} in the matrix. Enter another number");
                }
            } while(!IsInMatrix(matrix, number));
        }
        static bool IsInMatrix(int[,] matrix, int number) {
            for(int i = 0; i <= matrix.GetUpperBound(0); i++) {
                for(int j = 0; j <= matrix.GetUpperBound(1); j++) {
                    if(number == matrix[i , j]) {
                        return true;
                    }                    
                }
            }
            return false;
        }
    }
}