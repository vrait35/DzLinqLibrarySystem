using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DzLibrarySystemLinQ
{
    class Program
    {
        static void Main(string[] args)
        {           
            List<Author> authorsList = new List<Author>
            {
                new Author
                {
                    FullName="Евгений Петрович",
                    Books=new List<Book>
                    {
                        new Book
                        {
                            Name="Воробей"
                        },
                        new Book
                        {
                            Name="Медведь"
                        },
                        new Book
                        {
                            Name="Снеговик"
                        }
                    }
                },
                new Author
                {
                    FullName="Абай Кунанбаев",
                    Books=new List<Book>
                    {
                        new Book
                        {
                            Name="Муравей"
                        },
                        new Book
                        {
                            Name="Дед мороз"
                        },
                        new Book
                        {
                            Name="Снегурочка"
                        }
                    }
                }
            };
            using(LibrarySystemContext context=new LibrarySystemContext())
            {
                context.Authors.AddRange(authorsList);
               context.SaveChanges();
            }           
            using(LibrarySystemContext context=new LibrarySystemContext())
            {
                var books = context.Books.Include(b => b.Authors).ToList();
                foreach(Book b in books)
                {
                    Console.Write("Id="+b.Id+" Название книги: "+b.Name+" Авторы: ");
                    foreach(Author a in b.Authors)
                    {
                        Console.Write(a.FullName+"   ");
                    }
                    Console.WriteLine();
                }              
                int idBook = 0;
                bool isTrue = false;
                while (!isTrue)
                {
                    Console.WriteLine("введите id книги : ");
                    try
                    {
                        idBook = int.Parse(Console.ReadLine());
                        isTrue = true;
                    }
                    catch (ArgumentNullException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (OverflowException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                var booksLinq = context.Books.Where(b => b.Id == idBook);
                foreach(Book b in booksLinq)
                {
                    Console.Write("Id=" + b.Id + " Название книги: " + b.Name + " Авторы: ");
                    foreach (Author a in b.Authors)
                    {
                        Console.Write(a.FullName + "   ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("введите название книги");
                var nameBook = Console.ReadLine();
                //booksLinq = context.Books.Where(b => b.Name == nameBook);
                booksLinq = from b in context.Books where b.Name == nameBook select b;
                foreach (Book b in booksLinq)
                {
                    Console.Write("Id=" + b.Id + " Название книги: " + b.Name + " Авторы: ");
                    foreach (Author a in b.Authors)
                    {
                        Console.Write(a.FullName + "   ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("введите автора");
                var author = Console.ReadLine();
                var authors = context.Authors.Include(a => a.Books).ToList().Where(a => a.FullName == author);
                foreach(var a in authors)
                {
                    Console.Write("  "+a.FullName);
                    foreach(Book b in a.Books)
                    {
                        Console.Write("  "+b.Name+"   ");
                    }
                    Console.WriteLine();
                }
            }            
        }
    }
}
