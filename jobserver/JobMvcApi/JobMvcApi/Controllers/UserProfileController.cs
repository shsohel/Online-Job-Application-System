using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using JobMvcApi.Models;
using JobMvcApi.Models.Repository;
using JobMvcApi.Models.ViewModels;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Web.Http.Results;

namespace JobMvcApi.Controllers
{
    [Authorize(Roles = ("Jobseeker, Admin"))]
    [RoutePrefix("api/PersonalDetail")]
    public class UserProfileController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private IRepository<PersonalDetail> _repository;
        private readonly IRepository<Address> adRepository;
        public string message = "Someting Went Wrong!!!";

        public UserProfileController(IRepository<PersonalDetail> repository, IRepository<Address> AdRepository)
        {
            _repository = repository;
            adRepository = AdRepository;
        }

        // GET: api/PersonalDetail
        [HttpGet]
        [Route("GetPersonalDetailList", Name = "GetPersonalDetail")]
        public IHttpActionResult GetPersonalDetails()
        {
            string userName = RequestContext.Principal.Identity.GetUserName();
            IEnumerable<PersonalDetail> result = _repository.GetAll().Where(x => x.UserName == userName);
            return Ok(new { obj = result, user = userName });
        } 

        // GET: api/PersonalDetail/5
        [HttpGet]
        [Route("getbyId/{id}")]
        public IHttpActionResult GetPersonalDetail(int id)
        {
            
            PersonalDetail personalDetail = _repository.Get(id);
            if (personalDetail == null)
            {
                return NotFound();
            }

            return Ok(new {obj=personalDetail });
        }

        // PUT: api/PersonalDetail/5

        // [ResponseType(typeof(PersonalDetailViewModel))]
        [HttpPut]
        [Route("update")]
        public IHttpActionResult PutPersonalDetail(PersonalDetailViewModel model)
        {
            try
            {
                PersonalDetail personal = _repository.Get(model.PersonalDetailID);
                if (personal != null)
                {
                    personal.MotherName = model.MotherName;
                    personal.FatherName = model.FatherName;
                    personal.CellPhone = model.CellPhone;
                    personal.DOB = model.DOB;
                    personal.Email = model.Email;
                    personal.FirstName = model.FirstName;
                    personal.LastName = model.LastName;
                    personal.NationalID = model.NationalID;
                    personal.Photo = model.Photo;

                    PersonalDetail result = _repository.Update(personal);
              //      IEnumerable<Address> addresses = adRepository.GetAll();
             //       List<Address> filerAddress = addresses.Where(x => x.PersonalDetailID == model.PersonalDetailID).ToList();
                    //foreach(Address  address in filerAddress)
                    //{
                    //    AddressViewModel viewModel = new AddressViewModel
                    //    {
                    //        PermanentAddress = address.PermanentAddress,
                    //        PresentAddress = address.PresentAddress,
                    //    };
                    //    filerAddress.Add(address);
                    //    List<Address> result2 = adRepository.UpdateRange(filerAddress);
                    //}
                    return Ok(new { obj = result, message = "Update Successfully Done!!" });


                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                BadRequest(message);
                throw ex;
            }
  
            //         return CreatedAtRoute("DefaultApi", new { id = personalDetail.PersonalDetailID }, personalDetail);
        }
        [HttpPut]
        [Route("addressUpdate")]
        public IHttpActionResult PutAddress(List<AddressViewModel> models)
        {
            try
            {
                foreach (AddressViewModel model in models)
                {
                    Address address = adRepository.Get(model.AddressID);
                    if (address != null)
                    {

                        address.PermanentAddress = model.PermanentAddress;
                        address.PresentAddress = model.PresentAddress;

                        Address result = adRepository.Update(address);
                        return Ok(new { obj = result, message = "Address Udpate Successfuly" });
                    }
                    else
                    {
                        return BadRequest(message);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return Ok(message);
        }

        // POST: api/PersonalDetail
        [HttpPost]
        [Route("post")]
        public IHttpActionResult PostPersonalDetail(PersonalDetail personalDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PersonalDetails.Add(personalDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personalDetail.PersonalDetailID }, personalDetail);
        }

        // DELETE: api/PersonalDetail/5
        [ResponseType(typeof(PersonalDetail))]
        public IHttpActionResult DeletePersonalDetail(int id)
        {
            PersonalDetail personalDetail = db.PersonalDetails.Find(id);
            if (personalDetail == null)
            {
                return NotFound();
            }

            db.PersonalDetails.Remove(personalDetail);
            db.SaveChanges();

            return Ok(personalDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonalDetailExists(int id)
        {
            return db.PersonalDetails.Count(e => e.PersonalDetailID == id) > 0;
        }
    }
}