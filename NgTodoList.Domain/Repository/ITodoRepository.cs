using System;
using System.Collections.Generic;

namespace NgTodoList.Domain.Repository
{
    public interface ITodoRepository : IDisposable
    {
        IList<Todo> Get(string email);
        void Sync(IList<Todo> todos, string email);
    }
}
