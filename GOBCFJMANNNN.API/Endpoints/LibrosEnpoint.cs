using GOBCFJMANNNN.API.Models.DAL;
using GOBCFJMANNNN.API.Models.EN;

namespace GOBCFJMANNNN.API.Endpoints
{
    public static class LibrosEnpoint
    {
        public static void AddLibroEndpoints(this WebApplication app)
        {
            //POST: Buscar todos
            app.MapPost("/libro/search", async (SearchQueryLibroDTO libroDTO, LibroDAL autosDAL) =>
            {
                var auto1 = new Libro
                {
                    Marca = autoDTO.Marca_Like != null ? libroDTO.Marca_Like : string.Empty,
                    Modelo = autoDTO.Modelo_Like != null ? libnroDTO.Modelo_Like : string.Empty
                };

                var autos = new List<Libro>();
                int countRow = 0;

                if (autoDTO.SendRowCount == 2)
                {
                    autos = await librosDAL.Search(auto1, skip: libroDTO.Skip, take: autoDTO.Take);
                    if (autos.Count > 0)
                        countRow = await librossDAL.CountSearch(auto1);
                }
                else
                {
                    autos = await librosDAL.Search(libro1, skip: autoDTO.Skip, take: autoDTO.Take);
                }

                var autoResult = new SearchResultAutoDTO
                {
                    Data = new List<SearchResultAutoDTO.AutosDTO>(),
                    CountRow = countRow
                };

                autos.ForEach(s =>
                {
                    autoResult.Data.Add(new SearchResultAutoDTO.AutosDTO
                    {
                        Id = s.Id,
                        Marca = s.Marca,
                        Modelo = s.Modelo,
                        Year = s.Year,
                        Precio = s.Precio
                    });
                });

                return autoResult;
            });

            //GET: Obtener por ID
            app.MapGet("/auto/{id}", async (int id, AutosDAL autosDAL) =>
            {
                var auto = await autosDAL.GetById(id);

                var autoResult = new GetIdResultAuto
                {
                    Id = auto.Id,
                    Marca = auto.Marca,
                    Modelo = auto.Modelo,
                    Year = auto.Year,
                    Precio = auto.Precio
                };

                if (autoResult.Id > 0)
                    return Results.Ok(autoResult);
                else
                    return Results.NotFound(autoResult);
            });

            //POST: Crear 
            app.MapPost("/auto", async (CreateAutoDTO autoDTO, AutosDAL autosDAL) =>
            {
                var autos = new Auto
                {
                    Marca = autoDTO.Marca,
                    Modelo = autoDTO.Modelo,
                    Year = autoDTO.Year,
                    Precio = autoDTO.Precio
                };

                int result = await autosDAL.Create(autos);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });

            //PUT: Editar
            app.MapPut("/auto", async (EditAutoDTO autoDTO, AutosDAL autosDAL) =>
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
            app.MapDelete("/auto/{id}", async (int id, AutosDAL autosDAL) =>
            {
                int result = await autosDAL.Delete(id);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });
        }
    }
}
}
