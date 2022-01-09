using System.Linq.Expressions;

namespace Hw10IQueryable.Models
{
    public interface ICalculatorVisitor
    {
        public Expression Visit(Expression node);
    }
}