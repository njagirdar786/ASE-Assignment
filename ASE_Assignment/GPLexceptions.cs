using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class GPLexceptions
    {
        public class InvalidCommandException : Exception
        {
            public InvalidCommandException() { }
            public InvalidCommandException(string message) : base(message) { }
        }
        public class InvalidParameterException : Exception 
        {
            public InvalidParameterException() { }
            public InvalidParameterException(string message) : base(message) { }    
        }    
    }
}
