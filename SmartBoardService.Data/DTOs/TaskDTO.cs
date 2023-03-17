using System;
using System.Text.Json.Serialization;

namespace SmartBoardService.Data.DTOs
{
	public class TaskDTO
	{
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("creatorId")]
        public long CreatorId { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("dateCreation")]
        public DateTime DateCreation { get; set; }
        [JsonPropertyName("sectionId")]
        public long SectionId { get; set; }
        [JsonPropertyName("active")]
        public bool Active { get; set; }
        [JsonPropertyName("blocked")]
        public bool Blocked { get; set; }
        [JsonPropertyName("assigneeId")]
        public long? AssigneeId { get; set; }
        [JsonPropertyName("position")]
        public long Position { get; set; }
    }
}

