namespace DzLibrarySystemLinQ
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LibrarySystemContext : DbContext
    {
        // Контекст настроен для использования строки подключения "LibrarySystemContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "DzLibrarySystemLinQ.LibrarySystemContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "LibrarySystemContext" 
        // в файле конфигурации приложения.
        public LibrarySystemContext()
            : base("name=LibrarySystemContext")
        {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}