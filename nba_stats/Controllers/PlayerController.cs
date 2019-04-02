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
    }
}
