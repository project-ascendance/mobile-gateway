using MobileGateway.Models.DTOs.Content;

namespace MobileGateway.API.Services.Contracts
{
    public interface IDatahandler
    {
        // This is a temporary datahandler for testing purposes
        public List<ContentDTO> GetAllContentDTOs();
        public ContentDTO GetContentDTO(string id);
        public void UpdateContentDTO(ContentDTO contentDTO);
        public void AddContentCTO(ContentDTO contentDTO);
        public void DeleteContentDTO(string id);
    }
}
