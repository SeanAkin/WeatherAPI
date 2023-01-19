using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace WeatherAPI.Test.Integration_Tests
{
    public class TestBase
    {
        protected WebApplicationFactory<Program> _application;
        protected HttpClient _weatherApiClient;

        [OneTimeSetUp]
        protected void SetUp()
        {
            _application= new WebApplicationFactory<Program>();
            _weatherApiClient = _application.CreateClient();
        }
    }
}
