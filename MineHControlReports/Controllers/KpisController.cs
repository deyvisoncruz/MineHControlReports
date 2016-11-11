using System;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;
using System.Linq;
using MineHControlReports.Models;
using MineHControlReports.Dao;
using System.Collections.Generic;
namespace MineHControlReports.Controllers
{
    public class KpisController : Controller
    {
        //
        // GET: /Kpis/
        private Models.kpis dbkpis = new Models.kpis();
        public ActionResult Index()
        {
             
                return View(dbkpis);
            
            
        }

        //
        // GET: /Kpis/Create

        public ActionResult Create()
        {
            ViewBag.Message = "Cadastre seus Kpis";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(kpis kpis)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(kpis);
                        transaction.Commit();
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }

    }
}
