using AcaiConnUnificada.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcaiConnUnificada.Controllers
{
	public class ProdutosController : Controller
	{
		private readonly IProdutosDB _db;

		public ProdutosController(IProdutosDB db)
		{
			_db = db;
		}

		// GET: ProdutosController
		public ActionResult Index()
		{
			return View(_db.getList());
		}

		// GET: ProdutosController/Details/5
		public ActionResult Details(string id)
		{
            Produto p = _db.getById(id);
            return View(p);
		}

		// GET: ProdutosController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: ProdutosController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Produto p)
		{
			try
			{
				p.Id = Guid.NewGuid();
				_db.insert(p);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: ProdutosController/Edit/5
		public ActionResult Edit(string id)
		{
			Produto p = _db.getById(id);
			return View(p);
		}

		// POST: ProdutosController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Produto p)
		{
			try
			{
				_db.update(p);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: ProdutosController/Delete/5
		public ActionResult Delete(string id)
		{
            Produto p = _db.getById(id);
            return View(p);
		}

        // GET: ProdutosController/Delete/5
        public ActionResult Erase(string id)
        {
            _db.delete(id);
			return RedirectToAction("Index");
        }


    }
}
