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
            "https://record-shop-api.onrender.com/health"
        };

        foreach (var url in warmupUrls)
        {
            try
            {
                await httpClient.GetAsync(url, stoppingToken);
            }
            catch
            {
                // Warming a demo should never stop the portfolio from running.
            }
        }
    }
}
