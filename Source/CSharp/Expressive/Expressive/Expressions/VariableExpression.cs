﻿using System;
using System.Collections.Generic;

namespace Expressive.Expressions
{
    internal class VariableExpression : IExpression
    {
        private readonly string _variableName;

        internal VariableExpression(string variableName)
        {
            _variableName = variableName;
        }

        #region IExpression Members

        public object Evaluate(IDictionary<string, object> arguments)
        {
            if (arguments == null ||
                !arguments.ContainsKey(_variableName))
            {
                throw new ArgumentException("The variable '" + _variableName + "' has not been supplied.");
            }

            // Check to see if we have to referred to another expression.
            var expression = arguments[_variableName] as Expression;
            if (expression != null)
            {
                return expression.Evaluate(arguments);
            }

            return arguments[_variableName];
        }

        #endregion
    }
}
