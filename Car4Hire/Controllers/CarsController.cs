using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Car4Hire.Models;


namespace Car4Hire.Controllers
{
    public class CarsController : Controller
    {
        private c4hDBEntities db = new c4hDBEntities();

        // GET: Cars

        public ActionResult Show(string searchString, string manufacturer, string type, string fuel)
        {

            var allcars = from m in db.Car
                          select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                allcars = allcars.Where(x => x.model.Contains(searchString));
            }

            //////

            List<string> manufacturerList = new List<string>();
            var manufacturerQuery = from g in db.Car
                                    orderby g.make
                                    select g.make;
            manufacturerList.AddRange(manufacturerQuery.Distinct());
            ViewBag.manufacturer = new SelectList(manufacturerList);

            //var allcars = from m in db.Car
            //           select m;

            if(!String.IsNullOrEmpty(manufacturer))
            {
                allcars = allcars.Where(x => x.make == manufacturer);
            }

            /////////////////////////
            ///

            List<string> typeList = new List<string>();
            var typeQuery = from g in db.Car
                                    orderby g.type
                                    select g.type;
            typeList.AddRange(typeQuery.Distinct());
            ViewBag.type = new SelectList(typeList);

            //var allcars = from m in db.Car
            //              select m;

            if (!String.IsNullOrEmpty(type))
            {
                allcars = allcars.Where(x => x.type == type);
            }


            ///////////////////
            ///

            List<string> fuelList = new List<string>();
            var fuelQuery = from g in db.Car
                            orderby g.fuel
                            select g.fuel;
            fuelList.AddRange(fuelQuery.Distinct());
            ViewBag.fuel = new SelectList(fuelList);

            //var allcars = from m in db.Car
            //              select m;

            if (!String.IsNullOrEmpty(fuel))
            {
                allcars = allcars.Where(x => x.fuel == fuel);
            }

            return View(allcars);
        }

        public ActionResult View(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Car.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }



        public ActionResult Database()
        {
            return View(db.Car.ToList());
        }

        public ActionResult Index()
        {
            return View(db.Car.ToList());
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Car.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "carId,make,model,type,fuel,price,ImageFile")] Car car)
        {
            if (car.image == null)
            {
                car.image = "default1.jpg";
            }

            if (ModelState.IsValid)
            {
                string imagename = Path.GetFileNameWithoutExtension(car.ImageFile.FileName);
                string extension = Path.GetExtension(car.ImageFile.FileName);
                imagename = imagename + extension;
                car.image = imagename;

                imagename = Path.Combine(Server.MapPath("~/Images/"), imagename);
                car.ImageFile.SaveAs(imagename);

                db.Car.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Car.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]



        public ActionResult Edit([Bind(Include = "carId,make,model,type,fuel,price,ImageFile")] Car car)
        {


            if (ModelState.IsValid)
            {


                string imagename = Path.GetFileNameWithoutExtension(car.ImageFile.FileName);
                string extension = Path.GetExtension(car.ImageFile.FileName);
                imagename = imagename + extension;
                car.image = imagename;

                imagename = Path.Combine(Server.MapPath("~/Images/"), imagename);
                car.ImageFile.SaveAs(imagename);

                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Car.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Car.Find(id);
            db.Car.Remove(car);
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
