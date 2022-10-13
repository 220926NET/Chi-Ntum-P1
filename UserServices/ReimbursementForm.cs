namespace UserServices;
using Data;
public class ReimbursementForm{

    //possibly come up with class for ticketNumbers
    private string details;
    private decimal amount;
    private string userId;
    private int ticketNumber;

    public ReimbursementForm(){}
    
    public ReimbursementForm(string userId){
        this.userId = userId;
        //pull form for userId, then:
        Console.WriteLine("What is the amount of your reimbursement. \n\nAmount:");
        this.amount = decimal.Parse(Console.ReadLine());
        //save amount with ticket number for userId
        Console.WriteLine("Are there any details you would like to add.\n\nDetails:");
        this.details = Console.ReadLine();

        Data form = new Data();
        form.AddForm(amount, details, userId);
    }
    public ReimbursementForm(string userId,string details,decimal amount, int ticketNumber){
        this.userId = userId;
        this.details = details;
        this.amount = amount;
        this.ticketNumber = ticketNumber;
    }

}