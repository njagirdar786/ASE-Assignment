using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
 
    /// <summary>
    /// Class that holds custom exceptions related to this program (Graphical Programming Language).
    /// </summary>
    public class GPLexceptions
    {
        /// <summary>
        /// Exception that is thrown when a command is invalid.
        /// </summary>
        public class InvalidCommandException : Exception
        {
            public InvalidCommandException() { }
            public InvalidCommandException(string message) : base(message) { }
        }

        /// <summary>
        /// Exception that is thrown when invalid parameters are read.
        /// </summary>
        public class InvalidParameterException : Exception 
        {
            public InvalidParameterException() { }
            public InvalidParameterException(string message) : base(message) { }    
        }    
    }
}
