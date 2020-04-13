using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using System.Web.Mvc;

using CRUD_en_MVC_.Net.Models;
using CRUD_en_MVC_.Net.Controllers;
using CRUD_en_MVC_.Net.Models.ViewModels;

namespace CRUD_en_MVC_.Net.Controllers
{
    public class TablaController : Controller
    {
        // GET: Tabla
        public ActionResult Index()
        {
            List<ListTablaViewModel> lst;
            using (CrudEntities db=new CrudEntities())
            {
                
                lst=(from d in db.tabla
                        select new ListTablaViewModel
                        {
                            id = d.id,
                            nombre=d.nombre,
                  
                            correo=d.correo
                        }).ToList();
            }

            return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudEntities db = new CrudEntities())
                    {
                        var oTabla = new tabla();
                        oTabla.correo = model.correo;
                        oTabla.fecha_nacimiento = model.fecha_nacimiento;
                        oTabla.nombre = model.nombre;

                        db.tabla.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("~/Tabla/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult Editar(int id)
        {
            TablaViewModel model = new TablaViewModel();
            using (CrudEntities db = new CrudEntities())
            {
                var oTabla = db.tabla.Find(id);
                model.nombre = oTabla.nombre;
                model.correo = oTabla.correo;
                model.fecha_nacimiento = oTabla.fecha_nacimiento;
                model.id = oTabla.id;

                db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudEntities db = new CrudEntities())
                    {
                        var oTabla = db.tabla.Find(model.id);
                        oTabla.correo = model.correo;
                        oTabla.fecha_nacimiento = model.fecha_nacimiento;
                        oTabla.nombre = model.nombre;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    return Redirect("~/Tabla/");
                }

                return View(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            using (CrudEntities db = new CrudEntities())
            {

                var oTabla = db.tabla.Find(Id);
                db.tabla.Remove(oTabla);
                db.SaveChanges();
            }
            return Redirect("~/Tabla/");
        }

    }
}