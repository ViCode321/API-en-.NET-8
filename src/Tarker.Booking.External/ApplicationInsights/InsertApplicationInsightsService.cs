using System;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Configuration;
using Tarker.Booking.Application.External.ApplicationInsights;
using Tarker.Booking.Domain.Models.ApplicationInsights;

namespace Tarker.Booking.External.ApplicationInsights
{
    
    public class InsertApplicationInsightsService: IInsertApplicationInsightsService
    {
        private readonly IConfiguration _configuration;

        public InsertApplicationInsightsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Execute(InsertApplicationInsightsModel metric)
        {
            if(metric == null)
                throw new ArgumentNullException(nameof(metric));
            
            TelemetryConfiguration configuration = new TelemetryConfiguration();
            configuration.ConnectionString = _configuration["ApplicationInsightsConnectionString"];

            var _telemetryClient = new TelemetryClient(configuration);

            var properties = new Dictionary<string, string>
            {
                {"Id", metric.Id},
                {"Content", metric.Content},
                {"Detail", metric.Detail}
            };
            _telemetryClient.TrackTrace(metric.Type, SeverityLevel.Information, properties);

            return true;
        }
    }

}