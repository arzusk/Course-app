
using Course_app.Controllers;
using Repository.Enums;
using Service.Helpers.Extensions;

AccountController accountController = new AccountController();
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
                GroupAndStudentsMenues();
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
    while (true)
    {
        GroupAndStudentsMenues();
        StudentController studentController = new StudentController();
        GroupController groupController = new GroupController();
    Operation: string operations = Console.ReadLine();
        int operation;
        bool isCorrectOperation = int.TryParse(operations, out operation);
        if (isCorrectOperation)
        {
            switch (operation)
            {
                case (int)OperationType.GroupCreate:
                    groupController.CreateGroup();
                    break;
                case (int)OperationType.GroupGetAll:
                    groupController.GetAll();
                    break;
                case (int)OperationType.StudentCreate:
                    studentController.Create();
                    goto Operation;
                case (int)OperationType.StudentGetAll:
                    studentController.GetAll();
                    break;
            }
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

