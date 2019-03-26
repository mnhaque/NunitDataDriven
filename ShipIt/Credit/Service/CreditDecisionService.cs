using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipIt.Credit.Service
{
    public class CreditDecisionService : ICreditDecisionService
    {
        private int minScore = 200;
        public string GetDecision(int creditScore)
        {
            if (creditScore > minScore)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }
        public void UpdateMinScore(int score)
        {
            if (score < 0)
            {
                throw new ArgumentException($"{score} is not a valid score");
            }
            minScore = score;
        }
    }
}
