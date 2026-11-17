using Microsoft.Extensions.DependencyInjection;
using TakeAPill.Application.IntakeSchedules.Commands.CreateIntakeSchedule;
using TakeAPill.Application.IntakeSchedules.Commands.DeleteIntakeSchedule;
using TakeAPill.Application.IntakeSchedules.Queries.GetIntakeSchedules;
using TakeAPill.Application.Pills.Queries.GetPills;
using TakeAPill.Infrastructure.IntakeSchedules.Commands.CreateIntakeSchedule;
using TakeAPill.Infrastructure.IntakeSchedules.Commands.DeleteIntakeSchedule;
using TakeAPill.Infrastructure.IntakeSchedules.Queries.GetIntakeSchedules;
using TakeAPill.Infrastructure.Pills.Queries.GetPills;

namespace TakeAPill.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddIntakeScheduleInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IIntakeScheduleReadStore, IntakeScheduleReadStore>();
        services.AddScoped<ICreateIntakeScheduleStore, IntakeScheduleWriteStore>();
        services.AddScoped<IDeleteIntakeScheduleStore, IntakeScheduleDeleteStore>();
        services.AddScoped<IPillReadStore, PillReadStore>();
        return services;
    }
}

