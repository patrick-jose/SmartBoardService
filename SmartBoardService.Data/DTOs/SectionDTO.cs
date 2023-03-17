using System;
using System.Text.Json.Serialization;

namespace SmartBoardService.Data.DTOs
{
	public class SectionDTO
	{
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("active")]
        public bool Active { get; set; }
        [JsonPropertyName("position")]
        public long Position { get; set; }
        [JsonPropertyName("boardId")]
        public long BoardId { get; set; }
    }
}

