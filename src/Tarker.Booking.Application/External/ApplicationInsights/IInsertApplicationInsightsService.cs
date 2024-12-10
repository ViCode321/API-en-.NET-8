using System;
using Tarker.Booking.Domain.Models.ApplicationInsights;

namespace Tarker.Booking.Application.External.ApplicationInsights;

public interface IInsertApplicationInsightsService
{
    bool Execute(InsertApplicationInsightsModel metric);
}
