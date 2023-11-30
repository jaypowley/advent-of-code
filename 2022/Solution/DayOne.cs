using static Solution.Data.DayOneData;

namespace Solution
{
    public static class DayOne
    {
        public static string PartOne()
        {            
            var data = ParseInput();

            //Get elf with highest TotalCalorie amount
            var elf = data.OrderByDescending(x => x.TotalCalories).First();
            
            return elf.TotalCalories.ToString();
        }

        public static string PartTwo()
        {
            var data = ParseInput();

            //Get top 3 elves with highest TotalCalorie amount
            var elves = data.OrderByDescending(x => x.TotalCalories).Take(3);

            //Return sum of top 3 elves TotalCalorie amount
            return elves.Sum(x => x.TotalCalories).ToString();
        }
    }
}
