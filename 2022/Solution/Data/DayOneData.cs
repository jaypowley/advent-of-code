namespace Solution.Data
{
    public class DayOneData
    {
        public static IList<Elf> ParseInput()
        {
            int counter = 1;
            List<Elf> elves = new List<Elf>();
            List<int> foodItemCalories = new List<int>();
            
            foreach (string line in File.ReadLines(@"Data\Day1Data.txt"))
            {
                if (!string.IsNullOrEmpty(line))
                {
                    foodItemCalories.Add(int.Parse(line));
                    continue;
                }

                Console.WriteLine("Elf {0} has {1} total calories", counter, foodItemCalories.Sum());
                
                elves.Add(new Elf(counter, foodItemCalories, foodItemCalories.Sum()));
                foodItemCalories.Clear();

                counter++;
            }

            //End of line (no more empty lines)
            Console.WriteLine("Elf {0} has {1} total calories", counter, foodItemCalories.Sum());
            
            elves.Add(new Elf(counter, foodItemCalories, foodItemCalories.Sum()));            

            return elves;
        }
    }

    public record Elf(int Id, IList<int> FoodItemCalories, int TotalCalories);
}
