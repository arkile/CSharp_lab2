using System;

namespace CSharp_lab2.Exceptions
{
    class PersonDataException : Exception
    {
        public PersonDataException() { }
        public PersonDataException(string message) : base(message) { }
        public PersonDataException(string message, System.Exception inner) : base(message, inner) { }
    }

}