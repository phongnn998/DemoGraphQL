using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DemoGraphQL.EntityFramework;
using DemoGraphQL.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using DemoGraphQL.Domain.Services.Interfaces;
using DemoGraphQL.Domain.Models;

namespace DemoGraphQL.Domain.Services
{
    public class ToDoItemService : ITodoItemService
    {
        private readonly IRepository<TodoItem, int> _repository;
        private readonly IMapper _mapper;

        public ToDoItemService(
            IMapper mapper,
            IRepository<TodoItem, int> repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<TodoItemViewModel>> GetAllAsync(int pageSize = 10, int offset = 0)
        {
            var query = _repository.TableNoTracking.Skip(offset).Take(pageSize);
            return await _mapper.ProjectTo<TodoItemViewModel>(query).ToListAsync();
        }

        public async Task<TodoItemViewModel> CreateAsync(TodoItemViewModel input)
        {
            var entity = _mapper.Map<TodoItem>(input);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<TodoItemViewModel>(result);
        }

        public async Task<TodoItemViewModel> UpdateAsync(TodoItemViewModel input)
        {
            if (input == null || input.Id <= 0 )
            {
                throw new ArgumentException(nameof(input));
            }

            var entity = _repository.Table.FirstOrDefault(x => x.Id == input.Id);
            _mapper.Map(input, entity);

            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<TodoItemViewModel>(result);
        }

        public async Task<TodoItemViewModel> GetByIdAsync(int id)
        {
            var entity = await _repository.TableNoTracking.FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<TodoItemViewModel>(entity);
        }

        public async Task<TodoItemViewModel> DeleteAsync(int id)
        {
            var deleteItem = await _repository.DeleteAsync(id);
           return _mapper.Map<TodoItemViewModel>(deleteItem);
        }
    }
}
