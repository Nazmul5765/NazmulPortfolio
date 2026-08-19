namespace NazmulPortfolio.Services;

public class DemoWarmupService : BackgroundService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DemoWarmupService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var httpClient = _httpClientFactory.CreateClient();

        var warmupUrls = new[]
        {
            "https://record-shop-api.onrender.com/health",
            "https://record-shop-frontend-q9m3.onrender.com/"
        };

        var warmupTasks = warmupUrls.Select(async url =>
        {
            try
            {
                await httpClient.GetAsync(url, stoppingToken);
            }
            catch
            {
                // Warming a demo should never stop the portfolio from running.
            }
        });

        await Task.WhenAll(warmupTasks);
    }
}
