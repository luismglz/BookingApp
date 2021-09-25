using BookingApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Services
{
    public class ApiService
    {


       
          private string ApiUrl = "https://webapibooking.azurewebsites.net/";
        


        
        public async Task<ResponseModel> GetDataAsync(string controller) {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new System.Uri(ApiUrl)
                };
                var response = await client.GetAsync(controller);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        Message = result
                    };
                }

                return JsonConvert.DeserializeObject<ResponseModel>(result);
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }



        public async Task<ResponseModel> PostDataAsync(string controller, object data) {
            try
            {
                var serializeData = JsonConvert.SerializeObject(data);
                var content = new StringContent(serializeData, Encoding.UTF8, "application/json");
                var client = new HttpClient
                {
                    BaseAddress = new System.Uri(ApiUrl)
                };
                var response = await client.PostAsync(controller, content);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        Message = result
                    };
                }

                return JsonConvert.DeserializeObject<ResponseModel>(result);
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }





        public async Task<ResponseModel> PutDataAsync(string controller, object data) {
            try
            {
                var serializeData = JsonConvert.SerializeObject(data);
                var content = new StringContent(serializeData, Encoding.UTF8, "application/json");
                var client = new HttpClient
                {
                    BaseAddress = new System.Uri(ApiUrl)
                };
                var response = await client.PutAsync(controller, content);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        Message = result
                    };
                }

                return JsonConvert.DeserializeObject<ResponseModel>(result);
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }


        public async Task<ResponseModel> DeleteDataAsync(string controller, int id) {
            try
            {
                var serializeData = JsonConvert.SerializeObject(controller);
                var content = new StringContent(serializeData, Encoding.UTF8, "application/json");
                var client = new HttpClient
                {
                    BaseAddress = new System.Uri(ApiUrl)
                };
                var response = await client.DeleteAsync(controller + "/ " + id);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        Message = result
                    };
                }

                return JsonConvert.DeserializeObject<ResponseModel>(result);
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }




    }
}
