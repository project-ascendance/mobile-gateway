using MobileGateway.API.Services.Contracts;
using MobileGateway.Models.DTOs.Content;
using System.Linq;
using System.Text.Json;

namespace MobileGateway.API.Services
{
    public class DataHandler : IDatahandler
    {
        public List<ContentDTO> ContentDTOs { get; set; }

        public DataHandler()
        {
            ContentDTOs = ReadFromFile();
            bool idsUpdated = false;
            if (ContentDTOs != null && ContentDTOs.Any())
            {
                foreach (ContentDTO contentDTO in ContentDTOs)
                {
                    while (ContentDTOs.Count(x => contentDTO.Id == x.Id) > 1)
                    {
                        contentDTO.Id++;
                        idsUpdated = true;
                    }
                }
                if (idsUpdated)
                {
                    WriteToFile();
                }
            } else
            {
                // This should never run.
                ContentDTOs = new List<ContentDTO>();
            }
        }

        public void DeleteContentDTO(int id)
        {
            ContentDTOs.Remove(GetContentDTO(id));
            WriteToFile();
        }

        public List<ContentDTO> GetAllContentDTOs()
        {
            return ContentDTOs;
        }

        public ContentDTO GetContentDTO(int id)
        {
            return ContentDTOs.First(c => c.Id.Equals(id));
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

        public void AddContentDTO(ContentDTO contentDTO)
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
