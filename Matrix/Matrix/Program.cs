namespace Matrix {
    class Program {
        static void Main(string[] args) {
            int order, count = 0;

            do {
                Console.Write("Enter Matrix order: ");
                int.TryParse(Console.ReadLine(), out order);

                if (order <= 1) {
                    Console.WriteLine("The order must be a number greater than 1");
                }
            } while (order <= 1);

            string[] values;
            int[,] matrix = new int[order, order];

            for (int i = 1; i <= matrix.GetLength(0); i++) {                
                do {
                    Console.Write($"Enter {order} values separated by space (line #{i}): ");
                    values = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    
                    if (values.Any(x => x.Any(char.IsLetter)) || values.Any(x => x.Any(y => char.IsPunctuation(y) && y != '-')) || values.Any(x => x.Any(char.IsSymbol))) {
                        Console.WriteLine("Enter numbers only.");
                        continue;
                    }
                    if (values.Any(x => x[0] == '-' && (x.Length == 1 || !x.Skip(1).All(char.IsDigit)))) {
                        Console.WriteLine("Invalid number.");
                        continue;
                    }
                    if (values.Length != order) {
                        Console.WriteLine($"You must enter {order} values.");         
                    }

                } while (values.Length != order || values.Any(x => x.Any(char.IsLetter)) || values.Any(x => x.Any(y => char.IsPunctuation(y) && y != '-')) || values.Any(x => x.Any(char.IsSymbol)) || values.Any(x => x[0] == '-' && (x.Length == 1 || !x.Skip(1).All(char.IsDigit))));

                for (int j = 0; j < matrix.GetLength(1); j++) {
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
            Console.Write("Main Diagonal: ");
            for(int i = 0; i < matrix.GetLength(0); i++) {
                for(int j = 0; j < matrix.GetLength(1); j++){
                    if (j == i) {
                        Console.Write($"{matrix[i,j]} ");
                    }
                    if (matrix[i, j] < 0) {
                        count++;
                    }
                }
            }
           
            Console.WriteLine();
            Console.Write($"Negative numbers: {count}");
        }
    }
}