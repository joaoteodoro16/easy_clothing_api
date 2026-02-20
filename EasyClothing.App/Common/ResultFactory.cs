using System.Reflection;

namespace EasyClothing.App.Common;

public static class ResultFactory
{
    public static TResponse CreateFailure<TResponse>(ErrorCode code, string message)
    {
        // TResponse é Result<T>
        var error = new Error(code, message);

        // Busca o método estático: Result<T>.Failure(Error error)
        var failureMethod = typeof(TResponse).GetMethod(
            "Failure",
            BindingFlags.Public | BindingFlags.Static,
            binder: null,
            types: new[] { typeof(Error) },
            modifiers: null);

        if (failureMethod is null)
            throw new InvalidOperationException($"Não foi possível localizar {typeof(TResponse).Name}.Failure(Error).");

        return (TResponse)failureMethod.Invoke(null, new object[] { error })!;
    }
}
