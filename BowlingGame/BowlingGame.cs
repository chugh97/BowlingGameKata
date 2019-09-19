using System;

namespace BowlingGame
{
    public class BowlingGame
    {
        private int[] rolls = new int[21];
        private int currentroll = 0;
        public void Roll(int p)
        {
            rolls[currentroll++] = p;
        }

        public object Score()
        {
            int score = 0;
            int rollindex = 0;
            for (int frames = 0; frames < 10; frames++)
            {
                if (isStrike(rollindex))
                {
                    score += 10 + strikeBonus(rollindex);
                    rollindex++;
                }
                else if (isSpare(rollindex))
                {
                    score += 10 + spareBonus(rollindex);
                    rollindex += 2;
                }
                else
                {
                    score += rolls[rollindex] + rolls[rollindex+1];
                    rollindex += 2;
                }
            }

            return score;
        }

        private bool isStrike(int rollindex)
        {
            return rolls[rollindex] == 10;
        }

        private int strikeBonus(int rollindex)
        {
            return rolls[rollindex + 1] + rolls[rollindex + 2];
        }

        private int spareBonus(int rollindex)
        {
            return rolls[rollindex + 2];
        }

        private bool isSpare(int rollindex)
        {
            return rolls[rollindex] + rolls[rollindex + 1] == 10;
        }
    }
}
