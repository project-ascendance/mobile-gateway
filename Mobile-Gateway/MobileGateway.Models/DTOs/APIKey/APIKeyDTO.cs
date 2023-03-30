﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MobileGateway.Models.DTOs.APIKey
{
    public class APIKeyDTO
    {
        [JsonPropertyName("creationTime")] public string CreationTime { get; set; }
        [JsonPropertyName("key")] public string Key { get; set; }
    }
}
