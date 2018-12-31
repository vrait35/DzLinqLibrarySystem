using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzLibrarySystemLinQ
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public Book()
        {
            Authors = new List<Author>();
        }
    }
}
