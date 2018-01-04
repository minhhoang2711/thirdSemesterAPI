using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using thirdSemesterAPI.CustomModels;
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


        [HttpPost]
        [Route("upload")]
        public HttpResponseMessage UploadImage()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            try
            {

                var httpRequest = HttpContext.Current.Request;
                int imageId;
                ImageResponse imageRes;

                foreach (string file in httpRequest.Files)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {

                        int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB  

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (!AllowedFileExtensions.Contains(extension))
                        {

                            var message = string.Format("Please Upload image of type .jpg,.gif,.png.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else if (postedFile.ContentLength > MaxContentLength)
                        {

                            var message = string.Format("Please Upload a file upto 1 mb.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else
                        {



                            var filePath = HttpContext.Current.Server.MapPath("~/Content/Images/" + postedFile.FileName + extension);

                            postedFile.SaveAs(filePath);

                            var newImage = new ImageEntity {
                                Name = postedFile.FileName
                            };
                            imageId = imageModel.AddNewImage(newImage);
                            var responseMessage = imageId == -1 ? "Inserted image failed" : "Image Updated Successfully.";
                            imageRes = new ImageResponse
                            {
                                ImageId = imageId,
                                Message = "Image Updated Successfully."
                            };
                            response = new HttpResponseMessage(HttpStatusCode.Created);
                            response.Content = new StringContent(JsonConvert.SerializeObject(imageRes));
                            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                            return response;

                        }

                    }
                }

                var res = new ImageResponse
                {
                    ImageId = -1,
                    Message = "Inserted image failed"
                };
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
            catch (Exception)
            {
                var res = string.Format("some Message");
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
        }
    }
}
