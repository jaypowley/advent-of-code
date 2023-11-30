namespace Solution
{
    internal class Program
    {
        /// <summary>
        /// The entry point of the application. 
        /// </summary>
        /// <param name="args">Expecting 2 arguments to be passed in (int Day, int Part)</param>
        static void Main(string[] args)
        {
            _ = int.TryParse(args[0], out int day);
            _ = int.TryParse(args[1], out int part);

            string output = (day, part) switch
            {
                (1, 1) => DayOne.PartOne(),
                (1, 2) => DayOne.PartTwo(),
                (2, 1) => DayTwo.PartOne(),
                (2, 2) => DayTwo.PartTwo(),
                _ => "Day/Part combo not implemented",
            };

            Console.WriteLine(output);
        }
    }
}