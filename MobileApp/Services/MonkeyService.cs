
using MobileApp.Model;
using System.Net.Http.Json;

namespace MobileApp.Services
{

    public class MonkeyService
    {
        List<Monkey> monkeyList = new();
        HttpClient httpClient;

        public MonkeyService() 
        {
            httpClient = new HttpClient();
        }

        public async Task<List<Monkey>> GetMonkeysAsync()
        {
            if (monkeyList.Count != 0)
            {
                return monkeyList;
            }

            var response = await httpClient.GetAsync("https://raw.githubusercontent.com/tdtrevathan/monkeys/main/monkeys.json");


            if (response.IsSuccessStatusCode)
            {
                monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();
            }

            return monkeyList;
        }
    }

}
