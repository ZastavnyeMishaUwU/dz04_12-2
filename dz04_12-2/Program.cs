namespace dz04_12_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            File.Create("positive_numbers.txt").Dispose();
            File.Create("negative_numbers.txt").Dispose();
            File.Create("twonumbers.txt").Dispose();
            File.Create("fivenumbers.txt").Dispose();

            CreateLarge("numbers.txt");

            if (File.Exists("numbers.txt"))
            {
                eNumbers("numbers.txt");
                Console.WriteLine("Файл numbers.txt ");
            }
            else
            {
                Console.WriteLine("Файл numbers.txt не знайдено.");
            }
        }

        static void CreateLarge(string file)
        {
            Random random = new Random();
            string[] numbers = Enumerable.Range(0, 100000).Select(_ => random.Next(-99999, 99999).ToString()).ToArray();
            File.WriteAllLines(file, numbers);
            Console.WriteLine($"Файл {file} створено.");
        }

        static void eNumbers(string file)
        {
            var numbers = File.ReadAllLines(file).Select(int.Parse).ToArray();

            var positiveNumbers = numbers.Where(n => n > 0).Select(n => n.ToString()).ToArray();
            var negativeNumbers = numbers.Where(n => n < 0).Select(n => n.ToString()).ToArray();
            var twoNumbers = numbers.Where(n => Math.Abs(n) >= 10 && Math.Abs(n) <= 99).Select(n => n.ToString()).ToArray();
            var fiveNumbers = numbers.Where(n => Math.Abs(n) >= 10000 && Math.Abs(n) <= 99999).Select(n => n.ToString()).ToArray();

            File.WriteAllLines("positive_numbers.txt", positiveNumbers);
            File.WriteAllLines("negative_numbers.txt", negativeNumbers);
            File.WriteAllLines("twonumbers.txt", twoNumbers);
            File.WriteAllLines("fivenumbers.txt", fiveNumbers);

            Console.WriteLine($"додатних чисел: {positiveNumbers.Length}");
            Console.WriteLine($"відємних чисел: {negativeNumbers.Length}");
            Console.WriteLine($"двозначних чисел: {twoNumbers.Length}");
            Console.WriteLine($"пятизначних чисел: {fiveNumbers.Length}");
        }
    }
}
