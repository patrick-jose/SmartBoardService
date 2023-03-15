using System;
using System.Text.Json.Serialization;

namespace SmartBoardService.Data.DTOs
{
	public class StatusHistoryDTO
	{
        [JsonPropertyName("user")]
        public UserDTO User { get; set; }
        [JsonPropertyName("previousSection")]
        public SectionDTO PreviousSection { get; set; }
        [JsonPropertyName("actualSection")]
        public SectionDTO ActualSection { get; set; }
        [JsonPropertyName("dateModified")]
        public DateTime DateModified { get; set; }
        [JsonPropertyName("taskId")]
        public long TaskId { get; set; }
    }
}

