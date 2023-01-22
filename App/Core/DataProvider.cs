using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppR;
using App.MVVM.Model;

namespace App.Core
{
    internal class DataProvider
    {

        public async void getUsers()
        {
            var client = new HttpClient();

            try
            {
                client.BaseAddress = new Uri("http://localhost:3000");

                var response = await client.GetAsync("endpoint/example");
                var result = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<User>>(result);
            }
            catch(Exception e)
            {

            };

            


        }

    }
}
