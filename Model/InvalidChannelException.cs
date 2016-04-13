using System;

namespace Model
{
    public class InvalidChannelException : Exception
    {
        public InvalidChannelException()
            : base("Invalid Channel. Make sure the channel is a positive number.")
        {

        }
    }
}
