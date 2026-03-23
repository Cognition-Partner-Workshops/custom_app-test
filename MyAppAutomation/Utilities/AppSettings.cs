using System;

namespace MyAppAutomation.Utilities
{
    public static class AppSettings
    {
        public static string BaseUrl => Environment.GetEnvironmentVariable("APP_BASE_URL") ?? "http://localhost:5000";
    }
}
