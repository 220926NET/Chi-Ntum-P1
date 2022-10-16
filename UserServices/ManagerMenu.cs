namespace UserServices;
using Data;
using System.Collections.Generic;
public class ManagerMenu{

    private string userId;
    public ManagerMenu(string userId){
        Console.WriteLine("Manager Menu:\n\nView Reimbursement tickets(1)\nUpdate Employee Status(2)");
        string ans = Console.ReadLine();
        if (ans.Equals("1")){
            //lookup open reimbursement tickets
            //close tickets once done
            ReimbursementTickets();
        }else if (ans.Equals("2")){
            //retrieve list of employees
            UpdateEmployeeStatus();
        }
    }
    public void UpdateEmployeeStatus(){
        Data data = new Data();
        List<string> emps= new List<string>();
        emps = data.GetEmployees();
        //writeout employees
        Console.WriteLine("Which employee would you like to promote?");
        while (emps.Count()>0){
            Console.WriteLine(emps[0]);
            emps.RemoveAt(0);
        }
        string ans = Console.ReadLine();
        data.PromoteEmployee(ans);

    }
    public void ReimbursementTickets(){
        //do lookup of ticketform
        List <String> data = new List<String>();
        Data forms = new Data();
        data = forms.GetUsers();
        Console.WriteLine("Which employee would you like to view?");
        //write info for interface
        while(data.Count()>0){
            Console.WriteLine(data[0]);
            data.RemoveAt(0);
        }
        string ans = Console.ReadLine();
        List<Object> form = new List<Object>();
        form = forms.GetEmployeeForm(ans);
        Console.WriteLine("Ticket Number: " + (int)form[0]);
        Console.WriteLine("Amount: " + (decimal)form[1]);
        Console.WriteLine("Details: " + (string)form[2]);

        string employeeName = ans;
        string employeeId = (string)form[3];
        Console.WriteLine("Approve(1)       SendBack[with comment](2)");
        ans = Console.ReadLine();
        if(ans == "1"){
            forms.Approve(employeeId);
        }else{
            //logic to send back with comment
            if(forms.OldFormOpen(employeeId)==true){
                Console.WriteLine("Comment:");
                string comment = Console.ReadLine();
                forms.SendBackAgain(comment, employeeId);
            }else{
                Console.WriteLine("Comment:");
                string comment = Console.ReadLine();
                forms.SendBack((int)form[0], comment, employeeName);
            }
        }



    }
}