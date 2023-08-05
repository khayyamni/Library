using LibraryApp.Controllers;
using Service.Helpers.Enums;
using Service.Helpers.Extentions;

Menues();



LibraryController library = new();


while (true)
{

    Operation:  string operationStr = Console.ReadLine();

    int operation;

    bool isCorrectOperation = int.TryParse(operationStr, out operation);


    if (isCorrectOperation)
    {
        switch (operation)
        {
            case (int)Operations.CreateLibrary:
                //Console.WriteLine("Library Create");
                library.Create();
                break;
            case 2:
                Console.WriteLine("Library Delete");
                break;
            case 3:
                Console.WriteLine("Library Edit");
                break;
            case (int)Operations.GetAllLibraries:
                library .GetAll();
                break;
            case (int)Operations.GetLibraryById:
                library.GetById();
                break;
            default:
                ConsoleColor.Red.WriteConsole("Please write correct option:");
                goto Operation;
        }
    }
    else
    {
        ConsoleColor.Red.WriteConsole("Please write correct option format:");
        goto Operation;
    }


}


static void Menues()
{
    ConsoleColor.Cyan.WriteConsole("CHoose one option for working with application : " +
    "Library operations : 1 - Create, 2 - Delete. 3 - Edit, 4 - GetAll, 5 - GetById");

}