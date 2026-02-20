using System;
using System.Collections.Generic;
using System.Text;

namespace EasyClothing.App.Common
{
    public enum ErrorCode
    {
        Validation,
        NotFound,
        Conflict,
        Unauthorized,
        Unexpected
    }

    public record Error(ErrorCode Code, string Message);

    public class ResultApp
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;

        public Error? Error { get; }
        public string? Message { get; }

        protected ResultApp(bool isSuccess, Error? error, string? message)
        {
            IsSuccess = isSuccess;
            Error = error;
            Message = message;
        }

        public static ResultApp Success(string? message = null)
            => new(true, null, message);

        public static ResultApp Failure(Error error)
            => new(false, error, null);
    }

    public class Result<T> : ResultApp
    {
        public T? Value { get; }

        private Result(T? value, bool isSuccess, Error? error, string? message)
            : base(isSuccess, error, message)
        {
            Value = value;
        }

        public static Result<T> Success(T value, string? message = null)
            => new(value, true, null, message);

        public static Result<T> Failure(Error error)
            => new(default, false, error, null);
    }
}
