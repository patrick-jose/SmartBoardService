using System;
using System.Text.Json.Serialization;

namespace SmartBoardService.Data.DTOs
{
	public class UserDTO
	{
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}

