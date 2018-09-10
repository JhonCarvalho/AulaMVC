using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AulaMVC.Controllers
{
    public class LivroController : Controller
    {
        // GET: Livro
        public ActionResult Index()
        {
            bdlivroEntities context = new bdlivroEntities();
            var lts = context.tb_livro.ToList();

            return View(lts);
        }

        // GET: Livro/Details/5
        public ActionResult Details(int id)
        {
            return View(new bdlivroEntities().tb_livro.First(l => l.id == id));
        }

        // GET: Livro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Livro/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tb_livro livro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bdlivroEntities context = new bdlivroEntities();
                    context.tb_livro.Add(livro);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                // TODO: Add insert logic here

                return View(livro);
            }
            catch
            {
                return View(livro);
            }
        }

        // GET: Livro/Edit/5
        public ActionResult Edit(int id)
        {
            bdlivroEntities context = new bdlivroEntities();
            return View(context.tb_livro.First(l => l.id == id));
            
        }

        // POST: Livro/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tb_livro livro)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid) {
                    bdlivroEntities context = new bdlivroEntities();
                    tb_livro li = context.tb_livro.First(l => l.id == livro.id);
                    li.nome = livro.nome;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(livro);
            }
            catch
            {
                return View(livro);
            }
        }

        // GET: Livro/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new bdlivroEntities().tb_livro.First(l => l.id == id));

        }

        // POST: Livro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                bdlivroEntities context = new bdlivroEntities();
                tb_livro li = context.tb_livro.First(l => l.id == id);
                context.tb_livro.Remove(li);
                context.SaveChanges();
                return RedirectToAction("Index");
             
            }
            catch
            {
                return View();
            }
        }
    }
}
