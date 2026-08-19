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

        foreach (var url in warmupUrls)
        {
            try
            {
                var response = await httpClient.GetAsync(url, stoppingToken);

                _logger.LogInformation(
                    "Warm-up request to {Url} returned {StatusCode}",
                    url,
                    response.StatusCode);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(
                    ex,
                    "Warm-up request to {Url} failed",
                    url);
            }
        }
    }
}
