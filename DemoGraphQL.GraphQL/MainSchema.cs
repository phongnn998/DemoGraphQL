
using System;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace DemoGraphQL.GraphQL
{
    public class MainSchema : Schema
    {
        public MainSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<MainQuery>();
            Mutation = provider.GetRequiredService<MainMutation>();
        }
    }
}
