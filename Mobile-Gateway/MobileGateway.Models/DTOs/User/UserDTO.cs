﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MobileGateway.Models.DTOs.User
{
    public class UserDTO
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("firstName")] public string FirstName { get; set; }
        [JsonPropertyName("lastName")] public string LastName { get; set; }
        [JsonPropertyName("email")] public string Email { get; set; }
        [JsonPropertyName("username")] public string Username { get; set; }
        [JsonPropertyName("role")] public string Role { get; set; }
    }
}
