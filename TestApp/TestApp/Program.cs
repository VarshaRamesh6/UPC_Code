using System;
public class Program
{
    
    public bool IsAllDigits(string userValue)
    {
        foreach (char c in userValue)
        {
            if (!char.IsDigit(c))
                return false;
        }
        return true;
    }

    public bool ValidateLength(string userValue)
    {
        if (userValue.ToString().Length < 11 || userValue.ToString().Length > 11)
        {
            return false;
         }
        return true;
    }
 
    public static void Main()
    {
        Console.WriteLine("Hello!!");
        int sumEven = 0;
        int sumOdd = 0;
        Console.WriteLine("Enter your UPC Code");
        string userValue;
        bool flagDig = true;
        bool flagLen = true;
        userValue = Console.ReadLine();
        int strLen = userValue.ToString().Length;

        // To validate if the entered UPC code is within the range
    Program p2 = new Program();
    bool length = p2.ValidateLength(userValue);
        
    while (!length)
    {
        
        Console.WriteLine("Invalid UPC Code! Length is not 11");
        userValue = Console.ReadLine();
        length = p2.ValidateLength(userValue);
        flagLen = false;
    }
    // To validate if the entered UPC code has Digits 
    Program p = new Program();
    bool isChar = p.IsAllDigits(userValue);
        
        while (!isChar)
        {
            flagDig = false;
            if (flagLen == true)
            {
                Console.WriteLine("Invalid UPC Code! Enter digits only");
                userValue = Console.ReadLine();
                length = p2.ValidateLength(userValue);
                // isChar = p.IsAllDigits(userValue);
            }
            else if (flagDig == false && flagLen == false)
            {
                Console.WriteLine("Invalid UPC Code! Entered code is not 11 digits and contains non numeric values");
                userValue = Console.ReadLine();
                isChar = p.IsAllDigits(userValue);
                flagLen = true;
            }
         }
         

        // Arithmetic Computation of Check Digit
        for (int i = 0; i < strLen; i++)
        {
            if (i % 2 == 0)
            {
                sumOdd += Convert.ToInt16(userValue[i].ToString());
            }
            else
            {
                sumEven += Convert.ToInt16(userValue[i].ToString());
            }
        }
        int step2 = sumOdd * 3;
        int step3 = step2 + sumEven;
        int remainder = step3 % 10;
        int checkDigit;
        if (remainder == 0)
        {
            checkDigit = 0;
        }
        else
        {
            checkDigit = 10 - remainder;
        }
        string check = checkDigit.ToString();
        string final = userValue + check;

        Console.WriteLine("CheckDigit = {0}", checkDigit);
        Console.WriteLine("UPC_A Code with Check is {0}", final);

    }
 }

