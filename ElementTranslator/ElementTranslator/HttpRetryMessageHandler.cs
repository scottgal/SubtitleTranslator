using Polly;
using Polly.Timeout;

namespace ElementTranslator;

public class HttpRetryMessageHandler : DelegatingHandler
{
    public HttpRetryMessageHandler(HttpClientHandler handler) : base(handler)
    {
    }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        return Policy
            .Handle<HttpRequestException>()
            .Or<TimeoutRejectedException>()
            .Or<TaskCanceledException>()
            .OrResult<HttpResponseMessage>(x => !x.IsSuccessStatusCode)
            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(3, retryAttempt)))
            .ExecuteAsync(() => base.SendAsync(request, cancellationToken));
    }
}