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
    public class GoalController : TableController<Goal>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            connectivesportContext context = new connectivesportContext();
            DomainManager = new EntityDomainManager<Goal>(context, Request);
        }

        // GET tables/Goal
        public IQueryable<Goal> GetAllGoal()
        {
            return Query(); 
        }

        // GET tables/Goal/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Goal> GetGoal(string id)
        {
            
            return Lookup(id);
        }

        // PATCH tables/Goal/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Goal> PatchGoal(string id, Delta<Goal> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Goal
        public async Task<IHttpActionResult> PostGoal(Goal item)
        {
            Goal current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Goal/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteGoal(string id)
        {
             return DeleteAsync(id);
        }
    }
}
