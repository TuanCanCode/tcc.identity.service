﻿namespace Tcc.Identity.Core.Exceptions
{
    [Serializable]
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException() { }

        public ResourceNotFoundException(Type type) : base($"{type} is missing") { }

        public ResourceNotFoundException(string? message) : base(message) { }

        public ResourceNotFoundException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
