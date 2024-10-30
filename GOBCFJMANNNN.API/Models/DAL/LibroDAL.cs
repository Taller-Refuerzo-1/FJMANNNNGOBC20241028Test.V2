using GOBCFJMANNNN.API.Models.EN;
using Microsoft.EntityFrameworkCore;

namespace GOBCFJMANNNN.API.Models.DAL
{
    public class LibroDAL
    {
        readonly LibroBDContext _context;

        //Constructor que interactua con base de datos
        public LibroDAL(LibroBDContext libroBDContext)
        {
            _context = libroBDContext;
        }

        //Task:Crear
        public async Task<int> Create(Libro libro)
        {
            _context.Add(libro);
            return await _context.SaveChangesAsync();
        }

        //Task: Obtener por Id
        public async Task<Libro> GetById(int id)
        {
            var libro = await _context.Libros.FirstOrDefaultAsync(x => x.Id == id);
            return libro != null ? libro : new Libro();
        }

        //Task: Editar
        public async Task<int> Edit(Libro libro)
        {
            int result = 0;
            var autoUpdate = await GetById(libro.Id);
            if (autoUpdate.Id != 0)
            {
                autoUpdate.NombreLibro = libro.NombreLibro;
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        //Task: Eliminar
        public async Task<int> Delete(int id)
        {
            int result = 0;
            var libroDelete = await GetById(id);
            if (libroDelete.Id > 0)
            {
                _context.Libros.Remove(libroDelete);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        //Busqueda con filtro
        private IQueryable<Libro> Query(Libro libro)
        {
            var query = _context.Libros.AsQueryable();
            if (!string.IsNullOrWhiteSpace(libro.NombreLibro))
                query = query.Where(s => s.NombreLibro == libro.NombreLibro);
            return query;
        }

        //Contador 
        public async Task<int> CountSearch(Libro libro)
        {
            return await Query(libro).CountAsync();
        }

        //Paginacion
        public async Task<List<Libro>> Search(Libro libro, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = Query(libro);
            query = query.OrderByDescending(s => s.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
    
    }
}
