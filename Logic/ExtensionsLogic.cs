using Client.Models;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using System.Xml.Linq;

namespace Client.Logic
{
    public static class ExtensionsLogic
    {
        public static IEnumerable<EntryOutModel> MultEntryOutModelsJsonToClassBulk(this string json)
        {
            JArray response = JArray.Parse(json);

            foreach (JToken item in response)
            {
                JArray borrowingPeople = item["borrowingPeople"].Value<JArray>();

                List<PersonOutModel> temp = new List<PersonOutModel>();

                foreach (JToken subItem in borrowingPeople)
                {
                    temp.Add(new PersonOutModel()
                    {
                        Id = subItem["id"].Value<int>(),
                        Name = subItem["name"].Value<string>(),
                        Class = subItem["class"].Value<string>(),
                        Building = subItem["building"].Value<string>(),

                    });
                }

                yield return new EntryOutModel()
                {
                    Id = item["id"].Value<int>(),
                    State = item["state"].Value<string>(),
                    Name = item["name"].Value<string>(),
                    Quantity = item["quantity"].Value<uint>(),
                    Unit = item["unit"].Value<string>(),
                    Description = item["description"].Value<string>(),
                    Owner = item["owner"].Value<string>(),
                    BorrowingPeople = temp

                };
            }
        }

        public static EntryOutModel EntryOutModelJsonToClass(this string json)
        {
            JToken item = JToken.Parse(json);

            JArray borrowingPeople = item["borrowingPeople"].Value<JArray>();

            List<PersonOutModel> temp = new List<PersonOutModel>();

            foreach (JToken subItem in borrowingPeople)
            {
                temp.Add(new PersonOutModel()
                {
                    Id = subItem["id"].Value<int>(),
                    Name = subItem["name"].Value<string>(),
                    Class = subItem["class"].Value<string>(),
                    Building = subItem["building"].Value<string>(),

                });
            }

            return new EntryOutModel()
            {
                Id = item["id"].Value<int>(),
                State = item["state"].Value<string>(),
                Name = item["name"].Value<string>(),
                Quantity = item["quantity"].Value<uint>(),
                Unit = item["unit"].Value<string>(),
                Description = item["description"].Value<string>(),
                Owner = item["owner"].Value<string>(),
                BorrowingPeople = temp

            };
        }
    }
}

