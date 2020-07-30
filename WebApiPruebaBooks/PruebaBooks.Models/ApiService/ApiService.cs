using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PruebaBooks.Models.ApiService
{
    public class ApiService
    {
        //Metodos para consumir RESTFUL API

        //Obtener una lista generica 
        public async Task<Response> GetLista<T>(string urlBase, string servicePrefix, string controller)
        {
            try
            {

                var client = new HttpClient();

                client.BaseAddress = new Uri(urlBase);
                var url = string.Format("{0}{1}", servicePrefix, controller);

                var response = await client.GetAsync(url);

                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result
                    };
                }

                var lista = JsonConvert.DeserializeObject<List<T>>(result);
                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = lista
                };

            }
            catch (Exception ex)
            {

                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };

            }
        }

        //Obtener registro por id
        public async Task<Response> GetDataById<T>(string urlBase, string servicePrefix, string controller, int id)
        {
            try
            {

                controller = string.Concat(controller, id);

                var client = new HttpClient();

                client.BaseAddress = new Uri(urlBase);
                var url = string.Format("{0}{1}", servicePrefix, controller);

                var response = await client.GetAsync(url);

                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result
                    };
                }

                var data = JsonConvert.DeserializeObject<T>(result);
                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = data
                };

            }
            catch (Exception ex)
            {

                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };

            }
        }

        //Subir datos
        public async Task<Response> PostData(string urlBase, string servicePrefix, string controller, object datos)
        {

            try
            {

                var content = new StringContent(JsonConvert.SerializeObject(datos), Encoding.UTF8, "application/json");

                HttpClient httpclient = new HttpClient();

                httpclient.BaseAddress = new Uri(urlBase);

                string requestUri = string.Format("{0}{1}", servicePrefix, controller);

                var response = await httpclient.PostAsync(requestUri, content);


                if (!response.IsSuccessStatusCode)
                {

                    return new Response
                    {
                        IsSuccess = false,
                        Message = "Problema"
                    };

                }

                return new Response
                {

                    IsSuccess = true,
                    Message = "Ok"

                };




            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }

        }

        //Actualizar datos
        public async Task<Response> PutData(string urlBase, string servicePrefix, string controller,int id, object datos)
        {
            try
            {
                controller = string.Concat(controller, id);

                var content = new StringContent(JsonConvert.SerializeObject(datos), Encoding.UTF8, "application/json");

                HttpClient httpclient = new HttpClient();

                httpclient.BaseAddress = new Uri(urlBase);

                string requestUri = string.Format("{0}{1}", servicePrefix, controller);

                var response = await httpclient.PostAsync(requestUri, content);

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "Problema"
                    };
                }


                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok"
                };


            }
            catch (Exception ex)
            {

                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };

            }
        }

        //Actualizar datos
        public async Task<Response> PutData(string urlBase, string servicePrefix, string controller, object datos)
        {
            try
            {

                var content = new StringContent(JsonConvert.SerializeObject(datos), Encoding.UTF8, "application/json");

                HttpClient httpclient = new HttpClient();

                httpclient.BaseAddress = new Uri(urlBase);

                string requestUri = string.Format("{0}{1}", servicePrefix, controller);

                var response = await httpclient.PutAsync(requestUri, content);

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "Problema"
                    };
                }


                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok"
                };


            }
            catch (Exception ex)
            {

                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };

            }
        }

        //Eliminar datos
        public async Task<Response> DeleteData(string urlBase, string servicePrefix, string controller, int id)
        {

            try
            {

                var client = new HttpClient();

                client.BaseAddress = new Uri(urlBase);

                controller += id;

                var url = string.Format("{0}{1}", servicePrefix, controller);

                var response = await client.DeleteAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "Error"
                    };
                }

                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok"
                };


            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }

        }

    }
}
