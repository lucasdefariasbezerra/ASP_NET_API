using nba_stats.Models;
using nba_stats.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace nba_stats.Controllers
{
    public class PlayerController : ApiController
    {
        private static IService<PlayerDTO> service = ServiceFactory.GetService<PlayerDTO>();

        public void Post(PlayerDTO player) {
            service.save(player);
        }

        public List<PlayerDTO> Get() {
            return service.getAll();
        }

        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage response;
            PlayerDTO player = service.getById(id);
            if (player != null)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, player);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "non existing player");
            }
            return response;
        }

        public HttpResponseMessage Patch(PlayerDTO dto, int id)
        {
            int status = service.patch(dto, id);
            HttpResponseMessage response;
            if (status == 1)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, "Player Updated");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Player not found");
            }
            return response;
        }

        public HttpResponseMessage Put(PlayerDTO dto, int id)
        {
            int status = service.put(dto, id);
            HttpResponseMessage response;
            if (status == 1)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, "Player Updated");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Player or Franchise not found");
            }
            return response;
        }

        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage response;
            int status = service.delete(id);
            if (status == 1)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, "Player was deactivated");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, "Player non existent or already deactivated");
            }
            return response;
        }
    }
}
