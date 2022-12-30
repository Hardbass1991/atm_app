using System;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    /* Getters*/
    public String getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public String getFirstName()
    {
        return firstName;
    }

    public String getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    /* Setters */

    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options: ");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("Please enter the deposit amount: ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Your new balance is " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("Please enter the withdrawal amount: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            if(currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient balance.");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You are good to go.");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("4716372545654774", 6969, "Edson", "Arantes Do Nascimento", 1279.00));
        cardHolders.Add(new cardHolder("4716686036458753", 2937, "Jan", "Twardowski", 1945.00));
        cardHolders.Add(new cardHolder("4024007101734621", 2605, "Michael", "Jackson", 51.00));
        cardHolders.Add(new cardHolder("4916497802234933", 1097, "Joseph", "Stalin", 1953.00));
        cardHolders.Add(new cardHolder("4916862556238317", 0763, "Kick", "Bukowski", 150.00));
        cardHolders.Add(new cardHolder("4233743076129929", 5203, "Berlin", "Mauer", 1989.00));
        cardHolders.Add(new cardHolder("4916804385544713", 7655, "Matt", "Hardy", 1010.01));

        Console.WriteLine("Welcome to Keybank ATM");
        Console.WriteLine("Please enter your card number");
        String debitCardNum = "";
        cardHolder currentUser;

        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) {break; }
                else {Console.WriteLine("Card not recognized. Please try again");}
            }
            catch {Console.WriteLine("Card not recognized. Please try again");}
        }

        Console.WriteLine("Please enter your pin");
        int userPin = 0;
        while(true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin) {break; }
                else {Console.WriteLine("Incorrect pin. Please try again");}
            }
            catch {Console.WriteLine("Incorrect pin. Please try again");}
        }

        Console.WriteLine("Welcome, " + currentUser.getFirstName());
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch {}
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you for using Keybank ATM. Have a nice day!");
    }

}
