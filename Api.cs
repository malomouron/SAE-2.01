using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiGetPost
{
    
    public class Api
    {
        const string motDePasse = "WawUnM0tDeP8asseUltraS3curis33CestIncroyable!2837 :)";
        public static async Task PostScore(string nameVal = "John Doe", int scoreVal = 0)
        {
            const string apiUrl = "https://malomouron.fr/api/post";

            var newItem = new { name = nameVal, score = scoreVal, mdp= motDePasse };
            string json = JsonConvert.SerializeObject(newItem);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    
                    //Bloc de code modifiable
                    Console.WriteLine(responseBody);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
            }
        }


        public static async Task GetScore()
        {
            const string apiUrl = "https://malomouron.fr/api/get";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    List<AllOfFameData> data = JsonConvert.DeserializeObject<List<AllOfFameData>>(responseBody);

                    
                    //Bloc de code modifiable
                    foreach (var item in data)
                    {
                        Console.WriteLine($"ID: {item.id_score}, Name: {item.name}, Score: {item.score}, Date: {item.date}");  
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
            }
        }
    }


    public class AllOfFameData
    {
        public int id_score { get; set; }
        public string name { get; set; }
        public int score { get; set; }
        public string date { get; set; }
            
    }
}