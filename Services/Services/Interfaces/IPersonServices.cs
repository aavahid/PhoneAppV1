using System;
using Domain.Models;

namespace Services.Services.Interfaces
{
	public interface IPersonServices
    {
        void Create(Person person);
        List<Person> GetAll();
        bool Delete(string nameOrSurname);
        bool Edit(string nameOrSurname, string newPhone);
        List<Person> SearchByPhoneNumber(string searchText);
        List<Person> SearchByNameorSurname(string searchText);


    }
}