using System;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using HW9ExpressionTrees.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;



namespace HW9ExpressionTrees.Controllers
{
    public class CalculatorController : Controller
    {
        private CachedCalculatorVisitor _visitor;

        public CalculatorController(CachedCalculatorVisitor visitor)
        {
            _visitor = visitor;
        }
        
        [HttpGet, Route("calc")]
        public IActionResult Calc(string expression)
        {
            //expression = expression.Replace(" ", "+");
            var save = ExpressionParser.Parse(expression);
            var visit = new Visitor().Visit(save);
            var value = (int) (new Visitor().Visit(save) as ConstantExpression)?.Value!;
            return Ok(value);
        }
    }
}