using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using saafcity_fyp.Models;

namespace saafcity_fyp.Controllers
{
    public class ComplaintsController : ApiController
    {
        private SaafCity_DatabaseEntities7 db = new SaafCity_DatabaseEntities7();

        // GET: api/Complaints
        public IQueryable<Complaint> GetComplaints()
        {
            return db.Complaints;
        }

        // GET: api/Complaints/5
        [ResponseType(typeof(Complaint))]
        public async Task<IHttpActionResult> GetComplaint(int id)
        {
            Complaint complaint = await db.Complaints.FindAsync(id);
            if (complaint == null)
            {
                return NotFound();
            }

            return Ok(complaint);
        }

        // PUT: api/Complaints/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutComplaint(int id, Complaint complaint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != complaint.Complaint_ID)
            {
                return BadRequest();
            }

            db.Entry(complaint).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComplaintExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Complaints
        [ResponseType(typeof(Complaint))]
        public async Task<IHttpActionResult> PostComplaint(Complaint complaint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Complaints.Add(complaint);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = complaint.Complaint_ID }, complaint);
        }

        // DELETE: api/Complaints/5
        [ResponseType(typeof(Complaint))]
        public async Task<IHttpActionResult> DeleteComplaint(int id)
        {
            Complaint complaint = await db.Complaints.FindAsync(id);
            if (complaint == null)
            {
                return NotFound();
            }

            db.Complaints.Remove(complaint);
            await db.SaveChangesAsync();

            return Ok(complaint);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComplaintExists(int id)
        {
            return db.Complaints.Count(e => e.Complaint_ID == id) > 0;
        }
    }
}