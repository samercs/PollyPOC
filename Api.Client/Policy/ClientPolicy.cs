using Polly;

namespace Api.Client.Policy;

public class ClientPolicy
{
    public AsyncPolicy<HttpResponseMessage> ImmediatHttpRetry { get; }
    public AsyncPolicy<HttpResponseMessage> LinearHttpRetry { get; }
    public AsyncPolicy<HttpResponseMessage> ExponentialHttpRetry { get; }

    public ClientPolicy()
    {
        ImmediatHttpRetry = Polly.Policy.HandleResult<HttpResponseMessage>(res => !res.IsSuccessStatusCode)
            .RetryAsync(5);

        LinearHttpRetry = Polly.Policy.HandleResult<HttpResponseMessage>(i => !i.IsSuccessStatusCode)
            .WaitAndRetryAsync(5, ret => TimeSpan.FromSeconds(3));

        ExponentialHttpRetry = Polly.Policy.HandleResult<HttpResponseMessage>(i => !i.IsSuccessStatusCode)
            .WaitAndRetryAsync(5, ret => TimeSpan.FromSeconds(Math.Pow(2, ret)));

    }
}