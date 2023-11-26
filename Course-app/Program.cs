
using Course_app.Controllers;
using Domain.Models;
using Repository.Enums;
using Service.Helpers.Extensions;

AccountController accountController = new();


GetMenues();
while (true)
{
Operation: string opearionStr = Console.ReadLine();
    int operation;
    bool isCorrectOperation = int.TryParse(opearionStr, out operation);
    if (isCorrectOperation)
    {
        switch (operation)
        {
            case 1:
                accountController.Register();
                GetMenues();
                break;
            case 2:
                accountController.Login();
                GetStudentAndGroup();
                break;
            default:
                ConsoleColor.Red.WriteConsole("Operation is wrong, please try again : ");
                goto Operation;
        }
    }
    else
    {
        ConsoleColor.Red.WriteConsole("Operation format is wrong,please try again :");
        goto Operation;
    }
}


static void GetStudentAndGroup()
{
    StudentController studentController = new();
    GroupController groupController = new();

    while (true)
    {
        GroupAndStudentsMenues();

        string operationStr = Console.ReadLine();
        int operation;

        if (int.TryParse(operationStr, out operation))
        {
            switch (operation)
            {
                case (int)OperationType.GroupCreate:
                    groupController.CreateGroup();
                    break;
                case (int)OperationType.GroupDelete:
                    groupController.Delete();
                    break;
                case (int)OperationType.GroupEdit:
                    groupController.EditGroup();
                    break;
                case (int)OperationType.GroupGetById:
                    groupController.GetById();
                    break;
                case (int)OperationType.GroupGetAll:
                    groupController.GetAll();
                    break;
                case (int)OperationType.GroupSearch:
                    groupController.Search();
                    break;
                case (int)OperationType.GroupSorting:
                    groupController.Filter();
                    break;
                case (int)OperationType.StudentCreate:
                    studentController.Create();
                    break;
                case (int)OperationType.StudentDelete:
                    studentController.Delete();
                    break;
                case (int)OperationType.StudentEdit:
                    studentController.Edit();
                    break;
                case (int)OperationType.StudentGetById:
                    studentController.GetById();
                    break;
                case (int)OperationType.StudentGetAll:
                    studentController.GetAll();
                    break;
                case (int)OperationType.StudentSorting:
                    studentController.Filter();
                    break;
                case (int)OperationType.StudentSearch:
                    studentController.Search();
                    break;
                default:
                    ConsoleColor.Red.WriteConsole("Invalid operation. Please try again.");
                    break;
            }
        }
        else
        {
            ConsoleColor.Red.WriteConsole("Invalid operation format. Please try again.");
        }
    }
}

static void GetMenues()
{
    ConsoleColor.Cyan.WriteConsole("(1) - Register, (2) - Login");
}
static void GroupAndStudentsMenues()
{
    ConsoleColor.Cyan.WriteConsole("Please select one option: Group operations: 1-Create, 2-Delete, 3-Edit, 4- GetById, 5-GetAll, 6-Search, 7-Sorting ");
    ConsoleColor.Cyan.WriteConsole("Student operations : 8-Create, 9-Delete,10-Edit, 11-GetById, 12-GetAll, 13-Filter,14-Search");
}


