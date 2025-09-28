using Microsoft.AspNetCore.Mvc;
using Plant.WebApp.Models;
using Plant.WebApp.Repository;

namespace Plant.WebApp.Controllers
{
    public class PlantaController : Controller
    {
        private readonly PlantaRepository _plantaRepository;

        public PlantaController(PlantaRepository plantaRepository)
        {
            _plantaRepository = plantaRepository;
        }

        // BUSCAR PLANTAS POR TEXTO

        [HttpGet]
        public async Task<IActionResult> Index(string? texto)
        {
            texto = texto?.Trim();
            var plantas = new List<Planta>();

            if (!string.IsNullOrWhiteSpace(texto))
            {
                plantas = await _plantaRepository.BuscarPorTexto(texto);
            }

            if (!plantas.Any() && !string.IsNullOrWhiteSpace(texto))
            {
                ViewBag.Mensaje = "No hay resultados para esta búsqueda";
            }

            return View(plantas);
        }


        // MOSTRAR TODAS LAS PLANTAS

        [HttpGet]
        public async Task<IActionResult> MostrarTodas()
        {
            var plantas = await _plantaRepository.ObtenerTodasLasPlantas();
            return View("Index", plantas);
        }


        // INSERTAR NUEVA PLANTA - GET

        [HttpGet]
        public IActionResult Insertar()
        {
            // Retornamos un modelo vacío para el formulario
            return View();
        }


        // INSERTAR NUEVA PLANTA - POST

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Insertar(Planta planta)
        {
            planta.Nombre = planta.Nombre.Trim();
            planta.NombreCientifico = planta.NombreCientifico.Trim();
            planta.Origen = planta.Origen.Trim();
            planta.Descripcion = planta.Descripcion.Trim();
            planta.CuidadosBasicos = planta.CuidadosBasicos.Trim();
            planta.ClimaIdeal = planta.ClimaIdeal.Trim();
            planta.Floracion = planta.Floracion.Trim();
            planta.AlturaMaxima = planta.AlturaMaxima.Trim();
            planta.ImagenUrl = planta.ImagenUrl.Trim();

            if (!ModelState.IsValid)
                return View(planta);

            await _plantaRepository.InsertarPlantaAsync(planta);

            // Guardamos el mensaje en TempData
            TempData["MensajeAgregar"] = "Has agregado tu planta, ¡enhorabuena!";

            // Retornamos la misma vista con un modelo vacío
            return RedirectToAction("Insertar");
        }


        // BORRAR PLANTA - GET
        [HttpGet]
        public async Task<IActionResult> Borrar(int id)
        {
            var planta = (await _plantaRepository.ObtenerTodasLasPlantas())
                          .FirstOrDefault(p => p.Id == id);

            if (planta == null)
            {
                return NotFound();
            }

            return View(planta); // mostrar confirmación antes de borrar
        }

        // BORRAR PLANTA - POST

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarConfirmado(int id)
        {
            var planta = (await _plantaRepository.ObtenerTodasLasPlantas())
                          .FirstOrDefault(p => p.Id == id);

            if (planta == null)
                return NotFound();

            await _plantaRepository.BorrarPlantaAsync(planta);

            TempData["MensajeBorrar"] = "Has eliminado correctamente tu planta";

            return RedirectToAction("MostrarTodas"); 
        }


        
        // ACTUALIZAR PLANTA - GET
       
        [HttpGet]
        public async Task<IActionResult> Actualizar(int id)
        {
            // Buscamos la planta por el Id
            var planta = (await _plantaRepository.ObtenerTodasLasPlantas())
                         .FirstOrDefault(p => p.Id == id);

            if (planta == null)
            {
                return NotFound(); 
            }

            return View(planta); // mostramos la vista Actualizar con los datos
        }

   
        // ACTUALIZAR PLANTA - POST
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Actualizar(Planta planta)
        {
            if (!ModelState.IsValid)
            {
                // Si hay errores de validación, mostramos el formulario con los datos actuales
                return View(planta);
            }

            // Obtenemos la planta existente
            var plantaExistente = (await _plantaRepository.ObtenerTodasLasPlantas())
                                  .FirstOrDefault(p => p.Id == planta.Id);

            if (plantaExistente == null)
            {
                return NotFound();
            }

            // Actualizamos los campos
            plantaExistente.Nombre = planta.Nombre;
            plantaExistente.NombreCientifico = planta.NombreCientifico;
            plantaExistente.Origen = planta.Origen;
            plantaExistente.Descripcion = planta.Descripcion;
            plantaExistente.CuidadosBasicos = planta.CuidadosBasicos;
            plantaExistente.ClimaIdeal = planta.ClimaIdeal;
            plantaExistente.Floracion = planta.Floracion;
            plantaExistente.AlturaMaxima = planta.AlturaMaxima;
            plantaExistente.ImagenUrl = planta.ImagenUrl;

            // Guardamos cambios en la base de datos
            await _plantaRepository.ActualizarPlantaAsync(plantaExistente);

            TempData["MensajeActualizar"] = "Has actualizado la planta correctamente";

            // Redirigimos a la misma vista con el mensaje
            return RedirectToAction("Actualizar", new { id = planta.Id });
        }


    }
}
