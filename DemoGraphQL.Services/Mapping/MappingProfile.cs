using AutoMapper;
using DemoGraphQL.Domain.Models;
using DemoGraphQL.EntityFramework.Entities;

namespace DemoGraphQL.Domain.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<TodoItem, TodoItemViewModel>();
            CreateMap<TodoItemViewModel, TodoItem>();
        }
    }
}
