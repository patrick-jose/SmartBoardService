using System;
using System.Text.Json.Serialization;

namespace SmartBoardService.Data.DTOs
{
	public class BoardDTO
	{
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("active")]
        public bool Active { get; set; }
        [JsonPropertyName("sections")]
        public List<SectionDTO> Sections { get; set; }
	}
}

