﻿using System.Linq.Expressions;

namespace HW11Dynamic.Models
{
    public interface ICalculatorVisitor
    {
        public Expression Visit(Expression node);
    }
}