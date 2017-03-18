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
    public class ChallengeController : TableController<Challenge>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            connectivesportContext context = new connectivesportContext();
            DomainManager = new EntityDomainManager<Challenge>(context, Request);
        }

        // GET tables/Challenge
        public IQueryable<Challenge> GetAllChallenge()
        {
            return Query(); 
        }

        // GET tables/Challenge/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Challenge> GetChallenge(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Challenge/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Challenge> PatchChallenge(string id, Delta<Challenge> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Challenge
        public async Task<IHttpActionResult> PostChallenge(Challenge item)
        {
            Challenge current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Challenge/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteChallenge(string id)
        {
             return DeleteAsync(id);
        }
    }
}
