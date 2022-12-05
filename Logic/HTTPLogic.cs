using Client.Helpers;
using Client.Models;
using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Linq.Expressions;
using System.Xml.Linq;
using System.Text;

namespace Client.Logic
{
    public static class HTTPLogic
    {
        public static string IP { get; set; } = "";

        public static ushort Port { get; set; }


        public static CreateStatus Create(EntryInModel data)
        {


            CreateStatus status = new CreateStatus();
            using HttpClient client = new HttpClient();

            HttpResponseMessage response = client.PostAsync($"http://{IP}:{Port}/api/create", JsonContent.Create(data, data.GetType(), MediaTypeHeaderValue.Parse("application/json"), new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            })).Result;

            if (!response.IsSuccessStatusCode)
            {
                status.SuccessRet = false;
                status.Id = -1;

                return status;
            }

            string responseString = response.Content.ReadAsStringAsync().Result;

            status.SuccessRet = true;
            status.Id = int.Parse(responseString);

            return status;
        }

        public static GetUpdateDeleteStatus BindNewBorrower(int id, PersonInModel data)
        {
            GetUpdateDeleteStatus status = new GetUpdateDeleteStatus();
            using HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("id", new string[] { id.ToString() });

            HttpResponseMessage response = client.PutAsync($"http://{IP}:{Port}/api/bind-new-borrower", JsonContent.Create(data, data.GetType(), MediaTypeHeaderValue.Parse("application/json"), new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            })).Result;

            if (!response.IsSuccessStatusCode)
            {
                status.SuccessRet = false;
                status.SuccessDb = false;

                return status;
            }

            string responseString = response.Content.ReadAsStringAsync().Result;

            status.SuccessRet = true;
            status.SuccessDb = bool.Parse(responseString);

