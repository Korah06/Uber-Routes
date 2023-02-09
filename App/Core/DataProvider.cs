﻿using Newtonsoft.Json;
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
using System.Text.Json;
using System.Text.Json.Serialization;
using App.MVVM.View;
using System.Net;
using System.IO;

namespace App.Core
{
    internal class DataProvider
    {
        private HttpClient client = new HttpClient();

        public async Task<LoginResponse> Login(string username,string password) {

            try
            {
                client = new HttpClient();
                MVVM.Model.Login data = new MVVM.Model.Login()
                {
                    _id = username,
                    password = password
                };
                var serialized = System.Text.Json.JsonSerializer.Serialize<MVVM.Model.Login>(data);


                HttpContent content = new StringContent(serialized, System.Text.Encoding.UTF8, "application/JSON");

                var response = await client.PostAsync("http://localhost:9999/users/login", content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    LoginResponse loginResult = System.Text.Json.JsonSerializer.Deserialize<LoginResponse>(result);

                    if (loginResult.data != null && loginResult.data.admin)
                    {
                        return loginResult;

                    }
                    else
                    {
                        MessageBox.Show("El usuario no es administrador O no existe", "Error de Conexión", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.None);
                        return null;
                    }

                }
                else
                {
                    return null;
                }


            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<string> Register(User usuario)
        {

            try
            {
                client = new HttpClient();
                var serialized = System.Text.Json.JsonSerializer.Serialize<User>(usuario);


                HttpContent content = new StringContent(serialized, System.Text.Encoding.UTF8, "application/JSON");

                var response = await client.PostAsync("http://localhost:9999/users/register", content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    LoginResponse loginResult = System.Text.Json.JsonSerializer.Deserialize<LoginResponse>(result);

                    Console.WriteLine(loginResult.token);

                    return loginResult.token;
                }
                else
                {
                    return "";
                }


            }
            catch (Exception e)
            {
                return null;
            }
        }


        public async Task<List<Post>> GetPosts()
        {
            try
            {
                client = new HttpClient();
                string responseBody = await client.GetStringAsync("http://localhost:9999/posts");
                PostsResponse result = JsonConvert.DeserializeObject<PostsResponse>(responseBody);


                return result.data;

            }
            catch (Exception e)
            {
                MessageBox.Show("No tiene conexión con el servidor", "Error de Conexión", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.None);

                return null;
            };
        }

        public async Task<List<User>> GetUsers()
        {
            try
            {
                client = new HttpClient();
                string responseBody = await client.GetStringAsync("http://localhost:9999/users/");
                UserResponse result = JsonConvert.DeserializeObject<UserResponse>(responseBody);

                return result.data;

            }
            catch (Exception e)
            {
                MessageBox.Show("No tiene conexión con el servidor", "Error de Conexión", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.None);

                return null;
            };
        }

    }
}
