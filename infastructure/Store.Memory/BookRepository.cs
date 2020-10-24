﻿using System;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1,"ISBN 12312-32131","D. Knuth","Art of Programming"),
            new Book(2,"ISBN 12312-32132","M. Fowler","Refactoring"),
            new Book(3,"ISBN 12312-32133","B. Kernighan, D.Ritchie","C Programming Language"),
        };

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
    }
}
