using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using connectivesportService.DataObjects;
using connectivesportService.Models;

namespace connectivesportService.Controllers
{
    public class SportController : TableController<Sport>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            connectivesportContext context = new connectivesportContext();
            DomainManager = new EntityDomainManager<Sport>(context, Request);
        }

        // GET tables/Sport
        public IQueryable<Sport> GetAllSport()
        {
            return Query(); 
        }

        // GET tables/Sport/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Sport> GetSport(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Sport/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Sport> PatchSport(string id, Delta<Sport> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Sport
        public async Task<IHttpActionResult> PostSport(Sport item)
        {
            Sport current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Sport/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteSport(string id)
        {
             return DeleteAsync(id);
        }
    }
}
