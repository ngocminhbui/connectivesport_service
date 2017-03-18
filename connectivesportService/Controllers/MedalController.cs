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
    public class MedalController : TableController<Medal>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            connectivesportContext context = new connectivesportContext();
            DomainManager = new EntityDomainManager<Medal>(context, Request);
        }

        // GET tables/Medal
        public IQueryable<Medal> GetAllMedal()
        {
            return Query(); 
        }

        // GET tables/Medal/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Medal> GetMedal(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Medal/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Medal> PatchMedal(string id, Delta<Medal> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Medal
        public async Task<IHttpActionResult> PostMedal(Medal item)
        {
            Medal current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Medal/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteMedal(string id)
        {
             return DeleteAsync(id);
        }
    }
}
