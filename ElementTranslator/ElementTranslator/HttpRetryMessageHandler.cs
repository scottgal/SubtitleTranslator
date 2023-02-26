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
          
            .WaitAndRetryAsync(10, retryAttempt => TimeSpan.FromSeconds(Math.Pow(3, retryAttempt)));
        

         return await waitAndRetryPolicy.ExecuteAsync(cancellationToken => base.SendAsync(request, cancellationToken), cancellationToken);
    }
}