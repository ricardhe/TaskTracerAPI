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
using TaskTracerApi.Models;
using System.Web.Http.Cors;

namespace TaskTracerApi.Controllers
{

    
    public class WorkGroupsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/WorkGroups
  [Authorize]
        public IQueryable<WorkGroup> GetWorkGroup()
        {
            return db.WorkGroup;
        }

        // GET: api/WorkGroups/5
        [ResponseType(typeof(WorkGroup))]
        public async Task<IHttpActionResult> GetWorkGroup(int id)
        {
            WorkGroup workGroup = await db.WorkGroup.FindAsync(id);
            if (workGroup == null)
            {
                return NotFound();
            }

            return Ok(workGroup);
        }

        // PUT: api/WorkGroups/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWorkGroup(int id, WorkGroup workGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workGroup.WorkGroupID)
            {
                return BadRequest();
            }

            db.Entry(workGroup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkGroupExists(id))
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

        // POST: api/WorkGroups
        [ResponseType(typeof(WorkGroup))]
        public async Task<IHttpActionResult> PostWorkGroup(WorkGroup workGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WorkGroup.Add(workGroup);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = workGroup.WorkGroupID }, workGroup);
        }

        // DELETE: api/WorkGroups/5
        [ResponseType(typeof(WorkGroup))]
        public async Task<IHttpActionResult> DeleteWorkGroup(int id)
        {
            WorkGroup workGroup = await db.WorkGroup.FindAsync(id);
            if (workGroup == null)
            {
                return NotFound();
            }

            db.WorkGroup.Remove(workGroup);
            await db.SaveChangesAsync();

            return Ok(workGroup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkGroupExists(int id)
        {
            return db.WorkGroup.Count(e => e.WorkGroupID == id) > 0;
        }
    }
}