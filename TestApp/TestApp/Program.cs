using System;

public class Program
{
    public string calculate_check_digit(string input)
    {
        int sumEven = 0;
        int sumOdd = 0;
        int strLen = input.ToString().Length;
        for (int i = 0; i < strLen; i++)
        {
            if (i % 2 == 0)
            {
                sumOdd += Convert.ToInt16(input[i].ToString());
            }
            else
            {
                sumEven += Convert.ToInt16(input[i].ToString());
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
        string final = input + check;
        Console.WriteLine("CheckDigit = {0}", checkDigit);
        return final;
    }

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
        if (userValue.ToString().Length == 11)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void Main()
    {
        Console.WriteLine("Hello!!");
        Console.WriteLine("Enter your UPC Code");
        string userValue;
        userValue = Console.ReadLine();
        int strLen = userValue.ToString().Length;
        Program p = new Program();
        bool isChar = p.IsAllDigits(userValue);

        while (!isChar)
        {
            Console.WriteLine("Invalid UPC Code! Entered code contains non numeric values");
            userValue = Console.ReadLine();
            isChar = p.IsAllDigits(userValue);
            if (isChar == true)
            {
                break;
            }
        }

        Program p2 = new Program();
        bool length = p2.ValidateLength(userValue);
        isChar = p.IsAllDigits(userValue);

        while (!length)
        {
            Console.WriteLine("Invalid UPC Code! Length is not 11");
            userValue = Console.ReadLine();
            length = p2.ValidateLength(userValue);
            isChar = p.IsAllDigits(userValue);

            if (!isChar)
            {
                Console.WriteLine("Invalid UPC Code!  Entered code contains non numeric values");
            }

            if (length == true && isChar == true)
            {
                break;
            }
        }
        string result = p.calculate_check_digit(userValue);
        Console.WriteLine("UPC_A Code with Check is {0}", result);

        if (result.ToString().Length == 12)
        { 
        Console.WriteLine("UPC_A Code Validates {0}", result);
        }

        else
        {
            Console.WriteLine("UPC_A Code generated is invalid {0}- Please enter correct data again", result);
        }
    }

}
