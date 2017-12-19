using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using thirdSemesterAPI.Models.Entity;
using thirdSemesterAPI.Models.ImageModel;

namespace thirdSemesterAPI.Controllers
{
    [RoutePrefix("api/image")]
    public class ImageController : ApiController
    {

        private ImageModel imageModel = new ImageModel();

        [HttpGet]
        [Route("findall")]
        public HttpResponseMessage GetAllImage()
        {
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(imageModel.GetAllImage()));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return response;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [Route("getimagebyid/{id}")]
        public HttpResponseMessage GetImageById(int id)
        {
            try
            {
                if (imageModel.GetImageById(id) != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(imageModel.GetImageById(id)));
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    return response;
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [Route("getimagebyname/{name}")]
        public HttpResponseMessage GetImageByName(string name)
        {
            try
            {
                var images = imageModel.GetImageByName(name);
                if (images.Count > 0)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(imageModel.GetImageByName(name)));
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    return response;
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [Route("addImage")]
        public HttpResponseMessage AddNewImage(ImageEntity ImageEntity)
        {
            try
            {
                if (imageModel.AddNewImage(ImageEntity))
                {
                    var respone = new
                    {
                        createdAt = DateTime.Now
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, respone);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotAcceptable);
                }
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        [Route("updateimage/{id}")]
        public HttpResponseMessage UpdateImageById(int id, ImageEntity Image)
        {
            try
            {
                if (imageModel.UpdateImageById(id, Image))
                {
                    var respone = new
                    {
                        updatedAt = DateTime.Now
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, respone);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage DeleteImageById(int id)
        {
            try
            {
                if (imageModel.DeleteImageById(id))
                {
                    var respone = new
                    {
                        deletedAt = DateTime.Now
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, respone);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
