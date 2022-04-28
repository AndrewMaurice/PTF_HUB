using System;
namespace PtfHub.Exceptions
{
    public class RecordAlreadyExistsExcpetion : ApplicationException
    {
        public RecordAlreadyExistsExcpetion(): base("The record you are trying to add already exists")
        {
        }

        public RecordAlreadyExistsExcpetion(string message): base(message)
        {
        }
    }
}
