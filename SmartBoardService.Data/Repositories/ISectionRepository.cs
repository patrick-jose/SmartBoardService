using SmartBoardService.Data.DTOs;

namespace SmartBoardService.Data.Repositories
{
    public interface ISectionRepository
    {
        Task<bool> InsertSectionAsync(SectionDTO section);
        Task<bool> UpdateSectionAsync(SectionDTO section);
        Task<bool> UpdateSectionsAsync(List<SectionDTO> sections);
    }
}