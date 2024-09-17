using Challenge;

namespace Challenge.Exceptions
{
    public class InvalidCPFException : ArgumentException
    {
        public InvalidCPFException()
        {
        }

        public InvalidCPFException(string message) : base(message)
        {
        }

        public InvalidCPFException(string message, Exception inner) : base(message, inner)
        {
        }

    }
}