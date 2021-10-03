using System;
using DemoGraphQL.GraphQL;
using DemoGraphQL.GraphQL.Types;
using DemoGraphQL.EntityFramework;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using DemoGraphQL.Domain.Services.Interfaces;
using DemoGraphQL.Domain.Services;

namespace DemoGraphQL.IoCRegistrar
{
    public static class IoCRegistrar
    {
        public static IServiceCollection DIRegistar(this IServiceCollection services)
        {
            services.AddTransient<IDbContext, AppDbContext>();
            services.AddTransient(typeof(IRepository<,>), typeof(EfRepository<,>));

            ServiceRegistar(services);
            GraphQLTypeRegistar(services);

            return services;
        }

        private static void ServiceRegistar(IServiceCollection services)
        {
            services.AddTransient<ITodoItemService, ToDoItemService>();
        }

        private static void GraphQLTypeRegistar(IServiceCollection services)
        {
            // Roots.
            services.AddScoped<ISchema, MainSchema>();
            services.AddScoped<MainQuery>();
            services.AddScoped<MainMutation>();

            // Types
            services.AddScoped<TodoItemType>();
            services.AddScoped<CreateTodoItemInputType>();
            services.AddScoped<UpdateTodoItemInputType>();
            services.AddScoped<DeleteTodoItemInputType>();
        }
    }
}
