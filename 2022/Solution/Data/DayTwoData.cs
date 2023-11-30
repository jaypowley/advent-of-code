namespace Solution.Data
{
    public class DayTwoData
    {
        public static IList<Round> ParseInput()
        {
            int counter = 1;
            List<Round> rounds = new List<Round>();

            foreach (string line in File.ReadLines(@"Data\Day2Data.txt"))
            {
                char[] choices = line.ToCharArray();
                eChoice oppChoice = mapChoice(choices[0]);
                eChoice myChoice = mapChoice(choices[2]);
                
                var round = new Round(counter, oppChoice, myChoice);
                Console.WriteLine("Round {0} has opponent choosing {1} and me choosing {2}.", counter, round.OppChoice, round.MyChoice);

                rounds.Add(round);
                counter++;
            }

            return rounds;
        }

        public static IList<Round> ParseInput2()
        {
            int counter = 1;
            List<Round> rounds = new List<Round>();

            foreach (string line in File.ReadLines(@"Data\Day2Data.txt"))
            {
                char[] choices = line.ToCharArray();
                eChoice oppChoice = mapChoice(choices[0]);
                eOutcome myChoice = mapOutcome(choices[2]);

                var round = new Round(counter, oppChoice, myChoice);
                Console.WriteLine("Round {0} has opponent choosing {1} and me choosing {2}.", counter, round.OppChoice, round.MyChoice);

                rounds.Add(round);
                counter++;
            }

            return rounds;
        }        

        public record Round(int Id, eChoice OppChoice, eChoice MyChoice);

        public enum eOutcome
        {
            Loss = 0,
            Draw = 3,
            Win = 6
        }

        public enum eChoice
        {
            Rock = 0,
            Paper = 1,
            Scissor = 2
        }

        private static eChoice mapChoice(char v)
        {
            return v switch
            {
                'A' => eChoice.Rock,
                'X' => eChoice.Rock,
                'B' => eChoice.Paper,
                'Y' => eChoice.Paper,
                'C' => eChoice.Scissor,
                'Z' => eChoice.Scissor,
                _ => throw new Exception("Mistakes were made")
            };
        }

        private static eOutcome mapOutcome(char v)
        {
            return v switch
            {
                'X' => eOutcome.Loss,
                'Y' => eOutcome.Draw,
                'Z' => eOutcome.Win,
                _ => throw new Exception("Mistakes were made")
            };
        }
    }
}
