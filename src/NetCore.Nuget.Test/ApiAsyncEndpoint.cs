
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NetCore.Nuget.Test
{
    public class ApiAsyncEndpoint
    {
        public async Task<string> GetPersons(int age)
        {
            try
            {
                var persons = new List<Person>() { new Person() { Name = "First" }, new Person() { Name = "second" } };
                var res = await Task.Factory.StartNew((() => JsonConvert.SerializeObject(persons)));
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Person>> GetPersonsAsObj(int age)
        {
            var persons = await GetPersons(age);
            var personObjs = JsonConvert.DeserializeObject<IEnumerable<Person>>(persons);
            return personObjs;
        }
    }
}
