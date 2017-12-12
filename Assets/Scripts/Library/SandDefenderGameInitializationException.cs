using System;

// ReSharper disable once CheckNamespace
namespace SandDefender.Library.Settings
{
    public class SandDefenderGameInitializationException: Exception
    {
        public SandDefenderGameInitializationException()
        {}

        public SandDefenderGameInitializationException(string message): base(message) 
        {}

        public SandDefenderGameInitializationException(Exception cause): this("", cause)
        {}

        public SandDefenderGameInitializationException(string message, Exception cause) : base(message, cause)
        {}
    } 
}