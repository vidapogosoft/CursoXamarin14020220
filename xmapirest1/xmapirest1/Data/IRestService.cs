using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xmapirest1.Model;

namespace xmapirest1.Data
{
    public interface IRestService
    {

        Task<List<TodoItem>> RefreshData();

        Task SaveTodoItem(TodoItem item, bool isnewItem);

        Task DeleteTodoItem(string id);

    }
}
