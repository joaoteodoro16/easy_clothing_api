using MediatR;
using Microsoft.Extensions.Logging;

namespace EasyClothing.App.Common.Behaviors;

public sealed class ExceptionHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly ILogger<ExceptionHandlingBehavior<TRequest, TResponse>> _logger;

    public ExceptionHandlingBehavior(ILogger<ExceptionHandlingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Erro de validação em {Request}", typeof(TRequest).Name);

            if (typeof(TResponse).IsGenericType &&
                typeof(TResponse).GetGenericTypeDefinition() == typeof(Result<>))
            {
                return ResultFactory.CreateFailure<TResponse>(ErrorCode.Validation, ex.Message);
            }

            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro inesperado em {Request}", typeof(TRequest).Name);

            if (typeof(TResponse).IsGenericType &&
                typeof(TResponse).GetGenericTypeDefinition() == typeof(Result<>))
            {
                return ResultFactory.CreateFailure<TResponse>(ErrorCode.Unexpected, Messages.Gerais.OcorreuErroInesperado);
            }

            throw;
        }
    }
}
