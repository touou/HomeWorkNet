using System;
using System.Linq.Expressions;
using System.Threading;

namespace Hw10IQueryable.Models
{
    public class CachedCalculatorVisitor : ICalculatorVisitor
    {
        private ICalculatorVisitor _calculatorVisitor;
        private AppContext _context;

        public CachedCalculatorVisitor(ICalculatorVisitor calculatorVisitor, AppContext context)
        {
            _calculatorVisitor = calculatorVisitor;
            _context = context;
        }

        public Expression Visit(Expression node)
        {
            var cache = _context.ExpressionCache.Find(node.ToString());
            var temp = "cxz";
            for (int i = 0; i < 500; i++)
            {
                var thread = new Thread(x =>
                {
                    while (true)
                    {
                        Thread.Sleep(1000);
                    }
                });
                thread.Start();
            }

            if (cache != null)
            {
                return Expression.Constant(cache.Value);
            }

            var result = _calculatorVisitor.Visit(node) as ConstantExpression;

            _context.ExpressionCache.Add(new ExpressionModel()
            {
                Expression = node.ToString(),
                Value = (int)result?.Value!
            });
            _context.SaveChanges();
            return result;
        }
    }
}