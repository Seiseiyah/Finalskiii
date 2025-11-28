using Finalskiii.Finalskiii.Data;
using Finalskiii.Finalskiii.Models;
using Microsoft.AspNetCore.Mvc;

namespace Finalskiii.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class CatalogController : ControllerBase
        {
            private readonly LibraryDbContext dbContext;

            public CatalogController(LibraryDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            // GET: api/Catalog
            [HttpGet]
            public IActionResult GetAllCatalogs()
            {
                return Ok(dbContext.Catalogs.ToList());
            }

            // GET: api/Catalog/{id}
            [HttpGet("{id:guid}")]
            public IActionResult GetCatalogById(Guid id)
            {
                var catalog = dbContext.Catalogs.Find(id);
                if (catalog == null)
                    return NotFound();

                return Ok(catalog);
            }

            // POST: api/Catalog
            [HttpPost]
            public IActionResult AddCatalog(AddCatalogDto dto)
            {
                var catalog = new Catalog()
                {
                    Id = Guid.NewGuid(),
                    Name = dto.Name,
                    Description = dto.Description
                };

                dbContext.Catalogs.Add(catalog);
                dbContext.SaveChanges();

                return Ok(catalog);
            }

            // PUT: api/Catalog/{id}
            [HttpPut("{id:guid}")]
            public IActionResult UpdateCatalog(Guid id, UpdateCatalogDto dto)
            {
                var catalog = dbContext.Catalogs.Find(id);
                if (catalog == null)
                    return NotFound();

                catalog.Name = dto.Name;
                catalog.Description = dto.Description;

                dbContext.SaveChanges();
                return Ok(catalog);
            }

            // DELETE: api/Catalog/{id}
            [HttpDelete("{id:guid}")]
            public IActionResult DeleteCatalog(Guid id)
            {
                var catalog = dbContext.Catalogs.Find(id);
                if (catalog == null)
                    return NotFound();

                dbContext.Catalogs.Remove(catalog);
                dbContext.SaveChanges();

                return Ok(catalog);
            }
        }
    }

}
}
