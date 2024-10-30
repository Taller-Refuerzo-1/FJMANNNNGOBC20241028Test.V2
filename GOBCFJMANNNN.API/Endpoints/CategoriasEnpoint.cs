using GOBCFJMANNNN.API.Models.DAL;
using GOBCFJMANNNN.API.Models.EN;
using GOBCFJMANNNN.DTO.GOBCFJMANNNN.DTOs;
using static GOBCFJMANNNN.DTO.GOBCFJMANNNN.DTOs.SearchResultCategoriaDTO;

namespace GOBCFJMANNNN.API.Endpoints
{
    public static class CategoriasEnpoint
    {
        public static void AddCategoriaEndpoints(this WebApplication app)
        {
            //POST: Buscar todos
            app.MapPost("/categoria/search", async (SearchQueryCategoria libroDTO, CategoriaDAL libroDAL) =>
            {
                var libro1 = new Categoria
                {
                    Nombre = libroDTO.Nombre_Like != null ? libroDTO.Nombre_Like : string.Empty,
                };

                var libros = new List<Categoria>();
                int countRow = 0;

                if (libroDTO.SendRowCount == 2)
                {
                    libros = await libroDAL.Search(libro1, skip: libroDTO.Skip, take: libroDTO.Take);
                    if (libros.Count > 0)
                        countRow = await libroDAL.CountSearch(libro1);
                }
                else
                {
                    libros = await libroDAL.Search(libro1, skip: libroDTO.Skip, take: libroDTO.Take);
                }

                var autoResult = new SearchResultCategoriaDTO
                {
                    Data = new List<SearchResultCategoriaDTO.CategoriaDTO>(),
                    CountRow = countRow
                };

                libros.ForEach(s =>
                {
                    autoResult.Data.Add(new SearchResultCategoriaDTO.CategoriaDTO
                    {
                        Id = s.Id,
                        Nombre = s.Nombre
                    });
                });

                return autoResult;
            });

            //GET: Obtener por ID
            app.MapGet("/categoria/{id}", async (int id, CategoriaDAL libroDAL) =>
            {
                var libro = await libroDAL.GetById(id);

                var libroResult = new GetIdResultCategoriaDTO
                {
                    Id = libro.Id,
                    NombreLibro = libro.NombreLibro
                };

                if (libroResult.Id > 0)
                    return Results.Ok(libroResult);
                else
                    return Results.NotFound(libroResult);
            });

            //POST: Crear 
            app.MapPost("/categoria", async (CreateAutoDTO autoDTO, AutosDAL autosDAL) =>
            {
                var autos = new Auto
                {
                    Marca = autoDTO.Marca
                };

                int result = await autosDAL.Create(autos);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });

            //PUT: Editar
            app.MapPut("/categoria", async (EditAutoDTO autoDTO, AutosDAL autosDAL) =>
            {
                var autos = new Auto
                {
                    Id = autoDTO.Id,
                    Marca = autoDTO.Marca,
                    Modelo = autoDTO.Modelo,
                    Year = autoDTO.Year,
                    Precio = autoDTO.Precio
                };

                int result = await autosDAL.Edit(autos);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });

            //DELETE: Eliminar
            app.MapDelete("/categoria/{id}", async (int id, CategoriaDAL libroDAL) =>
            {
                int result = await libroDAL.Delete(id);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });
        }
    }
}
}
