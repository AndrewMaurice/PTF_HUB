using System;
namespace PtfHub.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException() : base("Cannot found teh resource that you've requested")
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }
    }
}
