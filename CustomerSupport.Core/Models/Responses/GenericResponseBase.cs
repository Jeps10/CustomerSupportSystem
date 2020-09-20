using System;
using System.Linq;
using System.Collections.Generic;

namespace CustomerSupport.Core.Models.Responses
{
    public class GenericResponseBase<T>
    {
        public GenericResponseBase(T value, Dictionary<string, string> errors)
        {
            Value = value;
            Errors = errors;
        }

        public T Value { get; private set; }

        public Dictionary<string, string> Errors { get; private set; }

        public bool Success { get => !Errors.Any(); }
    }
}