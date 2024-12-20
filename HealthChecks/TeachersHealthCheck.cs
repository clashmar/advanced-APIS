using advanced_APIS.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json;

namespace advanced_APIS.HealthChecks
{
    public class TeachersHealthCheck : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            string jsonFilePath = @"Resources\Teachers.json"; // TODO: Use config pattern to set this
            string jsonData = await File.ReadAllTextAsync(jsonFilePath);
            List<Teacher> teachersData = JsonSerializer.Deserialize<List<Teacher>>(jsonData) ?? [];

            int teacherCount = teachersData.Count;
            string message = $"There are {teacherCount} teachers at Evies Wizard World.";
            if (teacherCount > 0)
            {
                return HealthCheckResult.Healthy(message);
            }
            else
            {
                return HealthCheckResult.Unhealthy(message);
            }
        }
    }
}
