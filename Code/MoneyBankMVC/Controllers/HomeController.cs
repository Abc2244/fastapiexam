using Microsoft.AspNetCore.Mvc;
using MoneyBankMVC.Models;
using MoneyBankMVC.Services;
using System.Linq;

namespace MoneyBankMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly MoneybankdbContext _DBContext;

        public HomeController(MoneybankdbContext context)
        {
            _DBContext = context;
        }

        // 1. Listar
        public IActionResult Listar()
        {
            var accounts = _DBContext.Accounts.ToList();
            return View(accounts);
        }

        // 2. Crear (Vista y Acción POST)
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Account account)
        {
            if (ModelState.IsValid)
            {
                _DBContext.Accounts.Add(account);
                _DBContext.SaveChanges();
                return RedirectToAction("Listar");
            }
            return View(account);
        }

        // 3. Editar (Vista y Acción POST)
        public IActionResult Editar(int id)
        {
            var account = _DBContext.Accounts.Find(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        [HttpPost]
        public IActionResult Editar(Account account)
        {
            if (ModelState.IsValid)
            {
                _DBContext.Accounts.Update(account);
                _DBContext.SaveChanges();
                return RedirectToAction("Listar");
            }
            return View(account);
        }


        // 4. Depositar
        public IActionResult Depositar(int id)
        {
            var account = _DBContext.Accounts.Find(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        [HttpPost]
        public IActionResult Depositar(int id, decimal amount)
        {
            var account = _DBContext.Accounts.Find(id);
            if (account == null)
            {
                return NotFound();
            }
            account.BalanceAmount += amount;
            _DBContext.SaveChanges();
            return RedirectToAction("Listar");
        }

        // 5. Retirar
        public IActionResult Retirar(int id)
        {
            var account = _DBContext.Accounts.Find(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        [HttpPost]
        public IActionResult Retirar(int id, decimal amount)
        {
            var account = _DBContext.Accounts.Find(id);
            if (account == null)
            {
                return NotFound();
            }
            if (account.BalanceAmount - amount < 0)
            {
                // Aquí puedes manejar el caso en que no haya suficiente saldo
                return View("Error");
            }
            account.BalanceAmount -= amount;
            _DBContext.SaveChanges();
            return RedirectToAction("Listar");
        }

        // 6. Información
        public IActionResult Informacion(int id)
        {
            var account = _DBContext.Accounts.Find(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // 7. Eliminar
        public IActionResult Eliminar(int id)
        {
            var account = _DBContext.Accounts.Find(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        [HttpPost]
        public IActionResult ConfirmarEliminar(int id)
        {
            var account = _DBContext.Accounts.Find(id);
            if (account == null)
            {
                return NotFound();
            }
            _DBContext.Accounts.Remove(account);
            _DBContext.SaveChanges();
            return RedirectToAction("Listar");
        }

    }
}
