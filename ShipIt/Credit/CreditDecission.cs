using ShipIt.Credit.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipIt.Credit
{
    public class CreditDecission
    {
        ICreditDecisionService creditDecisionService;
        public CreditDecission(ICreditDecisionService creditDecisionService)
        {
            this.creditDecisionService = creditDecisionService;
        }
        public string MakeCreditDecision(int creditScore)
        {
            return creditDecisionService.GetDecision(creditScore);
        }
        public string MakeCreditDecision(int minVal, int creditScore)
        {
            creditDecisionService.UpdateMinScore(minVal);
            return creditDecisionService.GetDecision(creditScore);
        }
        public void UpdateMinScore(int minScore)
        {
            creditDecisionService.UpdateMinScore(minScore);
        }
    }
}
