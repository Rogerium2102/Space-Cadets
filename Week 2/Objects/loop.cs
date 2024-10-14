using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_2.Objects
{
    public class loop
    {
        private Condition _condition;
        private int _JumpPoint;
        private int _CallCount = 0;
        private string _LoopID;

        public loop(int CallPoint, variable[] variables, bool isConditionNot, int loopID)
        {
            _JumpPoint = CallPoint;
            _condition = new Condition(variables, isConditionNot);
            if (variables == null) { _LoopID = "NULL"; }
            else
            {
                _LoopID = variables[0].GetIdentifier();
            }
        }

        public string GetLoopId()
        {
            return _LoopID;
        }

        public int GetJumpPoint()
        {
            return (_JumpPoint);
        }
        public bool CheckCondition(variable[] Variables)
        {
            return _condition.isConditionMet(Variables);
        }
    }
}
