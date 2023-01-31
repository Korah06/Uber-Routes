using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppR;
using App.MVVM.Model;
using System.Windows;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Documents;

namespace App.Core
{
    internal class DataProvider
    {
        private HttpClient client = new HttpClient();

        public async Task<User> GetUsers(String username)
        {

            try
            {

                //https://jsonplaceholder.typicode.com/users


                //client.BaseAddress = new Uri("http://localhost:3505");

                //var response = await client.GetAsync("endpoint/example");
                //var result = await response.Content.ReadAsStringAsync();
                //var users = JsonConvert.DeserializeObject<List<User>>(result);


                string responseBody = await client.GetStringAsync($"http://localhost:9999/users/{username}");
                UserResponse result = JsonConvert.DeserializeObject<UserResponse>(responseBody);
                return result.data;

            }
            catch(Exception e)
            {
                MessageBox.Show("No tiene conexión con el servidor","Error de Conexión", MessageBoxButton.OK,MessageBoxImage.Error,MessageBoxResult.None);

                return new User();
            };

            

        }

        



    }
}
