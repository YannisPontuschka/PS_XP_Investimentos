using Challenge;

namespace Challenge.Exceptions
{
    public class InvalidEmailException : ArgumentException
    {
        public InvalidEmailException()
        {
        }

        public InvalidEmailException(string message) : base(message)
        {
        }

        public InvalidEmailException(string message, Exception inner) : base(message, inner)
        {
        }

    }
}