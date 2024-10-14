using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_2.Objects
{
    public class Condition
    {
        private variable[] _Variable;
        private bool _isNot;

        public Condition(variable[] variable, bool isNot)
        {
            _Variable = variable;
            _isNot = isNot;
        }

        private void UpdateVariables(variable[] variables)
        {
            for (int i = 0; i < _Variable.Length; i++)
            {
                for (int j = 0; j < variables.Length; j++)
                {
                    if (_Variable[i].GetIdentifier() == variables[j].GetIdentifier() && _Variable[i].GetIdentifier() != "CONSTANT" && variables[j].GetIdentifier() != "CONSTANT")
                    {
                        _Variable[i].SetValue(variables[j].GetValue());
                    }
                }
            }
            if (variables[1].GetIdentifier() == "CONSTANT")
            {
                variable[] tempVar = new variable[_Variable.Length + 1];
                _Variable.CopyTo(tempVar, 0);
                tempVar[tempVar.Length - 1] = variables[1];
                _Variable = tempVar;
            }
        }
        public bool isConditionMet(variable[] variables)
        {
            UpdateVariables(variables);
            if (_isNot)
            {
                if (_Variable[0].GetValue() != _Variable[1].GetValue())
                {
                    return true;
                }
            }
            else
            {
                if (_Variable[0].GetValue() == _Variable[1].GetValue())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
