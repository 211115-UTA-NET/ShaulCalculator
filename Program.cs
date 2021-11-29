// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
Console.WriteLine("Calculator");
Console.WriteLine("----------");

Console.WriteLine("enter expretion to calculate,press enter for the result,type 'exit' to exit Calculator");

Queue<string> myQ = new Queue<string>();
Stack<string> my_stack = new Stack<string>();
string lastElemnet="";
string InputString="";
float result=0;
float LastNumber=0;
Dictionary<string, string> WordList =
        new Dictionary<string, string>();
        WordList.Add("plus", "+");
        WordList.Add("minus", "-");
        WordList.Add("multiply", "*");
        WordList.Add("divide", "/");
        WordList.Add("one", "1");
        WordList.Add("two", "2");
        WordList.Add("three", "3");
        WordList.Add("four", "4");
        WordList.Add("five", "5");
        WordList.Add("six", "6");
        WordList.Add("seven", "7");
        WordList.Add("eight", "8");
        WordList.Add("nine", "9");
        WordList.Add("ten", "10");
do
{
 InputString=Console.ReadLine();
if (InputString!="exit")
{
    lastElemnet="";
    InputString=InputString.ToLower();
    foreach(var item in WordList)
    {
    InputString=InputString.Replace(item.Key,item.Value);
    }
    for (int i = 0; i < InputString.Length; i++) 
    { 
        if (InputString[i] =='*' || InputString[i] =='/' || InputString[i] =='+' || InputString[i] =='-' )
        {
            myQ.Enqueue(lastElemnet.Trim());
            myQ.Enqueue(InputString[i].ToString());
            lastElemnet="";
        }
        else
        lastElemnet=lastElemnet+InputString[i];
    }
    myQ.Enqueue(lastElemnet.Trim());
    String[] arr = myQ.ToArray();
        myQ.Clear();
        my_stack.Push(arr[0]);
    for(int i=1;i<arr.Length-1;i=i+2)
            {
                if (arr[i]=="*" || arr[i]=="/")
                {
                    if (arr[i]=="*")
                        my_stack.Push((float.Parse(my_stack.Pop()) * float.Parse(arr[i+1])).ToString());
                    else 
                        my_stack.Push((float.Parse(my_stack.Pop()) / float.Parse(arr[i+1])).ToString());
                }
                else
                {
                    my_stack.Push(arr[i]);
                    my_stack.Push(arr[i+1]);
                }
            }

        while (my_stack.Count > 0)
        {
            lastElemnet=my_stack.Pop();
            LastNumber = float.Parse(lastElemnet);
            if (my_stack.Count > 0)
            {
                if (my_stack.Pop()=="-")
                    result=result-LastNumber;
                else
                    result=result+LastNumber;
                }
            else
                result=result+LastNumber;
        }
        Console.WriteLine("The Result is : " + result); 
        result=0;
    }
}
while (InputString!="exit");


