using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

  namespace Library.Models
{
  public class Copy
  {
    private string _checkoutDate;
    private int _id;


    public Copy(string checkoutDate,int id = 0)

    {
      _checkoutDate = checkoutDate;
      _id = id;
    }

    public override bool Equals(System.Object otherCopy)
    {
      if (!(otherCopy is Copy))
      {
        return false;
      }
      else
      {
        Copy newCopy = (Copy) otherCopy;
        return this.GetId().Equals(newCopy.GetId());
      }
    }
    public override int GetHashCode()
    {
      return this.GetId().GetHashCode();
    }
    public string GetCheckOutDate()
    {
      return _checkoutDate;
    }
    public int GetId()
    {
      return _id;
    }
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO copies (checkoutDate) VALUES (@checkoutDate);";

      MySqlParameter checkoutDate = new MySqlParameter();
      checkoutDate.ParameterName = "@checkoutDate";
      checkoutDate.Value = this._checkoutDate;
      cmd.Parameters.Add(checkoutDate);


      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Copy> GetAll()
    {
      List<Copy> allCopy = new List<Copy> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM copies;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int CopyId = rdr.GetInt32(0);
        string CopyName = rdr.GetString(1);
        Copy newCopy = new Copy(CopyName, CopyId);
        allCopy.Add(newCopy);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCopy;
    }

    public static Copy Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM copies WHERE id = (@searchId);";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int CopyId = 0;
      string CopyName = "";


      while(rdr.Read())
      {
        CopyId = rdr.GetInt32(0);
        CopyName = rdr.GetString(1);

      }
      Copy newCopy = new Copy(CopyName, CopyId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newCopy;
    }

    public void AddBook(Book newBook)
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO books_copies (book_id, copy_id) VALUES (@BookId, @CopyId);";

        MySqlParameter book_id = new MySqlParameter();
        book_id.ParameterName = "@BookId";
        book_id.Value = newBook.GetId();
        cmd.Parameters.Add(book_id);

        MySqlParameter copy_id = new MySqlParameter();
        copy_id.ParameterName = "@CopyId";
        copy_id.Value = _id;
        cmd.Parameters.Add(copy_id);

        cmd.ExecuteNonQuery();
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
    }

    public List<Book> GetBooks()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT books.* FROM copies JOIN books_copies ON (copies.id = books_copies.copy_id) JOIN books ON (books_copies.book_id = books.id) WHERE copies.id = @CopyId;";

      MySqlParameter CopyId = new MySqlParameter();
      CopyId.ParameterName = "@CopyId";
      CopyId.Value = _id;
      cmd.Parameters.Add(CopyId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Book> books = new List<Book>{};

      while(rdr.Read())
      {
        int bookId = rdr.GetInt32(0);
        string bookTitlename = rdr.GetString(1);
        int bookcopies = rdr.GetInt32(2);
        Book newBook = new Book(bookTitlename, bookcopies, bookId);
        books.Add(newBook);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return books;
    }

    public void AddPatron(Patron newPatron)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO patrons_copies (patron_id, copy_id) VALUES (@PatronId, @CopyId);";

            MySqlParameter patron_id = new MySqlParameter();
            patron_id.ParameterName = "@PatronId";
            patron_id.Value = _id;
            cmd.Parameters.Add(patron_id);

            MySqlParameter copy_id = new MySqlParameter();
            copy_id.ParameterName = "@CopyId";
            copy_id.Value = newPatron.GetId();
            cmd.Parameters.Add(copy_id);

            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public List<Patron> GetPatrons()
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT patrons.* FROM copies JOIN patrons_copies ON (copies.id = patrons_copies.copy_id) JOIN patrons ON (patrons_copies.patron_id = patrons.id) WHERE copies.id = @CopyId;";

          MySqlParameter CopyId = new MySqlParameter();
          CopyId.ParameterName = "@CopyId";
          CopyId.Value = _id;
          cmd.Parameters.Add(CopyId);

          var rdr = cmd.ExecuteReader() as MySqlDataReader;
          List<Patron> patrons = new List<Patron>{};

          while(rdr.Read())
          {
            int patronId = rdr.GetInt32(0);
            string patronname = rdr.GetString(1);

            Patron newPatron = new Patron(patronname,patronId);
            patrons.Add(newPatron);
          }
          conn.Close();
          if (conn != null)
          {
            conn.Dispose();
          }
          return patrons;
        }



    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM copies;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    // public void Delete()
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //
    //   MySqlCommand cmd = new MySqlCommand("DELETE FROM patrons WHERE id = @PatronId; DELETE FROM patrons_books WHERE patron_id = @PatronId;", conn);
    //   MySqlParameter patronsIdParameter = new MySqlParameter();
    //   patronsIdParameter.ParameterName = "@PatronId";
    //   patronsIdParameter.Value = this.GetId();
    //
    //   cmd.Parameters.Add(patronsIdParameter);
    //   cmd.ExecuteNonQuery();
    //
    //   if (conn != null)
    //   {
    //     conn.Close();
    //   }
    // }

  }

}
