using Newtonsoft.Json;
using System.Collections.Generic;

namespace Azure.Migrate.Export.Models
{
    public class BusinessCaseSettingsJSON
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("properties")]
        public BuisnessCaseProperty Properties = new BuisnessCaseProperty();
    }

    public class BuisnessCaseProperty
    {
        [JsonProperty("settings")]
        public BusinessCaseSettings Settings { get; set; } = new BusinessCaseSettings();
    }

    public class BusinessCaseSettings
    {
        [JsonProperty("azureSettings")]
        public BusinessCaseAzureSettings AzureSettings { get; set; } = new BusinessCaseAzureSettings();
    }
    

    public class BusinessCaseAzureSettings
    {
        [JsonProperty("targetLocation")]
        public string TargetLocation { get; set; }

        [JsonProperty("discountPercentage")]
        public int DiscountPercentage { get; set; } = 0;

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("workloadDiscoverySource")]
        public string WorkloadDiscoverySource { get; set; }

        [JsonProperty("businessCaseType")]
        public string BusinessCaseType { get; set; }

        [JsonProperty("savingsOption")]
        public string SavingsOption { get; set; }

        [JsonProperty("perYearMigrationCompletionPercentage")]
        public Dictionary<string, double> PerYearMigrationCompletionPercentage { get; set; } =
            new Dictionary<string, double>()
            {
                { "Year0", 0 },
                { "Year1", 20 },
                { "Year2", 50 },
                { "Year3", 100 },
            };
    }
}