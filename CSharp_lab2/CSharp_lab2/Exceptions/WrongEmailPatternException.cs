﻿
namespace CSharp_lab2.Exceptions
{
    class WrongEmailPatternException : PersonDataException
    {
        public WrongEmailPatternException() { }
        public WrongEmailPatternException(string message) : base(message) { }
        public WrongEmailPatternException(string message, System.Exception inner) : base(message, inner) { }
    }
}
