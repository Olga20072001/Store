using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1,"ISBN 12312-32131","D. Knuth","Art of Programming" , " aaaaa", 7.19m),
            new Book(2,"ISBN 12312-32132","M. Fowler","Refactoring", "bbbbb ",12.45m),
            new Book(3,"ISBN 12312-32133","B. Kernighan, D.Ritchie","C Programming Language"," ccccc" , 14.98m),
        };

        public Book[] GetAllByIds(IEnumerable<int> bookIds)
        {
            var foundBooks = from book in books
                             join bookId in bookIds on book.Id equals bookId
                             select book;
            return foundBooks.ToArray();
        }

        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn)
                         .ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string titlePart)
        {
            return books.Where(book => book.Author.Contains(titlePart) 
                                    || book.Title.Contains(titlePart))
                        .ToArray();
        }

        public Book GetById(int id)
        {
            return books.Single(Book => Book.Id == id);
        }
    }
}
