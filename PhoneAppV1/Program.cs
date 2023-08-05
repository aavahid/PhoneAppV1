using Domain.Enums;
using Domain.Models;
using Services.Helpers.Controllers;

Menues();

PersonCtroller personController = new();
while (true)
{
    List<Person> people = new List<Person>();
    

    string option = Console.ReadLine();

    int selectedOption;
Menu: bool isTrueOption = int.TryParse(option, out selectedOption);

    if (isTrueOption)
    {
        switch ((Operations)selectedOption)
        {
            case Operations.Create:
                personController.Create();
                break;
            case Operations.Delete:
                personController.Delete();
                break;
            case Operations.Edit:
                personController.Edit();
                break;
            case Operations.GetAll:
                personController.GetAll();
                break;
            default:
                Console.WriteLine("Option is wrong, please select the true option again:");
                goto Menu;
        }
    }
    else
    {
        Console.WriteLine("Option is wrong, Please try again : ");
        goto Menu;

    }

}

static void Menues()
{
    Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :");
    Console.WriteLine("1. Yeni Numara Kaydetmek");
    Console.WriteLine("2. Varolan Numarayı Silmek");
    Console.WriteLine("3. Varolan Numarayı Güncelleme");
    Console.WriteLine("4. Rehberi Listelemek");
    Console.WriteLine("5. Rehberde Arama Yapmak﻿");
}


        

       
        

    
 



