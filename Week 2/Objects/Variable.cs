using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_2.Objects
{
    public class variable
    {
        private int _value = 0;
        private string _identifier;

        public variable(string identifier) { _identifier = identifier; }

        private bool CheckValueValid(int value)
        {
            if (value < 0)
            {
                return false;
            }
            return true;
        }
        public void SetValue(int value) 
        {
            if (CheckValueValid(value))
            {
                _value = value;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public int GetValue() { return _value; }
        public string GetIdentifier() { return _identifier; }
    }
}
