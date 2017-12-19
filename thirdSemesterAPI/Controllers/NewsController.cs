using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using thirdSemesterAPI.Models.Entity;
using thirdSemesterAPI.Models.NewsModel;

namespace thirdSemesterAPI.Controllers
{
    [RoutePrefix("api/news")]
    public class NewsController : ApiController
    {

        private NewsModel newsModel = new NewsModel();

        [HttpGet]
        [Route("findall")]
        public HttpResponseMessage GetAllNews()
        {
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(newsModel.GetAllNews()));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return response;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [Route("getnewsbyid/{id}")]
        public HttpResponseMessage GetNewsById(int id)
        {
            try
            {
                if (newsModel.GetNewsById(id) != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(newsModel.GetNewsById(id)));
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
        [Route("getnewsbyname/{name}")]
        public HttpResponseMessage GetNewsByName(string name)
        {
            try
            {
                var Newss = newsModel.GetNewsByName(name);
                if (Newss.Count > 0)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(newsModel.GetNewsByName(name)));
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
        [Route("addNews")]
        public HttpResponseMessage AddNewNews(NewsEntity newsEntity)
        {
            try
            {
                if (newsModel.AddNewNews(newsEntity))
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
        [Route("updateNews/{id}")]
        public HttpResponseMessage UpdateNewsById(int id, NewsEntity News)
        {
            try
            {
                if (newsModel.UpdateNewsById(id, News))
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
        public HttpResponseMessage DeleteNewsById(int id)
        {
            try
            {
                if (newsModel.DeleteNewsById(id))
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
