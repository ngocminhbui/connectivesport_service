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
    public class SportMembershipController : TableController<SportMembership>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            connectivesportContext context = new connectivesportContext();
            DomainManager = new EntityDomainManager<SportMembership>(context, Request);
        }

        // GET tables/SportMembership
        public IQueryable<SportMembership> GetAllSportMembership()
        {
            return Query(); 
        }

        // GET tables/SportMembership/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<SportMembership> GetSportMembership(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/SportMembership/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<SportMembership> PatchSportMembership(string id, Delta<SportMembership> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/SportMembership
        public async Task<IHttpActionResult> PostSportMembership(SportMembership item)
        {
            SportMembership current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/SportMembership/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteSportMembership(string id)
        {
             return DeleteAsync(id);
        }
    }
}
