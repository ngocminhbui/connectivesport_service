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
    public class UserStatusController : TableController<UserStatus>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            connectivesportContext context = new connectivesportContext();
            DomainManager = new EntityDomainManager<UserStatus>(context, Request);
        }

        // GET tables/UserStatus
        public IQueryable<UserStatus> GetAllUserStatus()
        {
            return Query(); 
        }

        // GET tables/UserStatus/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<UserStatus> GetUserStatus(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/UserStatus/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<UserStatus> PatchUserStatus(string id, Delta<UserStatus> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/UserStatus
        public async Task<IHttpActionResult> PostUserStatus(UserStatus item)
        {
            UserStatus current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/UserStatus/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteUserStatus(string id)
        {
             return DeleteAsync(id);
        }
    }
}
