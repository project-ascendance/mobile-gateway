using MobileGateway.API.Services.Contracts;
using MobileGateway.Models.DTOs.Content;
using System.Text.Json;

namespace MobileGateway.API.Services
{
    public class DataHandler : IDatahandler
    {
        public List<ContentDTO> ContentDTOs { get; set; }

        public DataHandler()
        {
            ContentDTOs = ReadFromFile();
        }

        public void DeleteContentDTO(string id)
        {
            ContentDTOs.Remove(GetContentDTO(id));
            WriteToFile();
        }

        public List<ContentDTO> GetAllContentDTOs()
        {
            return ContentDTOs;
        }

        public ContentDTO GetContentDTO(string id)
        {
            return ContentDTOs.Single(c => c.Id.Equals(id));
        }

        public void UpdateContentDTO(ContentDTO contentDTO)
        {
            if (ContentDTOs.Exists(c => c.Id.Equals(contentDTO.Id)))
            {
                ContentDTOs[contentDTO.Id] = contentDTO;
            }
            else
            {
                ContentDTOs.Add(contentDTO);
            }

            WriteToFile();
        }

        public void AddContentCTO(ContentDTO contentDTO)
        {
            ContentDTOs.Add(contentDTO);
            WriteToFile();
        }

        private void WriteToFile()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(ContentDTOs, options);

            File.WriteAllText($@"testData.json", json);
        }

        private List<ContentDTO> ReadFromFile()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = File.ReadAllText($@"testData.json");
            if (json.Equals(string.Empty)) return new List<ContentDTO>();
            List<ContentDTO> contentDtos = JsonSerializer.Deserialize<List<ContentDTO>>(json, options);
            return contentDtos;
        }
    }
}
