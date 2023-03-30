using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MobileGateway.Models.DTOs.Content
{
    public class CreateContentDTO
    {
        [JsonPropertyName("type")] public string Type { get; set; }
        [JsonPropertyName("title")] public string Title { get; set; }
        [JsonPropertyName("sites")] public List<string> Sites { get; set; } = new List<string>();
        [JsonPropertyName("body")] public string Body { get; set; }
        [JsonPropertyName("image")] public string Image { get; set; }
        [JsonPropertyName("startDate")] public string StartDate { get; set; }
        [JsonPropertyName("endDate")] public string EndDate { get; set; }
        [JsonPropertyName("creationTime")] public string CreationTime { get; set; }
        [JsonPropertyName("author")] public string Author { get; set; }
    }
}
