using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventure.ModLoaderAPI.Exceptions
{
    public class LoaderSignatureException : Exception
    {
        public LoaderSignatureException() : base("Invalid content loader class signature.") { }

        public LoaderSignatureException(string message) : base(message) { }

        public LoaderSignatureException(string message, Exception innerException) : base(message, innerException) { }
    }
}
