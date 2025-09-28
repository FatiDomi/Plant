using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;
using Plant.WebApp.Database;
using Plant.WebApp.Models;

namespace Plant.WebApp.Repository
{
    public class PlantaRepository
    {
        private readonly AppDbContext _context;
        public PlantaRepository(AppDbContext context)
        {
            _context = context;
        }

        /// Buscar plantas por el nombre o el nombre científico.
        /// La búsqueda es insensible a las mayúsculas y minúsculas y a las tildes, además aplica
        /// la simplificación de plural ('es' / 's') para mejorar las coincidencias. :)
        /// y devuelve una lista vacía si no hay coincidencias.

        public async Task<List<Planta>> BuscarPorTexto(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return new List<Planta>();

            string clave = Normalizar(texto);

            var plantas = await _context.Plantas.ToListAsync();

            var resultado = plantas
                .Where(p =>
                    Normalizar(p.Nombre ?? string.Empty).Contains(clave) ||
                    Normalizar(p.NombreCientifico ?? string.Empty).Contains(clave)
                )
                .ToList();

            return resultado; // puede ser lista vacía si no hay coincidencias
        }
        // Normalizamos: minusculas, quitar tildes, simplificar plural
        private string Normalizar(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;
            var lower = input.ToLowerInvariant();
            var sinAcentos = EliminarDiacritics(lower);
            var simple = SimplificarPlural(sinAcentos);
            return simple;
        }

        // Quitar tildes/diacríticos
        private string EliminarDiacritics(string text)
        {

            var normalized = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (var c in normalized)
            {
                var cat = CharUnicodeInfo.GetUnicodeCategory(c);
                if (cat != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        // Heurística simple para quitar plurales: 'es' o 's'
        private string SimplificarPlural(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            if (s.EndsWith("es") && s.Length > 2) return s.Substring(0, s.Length - 2);
            if (s.EndsWith("s") && s.Length > 1) return s.Substring(0, s.Length - 1);
            return s;
        }
    
    
        //Metodo para obtener todas las plantas

        public async Task<List<Planta>> ObtenerTodasLasPlantas()
        {
            return await _context.Plantas.ToListAsync();
        }

        public async Task InsertarPlantaAsync(Planta planta)
        {
            if (planta == null) throw new ArgumentNullException(nameof(planta));

            _context.Plantas.Add(planta);
            await _context.SaveChangesAsync();
        }

        public async Task BorrarPlantaAsync(Planta planta)
        {
            if (planta == null) throw new ArgumentNullException(nameof(planta));

            _context.Plantas.Remove(planta);
            await _context.SaveChangesAsync();
        }


        public async Task ActualizarPlantaAsync(Planta planta)
        {
            if (planta == null) throw new ArgumentNullException(nameof(planta));

            _context.Plantas.Update(planta);
            await _context.SaveChangesAsync();
        }



    }
}