            return status;
        }


        public static GetUpdateDeleteStatus UpdateBorrowerName(int id, string expression, string newName)
        {
            IdnMapping map = new IdnMapping();

            GetUpdateDeleteStatus status = new GetUpdateDeleteStatus();
            using HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Patch, $"http://{IP}:{Port}/api/update-borrower-name")
            {
                Headers =
                {

                    { "id", new string[] { id.ToString() } },
                    { "expression", new string[] { map.GetAscii(expression) } },
                    { "newName", new string[] { map.GetAscii(newName) } }
                }
            };

            HttpResponseMessage response = client.SendAsync(request).Result;

            if (!response.IsSuccessStatusCode)
            {
                status.SuccessRet = false;
                status.SuccessDb = false;

                return status;
            }

            string responseString = response.Content.ReadAsStringAsync().Result;

            status.SuccessRet = true;
            status.SuccessDb = bool.Parse(responseString);

            return status;
        }

        public static GetUpdateDeleteStatus UpdateBorrowerClass(int id, string expression, string className)
        {
            IdnMapping map = new IdnMapping();

            GetUpdateDeleteStatus status = new GetUpdateDeleteStatus();
            using HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Patch, $"http://{IP}:{Port}/api/update-borrower-class")
            {
                Headers =
                {

                    { "id", new string[] { id.ToString() } },
                    { "expression", new string[] { map.GetAscii(expression) } },
                    { "className", new string[] { map.GetAscii(className) } }
                }
            };

            HttpResponseMessage response = client.SendAsync(request).Result;

            if (!response.IsSuccessStatusCode)
            {
                status.SuccessRet = false;
                status.SuccessDb = false;

                return status;
            }

            string responseString = response.Content.ReadAsStringAsync().Result;

            status.SuccessRet = true;
            status.SuccessDb = bool.Parse(responseString);

            return status;

        }

        public static GetUpdateDeleteStatus UpdateBorrowerBuilding(int id, string expression, string building)
        {
            IdnMapping map = new IdnMapping();

            GetUpdateDeleteStatus status = new GetUpdateDeleteStatus();
            using HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Patch, $"http://{IP}:{Port}/api/update-borrower-building")
            {
                Headers =
                {

                    { "id", new string[] { id.ToString() } },
                    { "expression", new string[] { map.GetAscii(expression) } },
                    { "building", new string[] { map.GetAscii(building) } }
                }
            };

            HttpResponseMessage response = client.SendAsync(request).Result;

            if (!response.IsSuccessStatusCode)
            {
                status.SuccessRet = false;
                status.SuccessDb = false;

                return status;
            }

            string responseString = response.Content.ReadAsStringAsync().Result;

            status.SuccessRet = true;
            status.SuccessDb = bool.Parse(responseString);

            return status;
        }

        public static GetUpdateDeleteStatus UnbindBorrower(int entryId, string expression)
        {
            IdnMapping map = new IdnMapping();

            GetUpdateDeleteStatus status = new GetUpdateDeleteStatus();
            using HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, $"http://{IP}:{Port}/api/unbind-borrower")
            {
                Headers =
                {

                    { "entryId", new string[] { entryId.ToString() } },
                    { "expression", new string[] { map.GetAscii(expression) } }
                }
            };

            HttpResponseMessage response = client.SendAsync(request).Result;

            if (!response.IsSuccessStatusCode)
            {
                status.SuccessRet = false;
                status.SuccessDb = false;

                return status;
            }

            string responseString = response.Content.ReadAsStringAsync().Result;

            status.SuccessRet = true;
            status.SuccessDb = bool.Parse(responseString);

            return status;
        }

        public static (EntryOutModel, GetUpdateDeleteStatus) GetById(int id)
        {
            GetUpdateDeleteStatus status = new GetUpdateDeleteStatus();
            using HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"http://{IP}:{Port}/api/get-by-id")
            {
                Headers =
                {
                    { "id", new string[] { id.ToString() } }
                }
            };

            HttpResponseMessage response = client.SendAsync(request).Result;

            if (!response.IsSuccessStatusCode)
            {
                status.SuccessRet = false;
                status.SuccessDb = false;

                return (new EntryOutModel() { Name = "Ошибка" }, status);
            }

            string responseString = response.Content.ReadAsStringAsync().Result;

            status.SuccessRet = true;

            EntryOutModel model = responseString.EntryOutModelJsonToClass();

            status.SuccessDb = true;

            return (model, status);
        }

        public static (List<EntryOutModel>, GetUpdateDeleteStatus) GetAll()
        {
            GetUpdateDeleteStatus status = new GetUpdateDeleteStatus();
            using HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"http://{IP}:{Port}/api/get-all");

            HttpResponseMessage response = client.SendAsync(request).Result;

            if (!response.IsSuccessStatusCode)
            {
                status.SuccessRet = false;
                status.SuccessDb = false;

                return (new List<EntryOutModel>(new[] { new EntryOutModel() { Name = "Ошибка" } }), status);
            }

            string responseString = response.Content.ReadAsStringAsync().Result;

            status.SuccessRet = true;

            List<EntryOutModel> models = responseString.MultEntryOutModelsJsonToClassBulk().ToList();

            status.SuccessDb = true;

            return (models, status);
        }

        public static (List<EntryOutModel>, GetUpdateDeleteStatus) Search(string searchTerm)
        {
            IdnMapping map = new IdnMapping();

            GetUpdateDeleteStatus status = new GetUpdateDeleteStatus();
            using HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"http://{IP}:{Port}/api/get-search")
            {
                Headers =
                {
                    { "searchTerm", new string[] { map.GetAscii(searchTerm) } }
                }
            };

            HttpResponseMessage response = client.SendAsync(request).Result;

            if (!response.IsSuccessStatusCode)
            {
                status.SuccessRet = false;
                status.SuccessDb = false;

                return (new List<EntryOutModel>(new[] { new EntryOutModel() { Name = "Ошибка" } }), status);
            }

            string responseString = response.Content.ReadAsStringAsync().Result;

            status.SuccessRet = true;

            List<EntryOutModel> models = responseString.MultEntryOutModelsJsonToClassBulk().ToList();

            status.SuccessDb = true;

            return (models, status);
        }

        public static GetUpdateDeleteStatus UpdateState(int id, string state)
        {
            IdnMapping map = new IdnMapping();

            GetUpdateDeleteStatus status = new GetUpdateDeleteStatus();
            using HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Patch, $"http://{IP}:{Port}/api/update-state")
            {
                Headers =
                {
                    { "id", new string[] { id.ToString() } },
                    { "state", new string[] { map.GetAscii(state) } }
                }
            };

            HttpResponseMessage response = client.SendAsync(request).Result;

            if (!response.IsSuccessStatusCode)
            {
                status.SuccessRet = false;
                status.SuccessDb = false;

                return status;
            }

            string responseString = response.Content.ReadAsStringAsync().Result;

            status.SuccessRet = true;
            status.SuccessDb = bool.Parse(responseString);

            return status;
        }

        public static GetUpdateDeleteStatus UpdateName(int id, string name)
        {
            IdnMapping map = new IdnMapping();

            GetUpdateDeleteStatus status = new GetUpdateDeleteStatus();
            using HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Patch, $"http://{IP}:{Port}/api/update-name")
            {
                Headers =
                {
                    { "id", new string[] { id.ToString() } },
                    { "name", new string[] { map.GetAscii(name) } }
                }
            };

            HttpResponseMessage response = client.SendAsync(request).Result;

            if (!response.IsSuccessStatusCode)
            {
                status.SuccessRet = false;
                status.SuccessDb = false;

                return status;
            }

            string responseString = response.Content.ReadAsStringAsync().Result;

            status.SuccessRet = true;
            status.SuccessDb = bool.Parse(responseString);

            return status;
        }

        public static GetUpdateDeleteStatus UpdateQuantity(int id, uint quantity)
        {
            IdnMapping map = new IdnMapping();

            GetUpdateDeleteStatus status = new GetUpdateDeleteStatus();
            using HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Patch, $"http://{IP}:{Port}/api/update-quantity")
            {
                Headers =
                {
                    { "id", new string[] { id.ToString() } },
                    { "quantity", new string[] { quantity.ToString() } }
                }
            };

            HttpResponseMessage response = client.SendAsync(request).Result;

            if (!response.IsSuccessStatusCode)
            {
                status.SuccessRet = false;
                status.SuccessDb = false;

                return status;
            }

            string responseString = response.Content.ReadAsStringAsync().Result;

            status.SuccessRet = true;
            status.SuccessDb = bool.Parse(responseString);

            return status;
        }

        public static GetUpdateDeleteStatus UpdateUnit(int id, string unit)
        {
            IdnMapping map = new IdnMapping();

            GetUpdateDeleteStatus status = new GetUpdateDeleteStatus();
            using HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Patch, $"http://{IP}:{Port}/api/update-unit")
            {
                Headers =
                {
                    { "id", new string[] { id.ToString() } },
                    { "unit", new string[] { map.GetAscii(unit) } }
                }
            };

            HttpResponseMessage response = client.SendAsync(request).Result;

            if (!response.IsSuccessStatusCode)
            {
                status.SuccessRet = false;
                status.SuccessDb = false;

                return status;
            }

            string responseString = response.Content.ReadAsStringAsync().Result;

            status.SuccessRet = true;
            status.SuccessDb = bool.Parse(responseString);

            return status;
        }

        public static GetUpdateDeleteStatus UpdateDescription(int id, string description)
        {
            IdnMapping map = new IdnMapping();

            GetUpdateDeleteStatus status = new GetUpdateDeleteStatus();
            using HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Patch, $"http://{IP}:{Port}/api/update-desc")
            {
                Content = new StringContent("\"" + description + "\""),
                Headers =
                {
                    { "id", new string[] { id.ToString() } }
                }
            };

            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = client.SendAsync(request).Result;

            if (!response.IsSuccessStatusCode)
            {
                status.SuccessRet = false;
                status.SuccessDb = false;

                return status;
            }

            string responseString = response.Content.ReadAsStringAsync().Result;

            status.SuccessRet = true;
            status.SuccessDb = bool.Parse(responseString);

            return status;
        }

        public static GetUpdateDeleteStatus UpdateOwner(int id, string owner)
        {
            IdnMapping map = new IdnMapping();

            GetUpdateDeleteStatus status = new GetUpdateDeleteStatus();
            using HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Patch, $"http://{IP}:{Port}/api/update-owner")
            {
                Headers =
                {
                    { "id", new string[] { id.ToString() } },
                    { "owner", new string[] { map.GetAscii(owner) } }
                }
            };

            HttpResponseMessage response = client.SendAsync(request).Result;

            if (!response.IsSuccessStatusCode)
            {
                status.SuccessRet = false;
                status.SuccessDb = false;

                return status;
            }

            string responseString = response.Content.ReadAsStringAsync().Result;

            status.SuccessRet = true;
            status.SuccessDb = bool.Parse(responseString);

            return status;
        }

        public static GetUpdateDeleteStatus Delete(int id)
        {
            GetUpdateDeleteStatus status = new GetUpdateDeleteStatus();
            using HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, $"http://{IP}:{Port}/api/delete")
            {
                Headers =
                {
                    { "id", new string[] { id.ToString() } },
                }
            };

            HttpResponseMessage response = client.SendAsync(request).Result;

            if (!response.IsSuccessStatusCode)
            {
                status.SuccessRet = false;
                status.SuccessDb = false;

                return status;
            }

            string responseString = response.Content.ReadAsStringAsync().Result;

            status.SuccessRet = true;
            status.SuccessDb = bool.Parse(responseString);

            return status;
        }
    }
}

