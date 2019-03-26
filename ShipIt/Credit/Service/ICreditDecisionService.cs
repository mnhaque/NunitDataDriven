using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipIt.Credit.Service
{
    public interface ICreditDecisionService
    {
        string GetDecision(int creditScore);
        void UpdateMinScore(int score);
    }
}
