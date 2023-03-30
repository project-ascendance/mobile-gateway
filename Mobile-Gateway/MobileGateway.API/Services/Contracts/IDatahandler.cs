using MobileGateway.Models.DTOs.Content;

namespace MobileGateway.API.Services.Contracts
{
    public interface IDatahandler
    {
        // This is a temporary datahandler for testing purposes
        public List<ContentDTO> GetAllContentDTOs();
        public ContentDTO GetContentDTO(int id);
        public void UpdateContentDTO(ContentDTO contentDTO);
        public void AddContentDTO(ContentDTO contentDTO);
        public void DeleteContentDTO(int id);
    }
}
