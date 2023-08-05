using System;
using Domain.Common;
using Domain.Models;
using Services.Services.Interfaces;

namespace Services.Services
{
    public class PersonService : IPersonServices
    {
        private int _count = 1;

        public void Create(Person person)
        {
            person.Id = _count;
            AppDbContext.people.Add(person);
            _count++;
        }

        public bool Delete(string nameOrSurname)
        {
            //Person person = new();

            //foreach (var item in AppDbContext.people)
            //{
            //    if(item.Name == nameOrSurname || item.Surname == nameOrSurname)
            //    {
            //        person = item;
            //        break;
            //    }
            //}

            var existPerson = AppDbContext.people.FirstOrDefault(m => m.Name == nameOrSurname || m.Surname == nameOrSurname);
            if (existPerson != null)
            {
                AppDbContext.people.Remove(existPerson);
                return true;
            }

            return false;


        }

        public bool Edit(string nameOrSurname, string newPhone)
        {
            var existPerson = AppDbContext.people.FirstOrDefault(m => m.Name == nameOrSurname || m.Surname == nameOrSurname);

            if (existPerson != null)
            {
                existPerson.Phone = newPhone;
                return true;
            }

            return false;
        }


        public List<Person> GetAll()
            {
                return AppDbContext.people;
            }

            public List<Person> SearchByNameorSurname(string searchText)
            {
                return AppDbContext.people.Where(m => m.Name.Contains(searchText) || m.Surname.Contains(searchText)).ToList();
            }

            public List<Person> SearchByPhoneNumber(string searchText) => AppDbContext.people.Where(m => m.Phone.Contains(searchText)).ToList();

        }
    }
