using YukiTest.Domain.Interfaces;

namespace YukiTest.Domain.Model
{
    public class Author:IEntity
    {
        protected Author() { }
        public Author( string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public static Author Create(string name, string surname)
        {
            return new Author(name, surname);
        }
    }
}
