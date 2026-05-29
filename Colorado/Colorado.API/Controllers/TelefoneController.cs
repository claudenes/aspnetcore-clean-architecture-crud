using Colorado.Application.Dtos;
using Colorado.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Colorado.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefoneController : ControllerBase
    {
        private readonly ITelefoneService _service;
        public TelefoneController(ITelefoneService service)
        {
            _service = service;
        }
        [HttpGet]
        public Object ListAll()
        {
            return _service.ListAll();
        }
        [HttpPost]
        public Object Create([FromBody] TelefoneDto telefoneDto)
        {
            return _service.Create(telefoneDto);
        }
        [HttpPut]
        public Object Update([FromBody] TelefoneDto telefoneDto)
        {
            return _service.Update(telefoneDto);
        }
        [HttpDelete]
        public Object Delete(int Id)
        {
            return _service.Delete(Id);
        }
    }
}
