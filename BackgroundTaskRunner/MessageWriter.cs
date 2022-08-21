using BackgroundTaskRunner.Interfaces;
using System;

namespace BackgroundTaskRunner
{
    public class MessageWriter : IMessageWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}