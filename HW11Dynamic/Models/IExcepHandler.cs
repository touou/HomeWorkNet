using System;

namespace HW11Dynamic.Models
{
    public interface IExcepHandler
    {
        public void HandleException<T>(T exception) where T : Exception;
    }
}