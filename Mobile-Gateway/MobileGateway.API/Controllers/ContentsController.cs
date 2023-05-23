using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileGateway.API.Services.Contracts;
using MobileGateway.Models.DTOs.Content;
using System.Text.Json;

namespace MobileGateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentsController : ControllerBase
    {
        private readonly IDatahandler _datahandler;
        public ContentsController(IDatahandler datahandler)
        {
            _datahandler = datahandler;
        }

        [HttpGet]
        public ActionResult<List<ContentDTO>> GetAllContents()
        {
            try
            {
                return _datahandler.GetAllContentDTOs();
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ContentDTO> GetContent(int id)
        {
            try
            {
                return _datahandler.GetContentDTO(id);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public ActionResult PostContent([FromBody]ContentDTO content)
        {
            try
            {
                _datahandler.AddContentDTO(content);
                return Ok();
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
            
        }

        [HttpPut]
        public ActionResult PutContent([FromBody]ContentDTO content)
        {
            try
            {
                _datahandler.UpdateContentDTO(content);
                return Ok();
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteContent(int id)
        {
            try
            {
                _datahandler.DeleteContentDTO(id);
                return Ok();
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
    }
}
