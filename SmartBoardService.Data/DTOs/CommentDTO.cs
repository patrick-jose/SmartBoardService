using System;
using System.Text.Json.Serialization;

namespace SmartBoardService.Data.DTOs
{
	public class CommentDTO
	{
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("writer")]
        public UserDTO Writer { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; }
        [JsonPropertyName("dateCreation")]
        public DateTime DateCreation { get; set; }
	}
}

