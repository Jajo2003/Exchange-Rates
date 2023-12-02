using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Net.Http;


namespace Valuta.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult StartScreen()
        {
            return View();
        }
		public async Task<IActionResult> Exchange() 
        {

			string apiResponse = await PostDatas.Main();

            JsonDocument doc = JsonDocument.Parse(apiResponse);

            JsonElement eurRateBuy = doc.RootElement.GetProperty("commercialRatesList")[0].GetProperty("buy");
            JsonElement eurRateSell = doc.RootElement.GetProperty("commercialRatesList")[0].GetProperty("sell");
            ViewBag.EuroBuy = eurRateBuy.GetDecimal();
            ViewBag.EuroSell = eurRateSell.GetDecimal();

            JsonElement usdRateBuy = doc.RootElement.GetProperty("commercialRatesList")[1].GetProperty("buy");
            JsonElement usdRateSell = doc.RootElement.GetProperty("commercialRatesList")[1].GetProperty("sell");
            ViewBag.UsdBuy = usdRateBuy.GetDecimal();
            ViewBag.UsdSell = usdRateSell.GetDecimal();

            return View();
        }
    }

    public class PostDatas
    {

        public static async Task<string> Main()
        {
            string apiUrl = "https://test-api.tbcbank.ge/v1/exchange-rates/commercial?currency=usd,eur";
            string apiKey = "I3Rz8QXBVPofKtucsenkW7g2n7aDwqBg";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("apikey", apiKey);

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string body = await response.Content.ReadAsStringAsync();
                    
                    return body;
                }
                else
                {
                    return string.Empty;
                }

            }


        }

    }


}
