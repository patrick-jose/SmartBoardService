using System;
using System.Text.Json.Serialization;

namespace SmartBoardService.Data.DTOs
{
	public class CommentDTO
	{
        [JsonPropertyName("writerId")]
        public long WriterId { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; }
        [JsonPropertyName("dateCreation")]
        public DateTime DateCreation { get; set; }
        [JsonPropertyName("taskId")]
        public long TaskId { get; set; }
    }
}

