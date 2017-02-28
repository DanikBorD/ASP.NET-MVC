using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using test2.Models;
using PagedList;

namespace test2.Controllers
{
    public class PeopleController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: People
        public ActionResult Index(int? page)
        {

            int currentPage = page ?? 1;
            int pageSize = 3;
            var persons = db.Persons.Include(p => p.Company);
            var result = from i in persons
                         orderby i.PersonId
                         select i;
            //List<Person> list = SampleData.People.GetPeople();
            return View(result.AsQueryable().ToPagedList<Person>(currentPage, pageSize));

            //var persons = db.Persons.Include(p => p.Company);
            //int currentPage = page ?? 1;
            //int pageSize = 3;
            //PagedList<Person> result = persons.AsQueryable().ToPagedList<Person>(currentPage, pageSize) as PagedList<Person>;
            //if (Request.IsAjaxRequest())
            //{
            //    return PartialView("PesonPagedList", result);
            //}
            //return View();

            //var persons = db.Persons.Include(p => p.Company);
            //int pageSize = 3; // количество объектов на страницу
            //IEnumerable<Person> pPerPages = persons.Skip((page - 1) * pageSize).Take(pageSize);
            //PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = 6 };
            //IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Persons = phonesPerPages };
            //return View(ivm);


            //var persons = db.Persons.Include(p => p.Company);
            //return View(persons.ToList());


            //int pageSize = 3;
            //int pageNumber = (page ?? 1);
            //var result = from i in persons
            //             orderby i.PersonId
            //             select new {PersonId = i.PersonId, FirstName = i.FirstName, LastName = i.LastName };
            //return View(result.ToPagedList(pageNumber, pageSize));

        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name");
            return View();
        }

        // POST: People/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonId,FirstName,LastName,MiddleName,Telephone,CompanyId")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name", person.CompanyId);
            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name", person.CompanyId);
            return View(person);
        }

        // POST: People/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonId,FirstName,LastName,MiddleName,Telephone,CompanyId")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name", person.CompanyId);
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.Persons.Find(id);
            db.Persons.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
