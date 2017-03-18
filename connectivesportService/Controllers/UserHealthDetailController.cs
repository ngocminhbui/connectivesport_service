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
    public class UserHealthDetailController : TableController<UserHealthDetail>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            connectivesportContext context = new connectivesportContext();
            DomainManager = new EntityDomainManager<UserHealthDetail>(context, Request);
        }

        // GET tables/UserHealthDetail
        public IQueryable<UserHealthDetail> GetAllUserHealthDetail()
        {
            return Query(); 
        }

        // GET tables/UserHealthDetail/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<UserHealthDetail> GetUserHealthDetail(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/UserHealthDetail/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<UserHealthDetail> PatchUserHealthDetail(string id, Delta<UserHealthDetail> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/UserHealthDetail
        public async Task<IHttpActionResult> PostUserHealthDetail(UserHealthDetail item)
        {
            UserHealthDetail current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/UserHealthDetail/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteUserHealthDetail(string id)
        {
             return DeleteAsync(id);
        }
    }
}
