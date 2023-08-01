using System.Text;
using BingSamples.Web.Core;
using BingSamples.Web.Models;
using BingSamples.Web.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BingSamples.Web.Services;

public class BingTranslatorService
{
    private readonly HttpClient client;

    public BingTranslatorService(IOptions<AppOptions> appOptionsValue, HttpClient client)
    {
        this.client = client;
        client.BaseAddress = new Uri(WebConstants.TranslatorBaseEndpoint, UriKind.Absolute);
        var appOptions = appOptionsValue.Value;
        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", appOptions.TranslatorSubscriptionKey);
        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Region", appOptions.TranslatorRegion);
    }

    public async Task<string> GetTranslatedTextAsync(string textToTranslate, string from = "en", string to = "he")
    {
        var route = $"translate?api-version=3.0&from={from}&to={to}";
        var body = new object[] { new { Text = textToTranslate } };
        var requestBody = JsonConvert.SerializeObject(body);

        using var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(route, UriKind.RelativeOrAbsolute),
            Content = new StringContent(requestBody, Encoding.UTF8, "application/json")
        };

        var response = await client.SendAsync(request);

        if (!response.IsSuccessStatusCode)
            return string.Empty;

        var translatedText = await response.Content.ReadAsStringAsync();
        var translatorModel = JsonConvert.DeserializeObject<TranslationModel[]>(translatedText);
        return translatorModel.Length > 0 ? translatorModel[0].Translations[0].Text : string.Empty;
    }
}