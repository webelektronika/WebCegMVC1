using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCegMVC1.sqlClasses;

namespace WebCegMVC1.Controllers
{
    public class MunkatarsController : Controller
    {
        public IConfiguration Configuration { get; }

        private string connectString = null;

        public MunkatarsController(IConfiguration configuration)
        {
            Configuration = configuration;
            connectString = Configuration["ConnectionStrings:CegConnection"];
        }


        // GET: MunkatarsController
        public ActionResult Index()
        {
            sqlMunkatars sm = new sqlMunkatars(connectString);

            return View(sm.getLista());
        }

        // GET: MunkatarsController/Details/5
        public ActionResult Details(int id)
        {
            sqlMunkatars sm = new sqlMunkatars(connectString);

            return View(sm.getSzemely(id));
        }

        // GET: MunkatarsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MunkatarsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MunkatarsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MunkatarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MunkatarsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MunkatarsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
