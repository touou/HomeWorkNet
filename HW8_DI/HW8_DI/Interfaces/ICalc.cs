using HW8_DI.Controllers;
using HW8_DI.Models;

namespace HW8_DI.Interfaces
{
    public interface ICalc
    { 
        decimal Calc(CalcArguments args);
    }
    
}