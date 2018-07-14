using AutomatedTellerMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private ApplicationDbContext _context= new ApplicationDbContext();
        
        // GET: Transaction/deposit
        public ActionResult Deposit(int checkingAccountId)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Deposit(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Transactions.Add(transaction);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

    }
}