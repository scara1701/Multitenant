using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Multitenant.Core.Data
{
    public class BookCategory : BaseEntity
    {
        private readonly List<Book> _books = new List<Book>();
        public BookCategory()
        {
        }

        public BookCategory(int tenantID, int id, string name)
        {
            TenantId = tenantID;
            Id = id;
            Name = name; 
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public IEnumerable<Book> Books => _books.AsReadOnly();

        public void AddBook(Book book)
        {
            book.Category = this;
            _books.Add(book);
        }
    }
}
