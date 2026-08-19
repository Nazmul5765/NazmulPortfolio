namespace NazmulPortfolio.Services;

public class DemoWarmupService : BackgroundService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<DemoWarmupService> _logger;

    public DemoWarmupService(
        IHttpClientFactory httpClientFactory,
        ILogger<DemoWarmupService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var httpClient = _httpClientFactory.CreateClient();

        var warmupUrls = new[]
        {
            "https://record-shop-api.onrender.com/health",
            "https://record-shop-frontend-q9m3.onrender.com/"
        };

        var warmupTasks = warmupUrls.Select(url =>
            WarmServiceAsync(httpClient, url, stoppingToken));

        await Task.WhenAll(warmupTasks);
    }

    private async Task WarmServiceAsync(
        HttpClient httpClient,
        string url,
        CancellationToken stoppingToken)
    {
        const int maxAttempts = 12;
        var delay = TimeSpan.FromSeconds(8);

        for (var attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                using var response = await httpClient.GetAsync(url, stoppingToken);

                _logger.LogInformation(
                    "Warm-up attempt {Attempt} for {Url} returned {StatusCode}",
                    attempt,
                    url,
                    response.StatusCode);

                if (response.IsSuccessStatusCode)
                {
                    return;
                }
            }
            catch (Exception ex) when (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogWarning(
                    ex,
                    "Warm-up attempt {Attempt} for {Url} failed",
                    attempt,
                    url);
            }

            if (attempt < maxAttempts)
            {
                await Task.Delay(delay, stoppingToken);
            }
        }

        _logger.LogWarning(
            "Warm-up for {Url} did not succeed after {Attempts} attempts",
            url,
            maxAttempts);
    }
}
