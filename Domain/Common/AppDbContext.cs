using Domain.Models;

namespace Domain.Common
{
    public abstract class AppDbContext
	{
        public static List<Person> people;


        static AppDbContext()
        {
            
            people = new List<Person>
            {
                new Person { Id = 1, Name = "Vahid", Surname = "Aghazada", Phone = "1234567890" },
                new Person { Id = 2, Name = "Sahla", Surname = "Rasulzada", Phone = "9876543210" },
                new Person { Id = 3, Name = "Bob", Surname = "Dylan", Phone = "5555555555" },
                new Person { Id = 4, Name = "Stick", Surname = "Unjobs", Phone = "7777777777" },
                new Person { Id = 5, Name = "David", Surname = "Ironfield", Phone = "9999999999" }
            };
        }

    }
}

