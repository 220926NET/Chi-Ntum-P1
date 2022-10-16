﻿using UserServices;

class ReimbursementLogin{
    
    private string userName;
    private string userPassword;
    private string userId;
    EmployeeMenu emp = new EmployeeMenu();

    //runs the initial application
    public void run(){
        loginMenu();
    }

    //the standard login
    public void loginMenu(){

        Console.WriteLine("Hello, welcome to Revature-test Reimbursement Application.\n\nLogin\nUsername:\n\nIf you are a new user please type 'yes'.");

        String ans = Console.ReadLine();

        string user = "";

        if (ans.Equals("yes", StringComparison.OrdinalIgnoreCase)){
            newUserLogin();
        }else{
            this.userName = ans;
            Console.WriteLine("Login\nPassword:");
            this.userPassword = Console.ReadLine();
        }
        userId = userName + userPassword;
        string manager ="m+" + userName + userPassword;
        if (emp.Exists(manager)==true){
            user = "manager";
        }
        //if userId matches manager then use ManagerMenu
        if (user == "manager"){
            ManagerMenu menu = new ManagerMenu(manager);
        }else{
            EmployeeMenu menu2 = new EmployeeMenu(userId, userName);
        }

    }

    //a login for new users
    public void newUserLogin(){
        Console.WriteLine("If you are a manager please enter 'yes' again, otherwise enter your new Username:");
        String ans = Console.ReadLine();
        if(ans.Equals("yes", StringComparison.OrdinalIgnoreCase)){
            newManagerLogin();
        }else{
            this.userName = ans;
            while(emp.nameExists(userName)==true){
                Console.WriteLine("Your username exists, please enter another.");
                userName = Console.ReadLine();
            }
            Console.WriteLine("Please enter your Password:");
            this.userPassword = Console.ReadLine();
            //add database call for users
            userId = userName + userPassword;
            //checks if userId exists already
            while(emp.Exists(userId)==true){
                //write message telling them to enter user/pass again
                Console.WriteLine("");
            }
            emp.Add(userId, userName, userPassword);

        }
    }
    
    //a login for managers
    public void newManagerLogin(){
        Console.WriteLine("Please enter your desired Username:");
        this.userName = Console.ReadLine();
        while(emp.nameExists(userName)==true){
            Console.WriteLine("Your username exists, please enter another.");
            userName = Console.ReadLine();
        }
        Console.WriteLine("Please enter your Password:");
        this.userPassword = Console.ReadLine();

        userId = "m+" + userName + userPassword;
        while(emp.Exists(userId)==true){
            //write message telling them to enter user/pass again
            Console.WriteLine("");
        }
        emp.Add(userId, userName, userPassword);
    }

}
