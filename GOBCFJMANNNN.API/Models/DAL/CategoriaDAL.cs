using GOBCFJMANNNN.API.Models.EN;
using Microsoft.EntityFrameworkCore;

namespace GOBCFJMANNNN.API.Models.DAL
{
    public class CategoriaDAL
    {
        readonly CategoriaBDContext _context;

        //Constructor que interactua con base de datos
        public CategoriaDAL(CategoriaBDContext libroBDContext)
        {
            _context = libroBDContext;
        }

        //Task:Crear
        public async Task<int> Create(Categoria libro)
        {
            _context.Add(libro);
            return await _context.SaveChangesAsync();
        }

        //Task: Obtener por Id
        public async Task<Categoria> GetById(int id)
        {
            var libro = await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id);
            return libro != null ? libro : new Categoria();
        }

        //Task: Editar
        public async Task<int> Edit(Categoria libro)
        {
            int result = 0;
            var autoUpdate = await GetById(libro.Id);
            if (autoUpdate.Id != 0)
            {
                autoUpdate.Nombre = libro.Nombre;
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
                _context.Categorias.Remove(libroDelete);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        //Busqueda con filtro
        private IQueryable<Categoria> Query(Categoria libro)
        {
            var query = _context.Categorias.AsQueryable();
            if (!string.IsNullOrWhiteSpace(libro.Nombre))
                query = query.Where(s => s.Nombre == libro.Nombre);
            return query;
        }

        //Contador 
        public async Task<int> CountSearch(Categoria libro)
        {
            return await Query(libro).CountAsync();
        }

        //Paginacion
        public async Task<List<Categoria>> Search(Categoria libro, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = Query(libro);
            query = query.OrderByDescending(s => s.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
    
    }
}
