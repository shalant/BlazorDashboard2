using Dashboard.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Dashboard.Components.Pages;

public partial class Home
{

    private List<MyData> Data { get; set; } = new();
    private List<MyData> Data2 { get; set; } = new();
    public string FinancialData { get; set; } = "";
    public FinancialData dowObject { get; set; } = new();
    public FinancialData spObject { get; set; } = new();
    public FinancialData nasdaqObject { get; set; } = new();
    public HttpClient httpClient = new HttpClient();
    public double djPercentChange = 0;

    protected override void OnInitialized()
    {
        // FetchEconomicData();

        Data.Add(new MyData { Category = "Jan", NetProfit = 12, Revenue = 33 });
        Data.Add(new MyData { Category = "Feb", NetProfit = 43, Revenue = 42 });
        Data.Add(new MyData { Category = "Mar", NetProfit = 112, Revenue = 23 });
        Data2.Add(new MyData { Category = "Apr", NetProfit = 52, Revenue = 83 });
        Data2.Add(new MyData { Category = "May", NetProfit = 42, Revenue = 42 });
        Data2.Add(new MyData { Category = "Jun", NetProfit = 72, Revenue = 113 });
        Data2.Add(new MyData { Category = "Jul", NetProfit = 82, Revenue = 123 });
        Data2.Add(new MyData { Category = "Aug", NetProfit = 92, Revenue = 143 });
    }

    public class MyData
    {
        public string Category { get; set; }
        public int NetProfit { get; set; }
        public int Revenue { get; set; }
    }

    public class MyData2
    {
        public string Category { get; set; }
        public int NetProfit { get; set; }
        public int Revenue { get; set; }
    }

