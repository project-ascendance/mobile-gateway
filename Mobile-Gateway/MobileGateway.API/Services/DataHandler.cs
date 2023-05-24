using MobileGateway.API.Services.Contracts;
using MobileGateway.Models.DTOs.Content;
using System.Linq;
using System.Text.Json;

namespace MobileGateway.API.Services
{
    public class DataHandler : IDatahandler
    {
        public List<ContentDTO> ContentDTOs { get; set; }
        private int _maxId = 0;

        public DataHandler()
        {
            ReadFromFile();
            bool idsUpdated = false;
            if (ContentDTOs != null && ContentDTOs.Any())
            {
                for (int i = 0; i < ContentDTOs.Count; i++)
                {
                    ContentDTO contentDTO = ContentDTOs[i];
                    if (_maxId < contentDTO.Id)
                    {
                        _maxId = contentDTO.Id;
                    }
                    while (ContentDTOs.Count(x => contentDTO.Id == x.Id) > 1)
                    {
                        contentDTO.Id++;
                    }
                    contentDTO.Image = UnpackImage(contentDTO.Image);
                }
            }
            else
            {
                // This should never run.
                ContentDTOs = new List<ContentDTO>();
            }
            WriteToFile();
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
            contentDTO.Image = UnpackImage(contentDTO.Image);
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
            contentDTO.Image = UnpackImage(contentDTO.Image);
            if (contentDTO.Id != null && contentDTO.Id > 0)
            {
                if (!ContentDTOs.Any(x => x.Id == contentDTO.Id))
                {
                    ContentDTOs.Add(contentDTO);
                }
            }
            else
            {
                contentDTO.Id = ++_maxId;
                ContentDTOs.Add(contentDTO);
            }
            WriteToFile();
        }

        private void WriteToFile()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(ContentDTOs, options);

            File.WriteAllText($@"testData.json", json);
        }

        private void ReadFromFile()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = File.ReadAllText($@"testData.json");
            List<ContentDTO> contentDtos = JsonSerializer.Deserialize<List<ContentDTO>>(json, options) ?? new List<ContentDTO>();
            ContentDTOs = contentDtos.ToList();
        }
        private static string UnpackImage(string image)
        {
            if (image != null)
            {

                if (image != "")
                {
                    if (image.Contains("{\"data\":\""))
                    {
                        int base64ImgStart = image.IndexOf("{\"data\":\"") + "{\"data\":\"".Length;
                        int base64ImgEnd = image.IndexOf("\",\"type\":\"");
                        return image[base64ImgStart..base64ImgEnd];
                    }
                }
                if (image.Contains("string"))
                {
                    return "";
                }
            }
            return image ?? "";
        }
    }
}
