using System;

namespace IncomeSystem
{
    public interface IIncome
    {
        event Action<float> IncomeChanged;
    }
}