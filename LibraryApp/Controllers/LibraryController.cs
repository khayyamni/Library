using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Domain.Models;
using Service.Helpers.Extentions;
using Service.Services;
using Service.Services.Interfaces;

namespace LibraryApp.Controllers
{
    public class LibraryController
    {
        public readonly ILibraryService _libraryService;
        public LibraryController()
        {
            _libraryService = new LibraryService(); 
        }
        public void Create()
        {
            ConsoleColor.Cyan.WriteConsole("Add library name:");
            Name: string name =  Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Don't be empty :");
                goto Name;
            }

            bool isMatch = Regex.IsMatch(name, @"\d");
            if (isMatch)
            {
                ConsoleColor.Red.WriteConsole("Don't add digit for name :");
                goto Name;
            }

            ConsoleColor.Cyan.WriteConsole("Add library seat count:");
            SeatCount: string seatCountStr = Console.ReadLine();


            int seatCount;

            bool isCorrectSeatCount = int.TryParse(seatCountStr, out seatCount);

            if(isCorrectSeatCount)
            {
                Library library = new Library()
                {
                    Name = name,
                    SeatCount = seatCount
                };
                _libraryService.Create(library);
                ConsoleColor.Green.WriteConsole("Library create success");
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Please add seat count format again :");
                goto SeatCount;
            }
        }

        public void GetAll()
        {
            var result = _libraryService.GetAll();
            foreach(var item in result)
            {
                string data = $"{item.Id} - {item.Name} - {item.SeatCount}";
                ConsoleColor.Green.WriteConsole(data);
            }
        }

        public void GetById()
        {
            ConsoleColor.Cyan.WriteConsole("Add library id:");
            Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrectId = int.TryParse(idStr, out id);

            if(isCorrectId)
            {
                
                var result = _libraryService.GetById(id);

                if(result is null)
                {
                    ConsoleColor.Red.WriteConsole("Data not found, Write Id again:");
                    goto Id;
                }


                string data = $"{result.Id} - {result.Name} - {result.SeatCount}";
                ConsoleColor.Green.WriteConsole(data);


            }
            else
            {
                ConsoleColor.Red.WriteConsole("Please add id format again :");
                goto Id;
            }
        }

    }
}
