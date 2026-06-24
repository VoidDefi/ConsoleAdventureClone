using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventure.Graphics
{
    public struct Symbol
    {
        public string Value { get; private set; }

        public Symbol(string value)
        {
            if (value != null && value?.Length == 2)
                Value = value;

            else Value = " ?";
        }
    }
}
