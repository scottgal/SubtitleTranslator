using Polly;
using Polly.Timeout;

namespace ElementTranslator;

public class HttpRetryMessageHandler : DelegatingHandler
{
    public HttpRetryMessageHandler(HttpClientHandler handler) : base(handler)
    {
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var waitAndRetryPolicy = Policy
            .HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
            .Or<TimeoutRejectedException>()
            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(1, retryAttempt)));


        var result =
            await waitAndRetryPolicy.ExecuteAndCaptureAsync(
                cancellationToken => base.SendAsync(request, cancellationToken), cancellationToken);
        if (result.FinalException is not null)
            AnsiConsole.WriteException(result.FinalException);
        return result.Result;
    }
}