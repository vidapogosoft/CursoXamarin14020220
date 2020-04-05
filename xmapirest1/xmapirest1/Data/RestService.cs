using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xmapirest1.Model;

using Newtonsoft.Json;
using System.Net.Http;
using System.Diagnostics;


namespace xmapirest1.Data
{
    public class RestService : IRestService
    {
        HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
        }

        public List<TodoItem> Items { get; set; }

        public Task DeleteTodoItem(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TodoItem>> RefreshData()
        {
            Items = new List<TodoItem>();

            var uri = new Uri(string.Format(Constants.TodoItemsUrl, string.Empty));

            try
            {
                var response = await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<TodoItem>>(content);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"Error {0}", ex.Message);
            }

            return Items;
        }

        public async Task SaveTodoItem(TodoItem item, bool isnewItem)
        {
            var uri = new Uri(string.Format(Constants.TodoItemsUrl, string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                if (isnewItem)
                {
                    response = await _client.PostAsync(uri, content);
                }
                else
                {
                    response = await _client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"TodoItem: Saved");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"Error {0}", ex.Message);
            }

        }
    }
}
