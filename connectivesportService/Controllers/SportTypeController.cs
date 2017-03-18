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
    public class SportTypeController : TableController<SportType>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            connectivesportContext context = new connectivesportContext();
            DomainManager = new EntityDomainManager<SportType>(context, Request);
        }

        // GET tables/SportType
        public IQueryable<SportType> GetAllSportType()
        {
            return Query(); 
        }

        // GET tables/SportType/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<SportType> GetSportType(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/SportType/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<SportType> PatchSportType(string id, Delta<SportType> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/SportType
        public async Task<IHttpActionResult> PostSportType(SportType item)
        {
            SportType current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/SportType/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteSportType(string id)
        {
             return DeleteAsync(id);
        }
    }
}
