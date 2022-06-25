using Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicesLibrary.Utilites;

namespace ServicesLibrary.Utilites
{
    public class HttpVerbs
    {
        public static async Task<T> GetAsync<T>(string uri)
        {
            string response;
            using(var client=new HttpClient())
            {
                response = await client.GetStringAsync(uri);                
            }
             return response.Deserialize<T>();           
        }
    }
}
