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
    public class AchievementController : TableController<Achievement>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            connectivesportContext context = new connectivesportContext();
            DomainManager = new EntityDomainManager<Achievement>(context, Request);
        }

        // GET tables/Achievement
        public IQueryable<Achievement> GetAllAchievement()
        {
            return Query(); 
        }

        // GET tables/Achievement/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Achievement> GetAchievement(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Achievement/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Achievement> PatchAchievement(string id, Delta<Achievement> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Achievement
        public async Task<IHttpActionResult> PostAchievement(Achievement item)
        {
            Achievement current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Achievement/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteAchievement(string id)
        {
             return DeleteAsync(id);
        }
    }
}
