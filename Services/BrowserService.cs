using FizzBuzzWeb.Interfaces;

namespace FizzBuzzWeb.Services
{
    public class BrowserService : IBrowserService
    {
        public async Task<string> GetName(string name)
        {
            if (name.Contains("Edge") || name.Contains("Explorer")) {
                return "https://www.mozilla.org/pl/firefox/new";
            }
            return "";
        }
    }
}
