
using Course_app.Controllers;
using Repository.Enums;
using Service.Helpers.Extensions;

AccountController accountController = new AccountController();
GetMenues();
while (true)
{ 
    Operation: string opearionStr=Console.ReadLine();
    int operation;
    bool isCorrectOperation=int.TryParse(opearionStr, out operation);
    if (isCorrectOperation)
    {
        switch (operation)
        {
            case (int)OperationType.AccountRegister:
                accountController.Register();
                GetMenues();
                break;
            case (int)OperationType.AccountLogin:
                accountController.Login();
                GroupAndStudentsMenues();
                break;
        }
    }
    else
    {
        ConsoleColor.Red.WriteConsole("Operation format is wrong,please try again :");
        goto Operation;
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