    public async Task GetDjData()
    {
        // var client = new HttpClient();
        var requestDJ = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("https://yahoo-finance160.p.rapidapi.com/info"),
            Headers =
        {
            { "x-rapidapi-key", "d0a001874dmshb993809de6fe686p13f52cjsn2899437b8f3e" },
            { "x-rapidapi-host", "yahoo-finance160.p.rapidapi.com" },
        },
            Content = new StringContent("{\"stock\":\"^DJI\"}")
            {
                Headers =
                {
                    ContentType = new MediaTypeHeaderValue("application/json")
                }
            }
        };
        var responseDJ = await httpClient.SendAsync(requestDJ);
        var bodyDJ = await responseDJ.Content.ReadAsStringAsync();
        dowObject = JsonSerializer.Deserialize<FinancialData>(bodyDJ);
        if (dowObject != null) 
        {
            djPercentChange = Math.Round((dowObject.dayHigh / dowObject.previousClose),2);
        }
    }

    public async Task GetSpData()
    {
        //var client = new HttpClient();
        var requestSp = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("https://yahoo-finance160.p.rapidapi.com/info"),
            Headers =
        {
            { "x-rapidapi-key", "d0a001874dmshb993809de6fe686p13f52cjsn2899437b8f3e" },
            { "x-rapidapi-host", "yahoo-finance160.p.rapidapi.com" },
        },
            Content = new StringContent("{\"stock\":\"^GSPC\"}")
            {
                Headers =
                {
                    ContentType = new MediaTypeHeaderValue("application/json")
                }
            }
        };
        var responseSp = await httpClient.SendAsync(requestSp);
        var bodySp = await responseSp.Content.ReadAsStringAsync();
        spObject = JsonSerializer.Deserialize<FinancialData>(bodySp);
    }

    public async Task GetNasdaqData()
    {
        //var client = new HttpClient();
        var requestNasdaq = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("https://yahoo-finance160.p.rapidapi.com/info"),
            Headers =
        {
            { "x-rapidapi-key", "d0a001874dmshb993809de6fe686p13f52cjsn2899437b8f3e" },
            { "x-rapidapi-host", "yahoo-finance160.p.rapidapi.com" },
        },
            Content = new StringContent("{\"stock\":\"^IXIC\"}")
            {
                Headers =
                {
                    ContentType = new MediaTypeHeaderValue("application/json")
                }
            }
        };
        var responseNasdaq = await httpClient.SendAsync(requestNasdaq);
        var bodyNasdaq = await responseNasdaq.Content.ReadAsStringAsync();
        nasdaqObject = JsonSerializer.Deserialize<FinancialData>(bodyNasdaq);
    }

    // public async Task FetchEconomicData()
    // {
    //     // using System.Net.Http.Headers;
    //     var client = new HttpClient();
    //     var requestDJ = new HttpRequestMessage
    //         {
    //             Method = HttpMethod.Post,
    //             RequestUri = new Uri("https://yahoo-finance160.p.rapidapi.com/info"),
    //             Headers =
    //         {
    //             { "x-rapidapi-key", "d0a001874dmshb993809de6fe686p13f52cjsn2899437b8f3e" },
    //             { "x-rapidapi-host", "yahoo-finance160.p.rapidapi.com" },
    //         },
    //             Content = new StringContent("{\"stock\":\"^DJI\"}")
    //             {
    //                 Headers =
    //                 {
    //                     ContentType = new MediaTypeHeaderValue("application/json")
    //                 }
    //             }
    //         };
    //     var requestSP = new HttpRequestMessage
    //         {
    //             Method = HttpMethod.Post,
    //             RequestUri = new Uri("https://yahoo-finance160.p.rapidapi.com/info"),
    //             Headers =
    //         {
    //             { "x-rapidapi-key", "d0a001874dmshb993809de6fe686p13f52cjsn2899437b8f3e" },
    //             { "x-rapidapi-host", "yahoo-finance160.p.rapidapi.com" },
    //         },
    //             Content = new StringContent("{\"stock\":\"^GSPC\"}")
    //             {
    //                 Headers =
    //                 {
    //                     ContentType = new MediaTypeHeaderValue("application/json")
    //                 }
    //             }
    //         };
    //     var requestNasdaq = new HttpRequestMessage
    //         {
    //             Method = HttpMethod.Post,
    //             RequestUri = new Uri("https://yahoo-finance160.p.rapidapi.com/info"),
    //             Headers =
    //         {
    //             { "x-rapidapi-key", "d0a001874dmshb993809de6fe686p13f52cjsn2899437b8f3e" },
    //             { "x-rapidapi-host", "yahoo-finance160.p.rapidapi.com" },
    //         },
    //             Content = new StringContent("{\"stock\":\"^IXIC\"}")
    //             {
    //                 Headers =
    //                 {
    //                     ContentType = new MediaTypeHeaderValue("application/json")
    //                 }
    //             }
    //         };
    //     var responseDJ = await client.SendAsync(requestDJ);
    //     var responseSP = Task.Run(async delegate
    //     {
    //         await Task.Delay(1100);
    //         return await client.SendAsync(requestSP);
    //     });
    //     // await Task.Delay(1500).ContinueWith( client.SendAsync(requestSP));
    //     var responseNasdaq = await client.SendAsync(requestNasdaq);
    //     // {
    //     //     response.EnsureSuccessStatusCode();
    //     var bodyDJ = await responseDJ.Content.ReadAsStringAsync();
    //     var bodySP = await responseSP.Result.ReadAsStringAsync();
    //     var bodyNasdaq = await responseNasdaq.Content.ReadAsStringAsync();
    //     //     Console.WriteLine(body);
    //     // }
    //     FinancialData = bodyDJ.ToString();
    //     // FdObject = await httpClient.ReadFromJsonAsync<FinancialData>(request);
    //     dowObject = JsonSerializer.Deserialize<FinancialData>(bodyDJ);
    //     spObject = JsonSerializer.Deserialize<FinancialData>(bodySP);
    //     nasdaqObject = JsonSerializer.Deserialize<FinancialData>(bodyNasdaq);
    // }
}