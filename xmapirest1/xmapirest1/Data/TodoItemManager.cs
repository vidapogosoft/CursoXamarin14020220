using System;
using System.Collections.Generic;
using System.Text;

using xmapirest1.Model;
using System.Threading.Tasks;

namespace xmapirest1.Data
{
    public class TodoItemManager
    {
        IRestService _restService;

        public TodoItemManager(IRestService service)
        {
            _restService = service;
        }

        public Task<List<TodoItem>> GetTask()
        {
            return _restService.RefreshData();
        }

        public Task SaveTask(TodoItem item, bool isnew = false)
        {
            return _restService.SaveTodoItem(item, isnew);
        }
    }
}
