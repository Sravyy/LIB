using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using Library;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }
 //GET ALL AUTHORS
      [HttpGet("/Authors")]
      public ActionResult Results2()
      {
        return View("AllAuthors",Author.GetAll());
      }

      [HttpPost("/Authors")]
      public ActionResult AllAuthors()
      {
        Author newAuthor = new Author (Request.Form["inputAuthor"]);
        newAuthor.Save();
        return View (Author.GetAll());
      }
//ROUTE TO LIBRARIAN PAGE
      [HttpGet("/Librarian")]
      public ActionResult Librarian()
      {
        return View();
      }
//GET ALL PATRONS
      [HttpGet("/Patrons")]
      public ActionResult GetAllPatrons()
      {
        return View("Patron",Patron.GetAll());
      }

      [HttpPost("/Patrons")]
      public ActionResult PostPatron()
      {
        Patron newPatron = new Patron (Request.Form["patron"]);
        newPatron.Save();
        return View ("Patron", Patron.GetAll());
      }

//VIEW INDIVIDUAL AUTHOR
      [HttpGet("/Authors/{id}")]
      public ActionResult AuthorBooks(int id)
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Author selectedAuthor = Author.Find(id);
        List<Book> authorBooks = selectedAuthor.GetBooks();
        model.Add("author", selectedAuthor);
        model.Add("books", authorBooks);
        return View(model);
      }

      [HttpPost("/Authors/{id}")]
      public ActionResult NewBookToAuthor(int id)
      {
        string bookcopies = Request.Form["inputBook"];
        Book newBook = new Book(bookcopies,(Int32.Parse(Request.Form["inputDate"])));
        newBook.Save();
        Dictionary<string, object> model = new Dictionary<string, object>();
        Author selectedAuthor = Author.Find(Int32.Parse(Request.Form["author-id"]));
        selectedAuthor.AddBook(newBook);
        List<Book> authorBooks = selectedAuthor.GetBooks();
        model.Add("books", authorBooks);
        model.Add("author", selectedAuthor);
        return View("AuthorBooks", model);
      }
//VIEW INDIVIDUAL PATRON , CHECKEDOUT BOOKS
      [HttpGet("/patron/{id}")]
      public ActionResult PatronBooks(int id)
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Patron newPatron = Patron.Find(id);
        List<Book> patronBooks = Book.GetAll();
        model.Add("patron", newPatron);
        model.Add("books", patronBooks);
        return View(model);
      }


      [HttpGet("/Patrons/{patron_id}/{book_id}/Checkout")]
      public ActionResult checkout(int patron_id, int book_id)
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Patron newPatron = Patron.Find(patron_id);
        Book foundBook = Book.Find(book_id);
        model.Add("patron", newPatron);
        model.Add("books", foundBook);
        return View("checkout");
      }

      [HttpPost("/Patrons/{patron_id}/{book_id}/Checkout")]
      public ActionResult CheckoutPost(int patron_id, int book_id)
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Patron newPatron = Patron.Find(patron_id);
        Book foundBook = Book.Find(book_id);
        foundBook.BookCheckout();
        model.Add("patron", newPatron);
        model.Add("book", foundBook);
        return View("PatronBooks", model);
      }

      [HttpGet("/Authors/{id}/books/new")]
      public ActionResult BookForm(int id)
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Author selectedAuthor = Author.Find(id);
        List<Book> allBooks = selectedAuthor.GetBooks();
        model.Add("author", selectedAuthor);
        model.Add("books", allBooks);
        return View("AuthorBooks", model);
      }

      [HttpPost("/BookList")]
      public ActionResult DeletePage2()
      {
        Book.DeleteAll();
        return View();
      }

      [HttpPost("/Authors/{id}/Delete")]
      public ActionResult DeleteAuthor(int id)
      {
        Author foundAuthor = Author.Find(id);
        foreach (Book classBook in foundAuthor.GetBooks())
          {
            classBook.DeleteBooks();
          }
        foundAuthor.DeleteAuthor();
        return View("DeletePage3");
      }

      [HttpPost("/Authors/Delete")]
      public ActionResult DeletePage()
      {
        Author.DeleteAll();
        return View();
      }

      [HttpGet("/BookList")]
      public ActionResult AllBooks()
      {
        return View(Book.GetAlphaList());
      }

      [HttpGet("/Books/{id}")]
      public ActionResult BookAuthors(int id)
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Book selectedBook = Book.Find(id);
        List<Author> allAuthors = selectedBook.GetAuthors();
        model.Add("book", selectedBook);
        model.Add("author", allAuthors);
        return View(model);
      }

      [HttpGet("/book/{id}/authors/new")]
      public ActionResult authorsForm(int id)
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Book selectedBook = Book.Find(id);
        List<Author> allAuthors = selectedBook.GetAuthors();
        model.Add("book", selectedBook);
        model.Add("author", allAuthors);
        return View(model);
      }

      [HttpPost("/Books/{id}")]
      public ActionResult BookAuthors2(int id)
      {

        Author newAuthor = new Author(Request.Form["inputAuthor"]);
        newAuthor.Save();

        Dictionary<string, object> model = new Dictionary<string, object>();
        Book selectedBook = Book.Find(Int32.Parse(Request.Form["book-id"]));
        selectedBook.AddAuthor(newAuthor);
        List<Author> allAuthors = selectedBook.GetAuthors();
        model.Add("book", selectedBook);
        model.Add("author", allAuthors);
        return View("BookAuthors", model);
      }
    }
  }
