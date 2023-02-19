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
using System.Text.Json;
using System.Text.Json.Serialization;
using App.MVVM.View;
using System.Net;
using System.IO;
using MapControl;
using System.Net.Http.Headers;
using System.Security.Policy;

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
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + UserProvider.token);
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
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + UserProvider.token);
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

        public async void UploadPostImg(Post post)
        {
            try
            {

                string direccion = "http://localhost:9999/posts/deleteimg/"+post._id;

                client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + UserProvider.token);

                HttpContent content = null;

                var httpResponse = await client.PutAsync(direccion, content);

            }
            catch(Exception e)
            {
                MessageBox.Show(e+"");
            }
        }


        public async void UploadUserImg(User user)
        {
            try
            {

                string direccion = "http://localhost:9999/users/deleteimg/" + user._id;

                client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + UserProvider.token);

                HttpContent content = null;

                var httpResponse = await client.PutAsync(direccion, content);

            }
            catch (Exception e)
            {
                MessageBox.Show(e + "");
            }
        }

        public async void deleteUser(User user)
        {
            try
            {
                client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + UserProvider.token);
                var httpResponse = await client.DeleteAsync("http://localhost:9999/users/"+user._id);
                if (httpResponse.IsSuccessStatusCode)
                {

                    var result = await httpResponse.Content.ReadAsStringAsync();

                }
            }
            catch (Exception e) 
            {
                MessageBox.Show(e + "");
            }
        }

        public async void deletePost(Post post)
        {
            try
            {
                client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + UserProvider.token);
                var httpResponse = await client.DeleteAsync("http://localhost:9999/posts/" + post._id);
                if (httpResponse.IsSuccessStatusCode)
                {

                    var result = await httpResponse.Content.ReadAsStringAsync();

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e + "");
            }
        }
        public async void updatePost(Post post)
        {
            

            try
            {

                client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + UserProvider.token);

                var serialized = System.Text.Json.JsonSerializer.Serialize<Post>(post);



                HttpContent content = new StringContent(serialized, System.Text.Encoding.UTF8, "application/JSON");


                var httpResponse = await client.PutAsync("http://localhost:9999/posts/admupdate/" + post._id, content);

                if (httpResponse.IsSuccessStatusCode)
                {
                    MessageBox.Show("Se ha modificado la información de la ruta"+ post.name + "con id: " + post._id);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e + "");
                
            }
        }

        public async void updateUser(User user)
        {
            try
            {

                client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + UserProvider.token);

                var serialized = System.Text.Json.JsonSerializer.Serialize<User>(user);

                HttpContent content = new StringContent(serialized, System.Text.Encoding.UTF8, "application/JSON");


                var httpResponse = await client.PutAsync("http://localhost:9999/users/adm/" + user._id, content);

                if (httpResponse.IsSuccessStatusCode)
                {
                    MessageBox.Show("Se ha modificado la información del usuario:" + user._id);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e + "");

            }
        }

        public async Task<List<Post>> getPostsByUser(User user)
        {
            try
            {
                client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + UserProvider.token);


                Post data = new Post()
                {
                    user = user._id
                };

                var serialized = System.Text.Json.JsonSerializer.Serialize<Post>(data);


                HttpContent content = new StringContent(serialized, System.Text.Encoding.UTF8, "application/JSON");

                var response = await client.PostAsync("http://localhost:9999/posts/byuser", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    PostsResponse result = JsonConvert.DeserializeObject<PostsResponse>(responseBody);
                    return result.data;
                }
                else
                {
                    MessageBox.Show("Ha habido algún fallo de conexión");
                    return null;
                }


            }
            catch (Exception e)
            {
                MessageBox.Show(e + "");
                return null;
            }
        }

        public async Task<List<Coment>> getComments(string post)
        {
            try
            {
                client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + UserProvider.token);

                var response = await client.GetAsync("http://localhost:9999/comments/" + post);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    ComentResponse result = JsonConvert.DeserializeObject<ComentResponse>(responseBody);
                    return result.data;
                }
                else
                {
                    MessageBox.Show("Ha habido algún fallo de conexión");
                    return null;
                }

            }
            catch(Exception e) 
            {
                Console.WriteLine(e);
                MessageBox.Show("Ha habido algún problema interno de la aplicación");
                return null;
            }
        }

        public async void deleteComment(string comment)
        {
            try
            {
                client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + UserProvider.token);
                var httpResponse = await client.DeleteAsync("http://localhost:9999/comments/adm/" + comment);
                if (httpResponse.IsSuccessStatusCode)
                {

                    var result = await httpResponse.Content.ReadAsStringAsync();

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e + "");
            }
        }

    }
}
