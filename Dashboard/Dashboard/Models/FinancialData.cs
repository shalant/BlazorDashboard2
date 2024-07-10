namespace Dashboard.Models;

public class FinancialData
{
    public string phone { get; set; }
    public string longBusinessSummary { get; set; }
    public int maxAge { get; set; }
    public int priceHint { get; set; }
    public double previousClose { get; set; }
    public double open { get; set; }
    public double dayLow { get; set; }
    public double dayHigh { get; set; }
    public double regularMarketPreviousClose { get; set; }
    public double regularMarketOpen { get; set; }
    public double regularMarketDayLow { get; set; }
    public double regularMarketDayHigh { get; set; }
    public double trailingPE { get; set; }
    public int volume { get; set; }
    public int regularMarketVolume { get; set; }
    public int averageVolume { get; set; }
    public int averageVolume10days { get; set; }
    public int averageDailyVolume10Day { get; set; }
    public double bid { get; set; }
    public double ask { get; set; }
    public int bidSize { get; set; }
    public int askSize { get; set; }
    public double yield { get; set; }
    public int totalAssets { get; set; }
    public double fiftyTwoWeekLow { get; set; }
    public double fiftyTwoWeekHigh { get; set; }
    public double fiftyDayAverage { get; set; }
    public double twoHundredDayAverage { get; set; }
    public double navPrice { get; set; }
    public string currency { get; set; }
    public string category { get; set; }
    public double ytdReturn { get; set; }
    public string fundFamily { get; set; }
    public int fundInceptionDate { get; set; }
    public string legalType { get; set; }
    public string exchange { get; set; }
    public string quoteType { get; set; }
    public string symbol { get; set; }
    public string underlyingSymbol { get; set; }
    public string shortName { get; set; }
    public string longName { get; set; }
    public int firstTradeDateEpochUtc { get; set; }
    public string timeZoneFullName { get; set; }
    public string timeZoneShortName { get; set; }
    public string uuid { get; set; }
    public string messageBoardId { get; set; }
    public int gmtOffSetMilliseconds { get; set; }
    public object trailingPegRatio { get; set; }
}
