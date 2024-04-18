using System;

class Program {
  public static void Main (string[] args) {
    PrintUserInfo();
  }

  static void PrintUserInfo()
  {
    User UserInfo = EnterUser();
    Console.WriteLine("Your name is {0} {1}. You are {2} years old.", UserInfo.Name, UserInfo.Surname, UserInfo.Age);
    if (UserInfo.Pets != null)
    {
      Console.WriteLine("Your pets' names: {0}", string.Join(", ", UserInfo.Pets));
    }
    else
    {
      Console.WriteLine("You have no pets");
    }
    Console.WriteLine("Your favourite colors are {0}", string.Join(", ", UserInfo.FavColours));
  }

  static User EnterUser()
  {
    User UserInfo = new User();

    Console.WriteLine("Enter your name:");
    UserInfo.Name = Console.ReadLine();

    Console.WriteLine("Enter your last name:");
    UserInfo.Surname = Console.ReadLine();

    UserInfo.Age = GetIntNum("your age (in numbers)");

    Console.WriteLine("Do you have pets? (y/n):");
    if (Console.ReadLine() == "y")
    {
      UserInfo.Pets = CreateArray(GetIntNum("number of your pets"));
    }
    else
    {
      Console.WriteLine("You don't have pets.");
    }

    UserInfo.FavColours = CreateArray(GetIntNum("number of your favourite colours"));

    return UserInfo;
  }

  static string[] CreateArray(int num)
  {
    string[] array = new string[num];
    for (int i = 0; i < num; i++)
    {
      Console.WriteLine("Enter name number {0}:", i + 1);
      array[i] = Console.ReadLine();
    }
    return array;
  }

  static int GetIntNum(string ObjName)
  {
    string StringNum;
    int IntNum;
    do
    {
      Console.WriteLine("Enter {0}:", ObjName);
      StringNum = Console.ReadLine();
    }
    while (!CheckNum(StringNum, out IntNum));
    return IntNum;
  }

  static bool CheckNum(string Num, out int CheckedNum)
  {
    if (int.TryParse(Num, out int IntNum))
    {
      if (IntNum > 0)
      {
        CheckedNum = IntNum;
        return true;
      }
      CheckedNum = 0;
      Console.WriteLine("Invalid input: number must be greater than 0. Please try again.");
      return false;
    }
    CheckedNum = 0;
    Console.WriteLine("Invalid input: not a number. Please try again.");
    return false;
  }
}

class User
{
  public string Name { get; set; }
  public string Surname { get; set; }
  public int Age { get; set; }
  public string[] Pets { get; set; }
  public string[] FavColours { get; set; }
}
