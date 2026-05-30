using Colorado.Application.Dtos;
using Colorado.Application.Interfaces;
using Colorado.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Colorado.WebUI.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly ITipoTelefoneService _tipotelefoneService;
        private readonly IWebHostEnvironment _environment;

        public ClientesController(IClienteService clienteService, ITipoTelefoneService tipoTelefoneService, IWebHostEnvironment environment)
        {
            _clienteService = clienteService;
            _environment = environment;
            _tipotelefoneService = tipoTelefoneService;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clientes = _clienteService.ListAll();
            return View(await clientes);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
                return NotFound();

            var livroDto = await _clienteService.Read(id);

            if (livroDto == null) return NotFound();

            return View(livroDto);
        }


        // POST /Clientes/Create  (called via jQuery AJAX in the view)
        [HttpPost]
        [IgnoreAntiforgeryToken]  // Token é validado via header X-XSRF-TOKEN configurado no Program.cs
        public async Task<IActionResult> Create([FromBody] ClienteDto payload)
        {
            if (payload is null)
                return BadRequest(new { message = "Payload inválido ou Content-Type incorreto." });

            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            var created = await _clienteService.Create(payload);
            return Ok(new { id = created.CodigoCliente });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClienteDto clienteDto)
        {
            if (ModelState.IsValid)
            {
                await _clienteService.Update(clienteDto);
                return RedirectToAction(nameof(Index));
            }
            return View(clienteDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
                return NotFound();

            var clienteDto = await _clienteService.Read(id);

            if (clienteDto == null) return NotFound();

            return View(clienteDto);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _clienteService.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null) return NotFound();

            var clienteDto = await _clienteService.Read(id);

            if (clienteDto == null) return NotFound();
            var wwwroot = _environment.WebRootPath;


            return View(clienteDto);
        }
        private async Task PopulateTiposSelectList()
        {
            var tipos = await _tipotelefoneService.ListAll();
            ViewBag.TiposTelefone = new SelectList(tipos, "CodigoTipoTelefone", "DescricaoTipoTelefone");
            ViewBag.TiposTelefoneJson = System.Text.Json.JsonSerializer.Serialize(tipos,
                new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase
                });
        }
    }
}
