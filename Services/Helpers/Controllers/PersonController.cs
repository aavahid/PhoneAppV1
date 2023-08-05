using System;
using Domain.Models;
using Services.Services;
using Services.Services.Interfaces;

namespace Services.Helpers.Controllers
{
    public class PersonCtroller
    {
        private readonly IPersonServices _service;

        public PersonCtroller()
        {
            _service = new PersonService();
        }

        public void Create()
        {

            Console.WriteLine("Add name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Add surname: ");
            string surname = Console.ReadLine();

            Console.WriteLine("Add phone number: ");
            string phoneNumber = Console.ReadLine();

            Person person = new()
            {
                Name = name,
                Surname = surname,
                Phone = phoneNumber
            };

            _service.Create(person);

            Console.WriteLine("Person added operation is success");
        }

        public void GetAll()
        {
            foreach (var item in _service.GetAll())
            {
                string data = $"Id: {item.Id}, FullName : {item.Name} {item.Surname}, Phone: {item.Phone}";
                Console.WriteLine(data);
            }
        }

        public void Delete()
        {
            Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");

        NameOrSurname: string nameOrSurname = Console.ReadLine();

            if (string.IsNullOrEmpty(nameOrSurname.Trim()))
            {
                Console.WriteLine("Dont be empty, please try again:");
                goto NameOrSurname;
            }

            bool result = _service.Delete(nameOrSurname);

            if (!result)
            {
                Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.\r\n" +
                    "  * Silmeyi sonlandırmak için : (1)\r\n  * Yeniden denemek için      : (2)");

            Option: string option = Console.ReadLine();

                int selectedOption;

                bool isTrueOption = int.TryParse(option, out selectedOption);

                if (isTrueOption)
                {
                    switch (selectedOption)
                    {
                        case 1:
                            Console.WriteLine("Select main option:");
                            break;
                        case 2:
                            Console.WriteLine("Try again for delete:");
                            goto NameOrSurname;

                        default:
                            Console.WriteLine("Try again for option:");
                            goto Option;
                    }
                }
                else
                {
                    Console.WriteLine("Select option again:");
                    goto Option;
                }
            }
            else
            {
                Console.WriteLine("Deleted success");
            }



        }

        public void Edit()
        {
            Console.WriteLine("Lütfen numarasını guncellemek istediğiniz kişinin adını ya da soyadını giriniz:");

        NameOrSurname: string nameOrSurname = Console.ReadLine();

            if (string.IsNullOrEmpty(nameOrSurname.Trim()))
            {
                Console.WriteLine("Dont be empty, please try again:");
                goto NameOrSurname;
            }

            Console.WriteLine("Please add new phone number: ");
        PhoneNumber: string newPhone = Console.ReadLine();

            if (string.IsNullOrEmpty(newPhone.Trim()))
            {
                Console.WriteLine("Dont be empty, please try again:");
                goto PhoneNumber;
            }


            bool result = _service.Edit(nameOrSurname, newPhone);

            if (!result)
            {
                Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.\r\n" +
                    "  * Güncellemeyi  sonlandırmak için : (1)\r\n  * Yeniden denemek için      : (2)");

            Option: string option = Console.ReadLine();

                int selectedOption;

                bool isTrueOption = int.TryParse(option, out selectedOption);

                if (isTrueOption)
                {
                    switch (selectedOption)
                    {
                        case 1:
                            Console.WriteLine("Select main option:");
                            break;
                        case 2:
                            Console.WriteLine("Try again for edit:");
                            goto NameOrSurname;

                        default:
                            Console.WriteLine("Try again for option:");
                            goto Option;
                    }
                }
                else
                {
                    Console.WriteLine("Select option again:");
                    goto Option;
                }
            }
            else
            {
                Console.WriteLine("Edit success");
            }
        }

        public void GetById()
        {

        }
        public void Search()
        {
            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.\r\n ********************************************** " +
                "İsim veya soyisime göre arama yapmak için: (1) Telefon numarasına göre arama yapmak için: (2)");


        Option: string option = Console.ReadLine();

            int selectedOption;

            bool isTrueOption = int.TryParse(option, out selectedOption);


            if (isTrueOption)
            {
                switch (selectedOption)
                {
                    case 1:
                    SearchByNameOrSurname: string searchByNameOrSurname = Console.ReadLine();

                        if (string.IsNullOrEmpty(searchByNameOrSurname))
                        {
                            goto SearchByNameOrSurname;
                        }

                        foreach (var item in _service.SearchByNameorSurname(searchByNameOrSurname))
                        {
                            string data = $"Id: {item.Id}, FullName : {item.Name} {item.Surname}, Phone: {item.Phone}";
                            Console.WriteLine(data);
                        }
                        break;

                    case 2:
                    SearchPhone: string searchPhone = Console.ReadLine();

                        if (string.IsNullOrEmpty(searchPhone))
                        {
                            goto SearchPhone;
                        }

                        foreach (var item in _service.SearchByPhoneNumber(searchPhone))
                        {
                            string data = $"Id: {item.Id}, FullName : {item.Name} {item.Surname}, Phone: {item.Phone}";
                            Console.WriteLine(data);
                        }

                        break;

                    default:
                        Console.WriteLine("Try again for option:");
                        goto Option;
                }
            }



        }
    }
}
