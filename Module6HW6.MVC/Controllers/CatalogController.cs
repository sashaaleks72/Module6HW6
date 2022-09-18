using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Module6HW4.Models;
using Module6HW4.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Module6HW4.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CatalogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeapots()
        {
            List<Teapot> teapots = null;

            var httpClient = _httpClientFactory.CreateClient();
            var accessToken = await GetAccessToken();

            httpClient.SetBearerToken(accessToken);
            var response = await httpClient.GetAsync("https://localhost:44374/api/teapots");

            var serializedTeapots = await response.Content.ReadAsStringAsync();

            teapots = JsonConvert.DeserializeObject<List<Teapot>>(serializedTeapots);

            return View(teapots);
        }

        public async Task<IActionResult> GetTeapotById(Guid id)
        {
            Teapot teapot = null;

            var httpClient = _httpClientFactory.CreateClient();
            var accessToken = await GetAccessToken();

            httpClient.SetBearerToken(accessToken);
            var response = await httpClient.GetAsync($"https://localhost:44374/api/teapots/{id}");

            var serializedTeapots = await response.Content.ReadAsStringAsync();

            teapot = JsonConvert.DeserializeObject<Teapot>(serializedTeapots);

            return View(teapot);
        }

        public IActionResult AddTeapot()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTeapot(TeapotViewModel teapotFromBody)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var accessToken = await GetAccessToken();

            httpClient.SetBearerToken(accessToken);
            var body = new StringContent(JsonConvert.SerializeObject(teapotFromBody), Encoding.Unicode, "application/json");

            await httpClient.PostAsync($"https://localhost:44374/api/teapots/", body);

            return RedirectToAction("GetTeapots");
        }

        [HttpGet]
        public async Task<IActionResult> EditTeapotById(Guid id)
        {
            Teapot teapot = null;

            var httpClient = _httpClientFactory.CreateClient();
            var accessToken = await GetAccessToken();

            httpClient.SetBearerToken(accessToken);
            var response = await httpClient.GetAsync($"https://localhost:44374/api/teapots/{id}");

            var serializedTeapots = await response.Content.ReadAsStringAsync();

            teapot = JsonConvert.DeserializeObject<Teapot>(serializedTeapots);

            return View(teapot);
        }

        [HttpPost]
        public async Task<IActionResult> EditTeapotById(Teapot teapot)
        {
            var teapotFromView = new TeapotViewModel
            {
                ImgUrl = teapot.ImgUrl,
                Capacity = teapot.Capacity,
                Price = teapot.Price,
                Description = teapot.Description,
                ManufacturerCountry = teapot.ManufacturerCountry,
                Quantity = teapot.Quantity,
                Title = teapot.Title,
                WarrantyInMonths = teapot.WarrantyInMonths
            };

            var httpClient = _httpClientFactory.CreateClient();
            var accessToken = await GetAccessToken();

            httpClient.SetBearerToken(accessToken);
            var body = new StringContent(JsonConvert.SerializeObject(teapotFromView), Encoding.Unicode, "application/json");

            await httpClient.PutAsync($"https://localhost:44374/api/teapots/{teapot.Id}", body);

            return RedirectToAction("GetTeapots");
        }

        public async Task<IActionResult> DeleteTeapotById(Guid id)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var accessToken = await GetAccessToken();

            httpClient.SetBearerToken(accessToken);
            await httpClient.DeleteAsync($"https://localhost:44374/api/teapots/{id}");

            return RedirectToAction("GetTeapots");
        }

        private async Task<string> GetAccessToken()
        {
            var httpClientForIdentityServer = _httpClientFactory.CreateClient();

            var discoveryDocument = await httpClientForIdentityServer.GetDiscoveryDocumentAsync("https://localhost:44368");
            var token = await httpClientForIdentityServer.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = discoveryDocument.TokenEndpoint,
                ClientId = "client_id",
                ClientSecret = "client_secret",
                Scope = "WebApi"
            });

            return token.AccessToken;
        }
    }
}
