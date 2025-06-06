using System.Text.Json.Serialization;

namespace CoinXplorer_API.DTOs
{
    // This class represents the response structure for a coin's listing
    public class CoinResponseDto
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        [JsonPropertyName("current_price")]
        public decimal CurrentPrice { get; set; }

        [JsonPropertyName("market_cap")]
        public decimal MarketCap { get; set; }

        [JsonPropertyName("market_cap_rank")]
        public int MarketCapRank { get; set; }

        [JsonPropertyName("fully_diluted_valuation")]
        public decimal? FullyDilutedValuation { get; set; }

        [JsonPropertyName("total_volume")]
        public decimal TotalVolume { get; set; }

        [JsonPropertyName("high_24h")]
        public decimal High24h { get; set; }

        [JsonPropertyName("low_24h")]
        public decimal Low24h { get; set; }

        [JsonPropertyName("price_change_24h")]
        public decimal PriceChange24h { get; set; }

        [JsonPropertyName("price_change_percentage_24h")]
        public double PriceChangePercentage24h { get; set; }

        [JsonPropertyName("market_cap_change_24h")]
        public decimal MarketCapChange24h { get; set; }

        [JsonPropertyName("market_cap_change_percentage_24h")]
        public double MarketCapChangePercentage24h { get; set; }

        [JsonPropertyName("circulating_supply")]
        public decimal CirculatingSupply { get; set; }

        [JsonPropertyName("total_supply")]
        public decimal? TotalSupply { get; set; }

        [JsonPropertyName("max_supply")]
        public decimal? MaxSupply { get; set; }

        [JsonPropertyName("ath")]
        public decimal Ath { get; set; }

        [JsonPropertyName("ath_change_percentage")]
        public double AthChangePercentage { get; set; }

        [JsonPropertyName("ath_date")]
        public DateTime AthDate { get; set; }

        [JsonPropertyName("atl")]
        public decimal Atl { get; set; }

        [JsonPropertyName("atl_change_percentage")]
        public double AtlChangePercentage { get; set; }

        [JsonPropertyName("atl_date")]
        public DateTime AtlDate { get; set; }

        public object Roi { get; set; }

        [JsonPropertyName("last_updated")]
        public DateTime LastUpdated { get; set; }
    }
}
