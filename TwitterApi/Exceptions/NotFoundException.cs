﻿namespace TwitterApi.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, string key) : base($"Entity {name} with key {key} not found!") { }
    }
}
