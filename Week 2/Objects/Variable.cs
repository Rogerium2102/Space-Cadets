using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_2.Objects
{

    public class Variable
    {
        private int Value;
        private string Identifier;

        public Variable() { }   

        public void SetValue(int value) {
            Value = value; }

        public int GetValue() { return Value; }

        public void SetIdentifier(string identifier) { Identifier = identifier; }

        public string GetIdentifier() { return Identifier; }
    }
}
