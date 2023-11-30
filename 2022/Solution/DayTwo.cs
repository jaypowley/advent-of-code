using static Solution.Data.DayTwoData;

namespace Solution
{
    public static class DayTwo
    {
        public static string PartOne()
        {            
            var data = ParseInput();
            
            int totalPoints = 0;
            foreach (var round in data)
            {
                var outcome = determineOutcome(round.OppChoice, round.MyChoice);
                totalPoints += outcome.TotalPoints;
            }
            
            return totalPoints.ToString();
        }

        public static string PartTwo()
        {
            var data = ParseInput();

            int totalPoints = 0;
            foreach (var round in data)
            {
                var outcome = determineExactOutcome(round.OppChoice, round.MyChoice);
                totalPoints += outcome.TotalPoints;
            }

            return totalPoints.ToString();

            return totalPoints.ToString();
        }

        private static Outcome determineExactOutcome(eChoice oppChoice, eChoice myChoice)
        {
            return ((int)oppChoice, (int)myChoice) switch
            {
                (0, 0) => new Outcome(eOutcome.Draw, GetOutcomeValue(eOutcome.Draw, 0)),    //Rock v Rock
                (0, 1) => new Outcome(eOutcome.Win, GetOutcomeValue(eOutcome.Win, 1)),      //Rock v Paper
                (0, 2) => new Outcome(eOutcome.Loss, GetOutcomeValue(eOutcome.Loss, 2)),    //Rock v Scissor
                (1, 0) => new Outcome(eOutcome.Loss, GetOutcomeValue(eOutcome.Loss, 0)),    //Paper v Rock
                (1, 1) => new Outcome(eOutcome.Draw, GetOutcomeValue(eOutcome.Draw, 1)),    //Paper v Paper
                (1, 2) => new Outcome(eOutcome.Win, GetOutcomeValue(eOutcome.Win, 2)),      //Paper v Scissor
                (2, 0) => new Outcome(eOutcome.Win, GetOutcomeValue(eOutcome.Win, 0)),      //Scissor v Rock
                (2, 1) => new Outcome(eOutcome.Loss, GetOutcomeValue(eOutcome.Loss, 1)),    //Scissor v Paper
                (2, 2) => new Outcome(eOutcome.Draw, GetOutcomeValue(eOutcome.Draw, 2)),    //Scissor v Scissor
                _ => throw new Exception("Mistakes were made")
            };
        }

        private static Outcome determineOutcome(eChoice oppChoice, eChoice myChoice)
        {
            return ((int)oppChoice, (int)myChoice) switch
            {
                (0, 0) => new Outcome(eOutcome.Draw, GetOutcomeValue(eOutcome.Draw, 0)),    //Rock v Rock
                (0, 1) => new Outcome(eOutcome.Win, GetOutcomeValue(eOutcome.Win, 1)),      //Rock v Paper
                (0, 2) => new Outcome(eOutcome.Loss, GetOutcomeValue(eOutcome.Loss, 2)),    //Rock v Scissor
                (1, 0) => new Outcome(eOutcome.Loss, GetOutcomeValue(eOutcome.Loss, 0)),    //Paper v Rock
                (1, 1) => new Outcome(eOutcome.Draw, GetOutcomeValue(eOutcome.Draw, 1)),    //Paper v Paper
                (1, 2) => new Outcome(eOutcome.Win, GetOutcomeValue(eOutcome.Win, 2)),      //Paper v Scissor
                (2, 0) => new Outcome(eOutcome.Win, GetOutcomeValue(eOutcome.Win, 0)),      //Scissor v Rock
                (2, 1) => new Outcome(eOutcome.Loss, GetOutcomeValue(eOutcome.Loss, 1)),    //Scissor v Paper
                (2, 2) => new Outcome(eOutcome.Draw, GetOutcomeValue(eOutcome.Draw, 2)),    //Scissor v Scissor
                _ => throw new Exception("Mistakes were made")
            };
        }

        private static int GetOutcomeValue(eOutcome outcome, int choice)
        {
            int outcomePoints = outcome switch
            {
                eOutcome.Loss => 0,
                eOutcome.Draw => 3,
                eOutcome.Win => 6,
                _ => throw new Exception("Mistakes were made")
            };

            int choicePoints = choice switch
            {
                0 => 1, //Rock
                1 => 2, //Paper
                2 => 3, //Scissor
                _ => throw new Exception("Mistakes were made")
            };

            return outcomePoints + choicePoints;
        }

        public record Outcome(eOutcome WinLossorDraw, int TotalPoints);
    }
}
