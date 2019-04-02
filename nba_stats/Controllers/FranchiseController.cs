using nba_stats.Models;
using nba_stats.Models.DTO;
using nba_stats.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace nba_stats.Controllers
{
    public class FranchiseController : ApiController
    {
        private IService<FranchiseDTO> service = ServiceFactory.GetService<FranchiseDTO>();

        public List<FranchiseDTO> Get() => service.getAll();

        public void Post(FranchiseDTO franchiseDto) => service.save(franchiseDto);

        public HttpResponseMessage Patch(FranchiseDTO dto, int id) {
            int status = service.patch(dto, id);
            HttpResponseMessage response;
            if (status == 1)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, "Franchise Updated");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Franchise not found");
            }
            return response;
        }

        public HttpResponseMessage Put(FranchiseDTO dto, int id) {
            int status = service.put(dto, id);
            HttpResponseMessage response;
            if (status == 1)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, "Franchise Updated");
            }
            else {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Franchise not found");
            }
            return response;
        }

        public HttpResponseMessage Get(int id) {
            HttpResponseMessage response;
            FranchiseDTO franchise = service.getById(id);
            if (franchise != null)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, franchise);
            }
            else {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "non existing id");
            }
            return response;
        }

        public HttpResponseMessage Delete(int id) {
            HttpResponseMessage response;
            int status = service.delete(id);
            if (status == 1)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, "Franchise was deactivated");
            }
            else {
                response = Request.CreateResponse(HttpStatusCode.OK, "Franchise non existent or already deactivated");
            }
            return response;
        }
    }
}
