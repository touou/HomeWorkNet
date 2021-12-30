using System;
using System.Linq.Expressions;
using HW11Dynamic.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW11Dynamic.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICalculatorVisitor _visitor;
        private readonly IExcepHandler _exceptionHandler;

        public CalculatorController(ICalculatorVisitor visitor, IExcepHandler exceptionHandler)
        {
            _visitor = visitor;
            _exceptionHandler = exceptionHandler;
        }
        
        [HttpGet, Route("calc")]
        public IActionResult Calc(string expression)
        {
            try
            {
                 expression= expression.Replace(" ", "+");
                var temp = ExpressionParser.Parse(expression);
                var visit = _visitor.Visit(temp);
                var value = (int) (_visitor.Visit(temp) as ConstantExpression)?.Value!;
                return Ok(value);
            }
            catch(Exception e)
            {
                _exceptionHandler.HandleException(e);
                return Content(e.Message);
            }
        }
    }
}