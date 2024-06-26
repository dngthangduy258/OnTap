using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnTap.Models;
namespace OnTap.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        //hiển thị list book
        public IActionResult Index()
        {
            var dsBook = _db.Books.ToList();
            var tongsoluong = _db.Books.Sum(x => x.Quantity);
            ViewBag.SUM = tongsoluong;
            return View(dsBook);
        }
        //hiển thị giao diện thêm sách
        public IActionResult Add() {
            return View();
        }

        //xử lý thêm sách
        [HttpPost]
        public IActionResult Add(Book book)
        {
            if (ModelState.IsValid)
            {
                _db.Books.Add(book);
                _db.SaveChanges();
                TempData["success"] = "Đã thêm 1 quyển sách";
                return RedirectToAction("Index");
            }
            return View(book);
        }

        //hiển thị giao diện cập nhật sách
        public IActionResult Update(int id)
        {
            //var book = _db.Books.Find(id);
            var book = _db.Books.SingleOrDefault(x=>x.Id==id);
            if(book!=null)
               return View(book);

            return NotFound();
        }

        //xử lý sua sách
        [HttpPost]
        public IActionResult Update(Book book)
        {
            if (ModelState.IsValid)
            {
                _db.Books.Update(book);
                _db.SaveChanges();
                TempData["success"] = "Đã cập nhật 1 quyển sách";
                return RedirectToAction("Index");
            }
            return View(book);
        }
    }
}
