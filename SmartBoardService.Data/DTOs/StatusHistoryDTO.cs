using System;
using System.Text.Json.Serialization;

namespace SmartBoardService.Data.DTOs
{
	public class StatusHistoryDTO
	{
        [JsonPropertyName("userId")]
        public long UserId { get; set; }
        [JsonPropertyName("previousSectionId")]
        public long PreviousSectionId { get; set; }
        [JsonPropertyName("actualSectionId")]
        public long ActualSectionId { get; set; }
        [JsonPropertyName("dateModified")]
        public DateTime DateModified { get; set; }
        [JsonPropertyName("taskId")]
        public long TaskId { get; set; }
    }
}

