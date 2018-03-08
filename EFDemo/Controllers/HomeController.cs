namespace EFDemo.Controllers
{
    using Repository;
    using System.Linq;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        private PersonRepository _personRepository { get; set; }
        public HomeController()
        {
            this._personRepository = new PersonRepository();
        }

        public ActionResult Login() => View();

        [HttpPost]
        public ActionResult Login(string userName,string userPassword)
        {
            return RedirectToAction("index", "Home");
        }

        public ActionResult Index()
        {
            //int x = 0, y = 1, z = y / x;
            var list = this._personRepository.Get(s => true);
            try
            {
            }
            catch (System.Exception ex)
            {
                return Content($"Error:{ex.ToString()}");
            }
            return View(list);
        }

        public ActionResult Add() => View();

        [HttpPost]
        public ActionResult Add(Model.Person model)
        {
            if (!ModelState.IsValid) { };
            this._personRepository.Add(model);
            var res = this._personRepository.SaveChanges();
            return RedirectToAction("index", "Home");
        }

        public ActionResult Edit(int id)
        {
            var model = this._personRepository.Get(s => s.Id == id).FirstOrDefault();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Model.Person model)
        {
            if (!ModelState.IsValid) return View();
            return View();
        }

        public ActionResult Delete(int id)
        {
            var model = new Model.Person { Id = id };
            this._personRepository.Delete(model);
            var res = this._personRepository.SaveChanges();
            return RedirectToAction("index", "Home");
        }
    }
}