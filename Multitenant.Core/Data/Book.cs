using System;

namespace Multitenant.Core.Data
{
    public class Book : BaseEntity
    {
        private string _name;
        private string _description;
        private BookCategory _category;

        public Book()
        {

        }

        public Book(int tenantId, int id, string name, string description)
        {
            TenantId = tenantId;
            Id = id;
            Name = name;
            Description = description;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception(nameof(Name) + " cannot be null or empty string");
                }

                if(value.Length > 50)
                {
                    throw new Exception(nameof(Name) + " cannot be longer than 50 characters");
                }

                _name = value;
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new Exception(nameof(Description) + " cannot be null or empty string");
                }
                if(value.Length> 512)
                {
                    throw new Exception(nameof(Description) + " cannot be longer than 512 characters");
                }
                _description = value;
            }
        }

        public BookCategory BookCategory
        {
            get { return _category; }
            set
            {
                if(value == null)
                {
                    throw new Exception(nameof(BookCategory) + " cannot be null");
                }
                _category = value;
            }
        }
    }
}
