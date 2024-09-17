using Challenge;

namespace Challenge.Exceptions
{
    public class InvalidNameException : ArgumentException
    {
        public InvalidNameException()
        {
        }

        public InvalidNameException(string message) : base(message)
        {
        }

        public InvalidNameException(string message, Exception inner) : base(message, inner)
        {
        }

    }
}