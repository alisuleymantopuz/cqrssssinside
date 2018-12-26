using System;
namespace cqrssssinside.domain.appServices
{
    public static class HandlerRegistration
    {
        public static void AddHandlers(this IServiceCollection services)
        {
            List<Type> handlerTypes = typeof(ICommand).Assembly.GetTypes()
                .Where(x => x.GetInterfaces().Any(IsHandlerInterface))
                .Where(x => x.Name.EndsWith("Handler", StringComparison.Ordinal))
                .ToList();

            handlerTypes.ForEach(x => { services.AddTransient(x.GetGenericTypeDefinition(), x); });
        }
    }
}
