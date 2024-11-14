using System;

public interface IIncome
{
    event Action<float> IncomeChanged;
}