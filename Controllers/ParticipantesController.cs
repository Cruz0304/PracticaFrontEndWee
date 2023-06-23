using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PracticaFrontEnd.Data;
using PracticaFrontEnd.Models;


namespace PracticaFrontEnd.Controllers
{
    public class ParticipantesController : Controller
    {
        private readonly PracticaFrontEndContext _context;

        public ParticipantesController(PracticaFrontEndContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ConsultarSep(int cedula)
        {
            cedula = 11191881;
            var url = "https://cedulaprofesional.sep.gob.mx/cedula/buscaCedulaJson.action?json={%27maxResult%27:%27100%27,%27nombre%27:%27%27,%27paterno%27:%27%27,%27materno%27:%27%27,%27idCedula%27:%27" + cedula + "%27})";
            HttpClient _httpClient = new HttpClient();
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Datos? data = JsonConvert.DeserializeObject<Datos>(json);
                List<Items> dat = data.Items.ToList();
                return View(dat);
            }
            return View();
        }
        // GET: Participantes
        public async Task<IActionResult> Index()
        {
            HttpClient _httpClient = new HttpClient();
            string url = "https://localhost:44313/api/registro";
            List<Items> listaItem = await _httpClient.GetFromJsonAsync<List<Items>>(url);
            List<Items> showItems = new List<Items>();
            foreach (var obj in listaItem)
            {
                showItems.Add(new Items
                {
                    Cedula = obj.Cedula,
                    Correo = obj.Correo,
                    Nombre = obj.Nombre,
                    NombreCompania = obj.NombreCompania,
                    telefono = obj.telefono,
                    Titulo = obj.Titulo,
                });
            }
            var allItems = showItems.ToList();
            return View(allItems);
        }        

        // POST: Participantes/Create        
        public async Task<IActionResult> Create([Bind("id,NombreCompania,Cedula,Nombre,Titulo,Correo,telefono")] Items items)
        {
            if (ModelState.IsValid)
            {
                HttpClient httpClient= new HttpClient();
                string url = "https://localhost:44313/api/registro";
                var objItems = System.Text.Json.JsonSerializer.Serialize(items);
                HttpContent content = new StringContent(objItems,System.Text.Encoding.UTF8,"application/json");
                var result=await httpClient.PostAsync(url, content);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                
            }
            return View(items);
        }


    }
}
