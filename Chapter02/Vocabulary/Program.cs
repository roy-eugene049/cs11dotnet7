using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;

//This program uses a technique called reflection

// declare some unused variables using types
// in additional assemblies
System.Data.DataSet ds;
HttpClient client;


// By declaring variables that use types in other assemblies, those assemblies are loaded with
// our application, which allows our code to see all the types and methods in them.

Assembly? myApp = Assembly.GetExecutingAssembly();

if (myApp == null) return;

    //Loop through the assemblies that my app references
foreach (AssemblyName name in myApp.GetReferencedAssemblies())
{
    //Load the assembly so we can read its details
  Assembly a = Assembly.Load(name);

    //Declare a variable to count the number of methods
  int methodCount = 0;

    //Loop through all the types in the assembly
  foreach (TypeInfo t in a.DefinedTypes)
    {
        // add up the counts of methods
        methodCount += t.GetMethods().Count();
    }
}

//Working with Variables

//To output emoji at the command line on Windows,
//you must use Windows Terminal because Command Prompt does not support emoji,
//and set the output encoding to use UTF-8

Console.OutputEncoding = System.Text.Encoding.UTF8;
string grinningEmoji = char.ConvertFromUtf32(0x1F600);
Console.WriteLine(grinningEmoji);

//Verbatim Strings
//When storing text in a string variable, you can include escape sequences, 
//which represent special characters like tabs and new lines using a backslash

string fullNameWithTabSeparator = "Bob\tSmith";


//But what if you are storing the path to a file on Windows, and one of the folder names starts with a T,
//as shown in the following code ?

string filePath = "C:\televisions\sony\bravia.txt";

//The compiler will convert the \t into a tab character and you will get errors!
//You must prefix with the @ symbol to use a verbatim literal string, as shown in the following code:

string filePath = @"C:\televisions\sony\bravia.txt";


//Raw string literals
//Introduced in C# 11, raw string literals are convenient for entering any arbitrary text without needing to escape the contents.
//They make it easy to define literals containing other languages like XML, HTML, or JSON.
//Raw string literals start and end with three or more double-quote characters, as shown in the following code:

string xml = """
                 <person age="50">
                  <first_name>Mark</first_name>
                 </person>
                 """;

//Raw interpolated string literals
//You can mix interpolated strings that use curly braces { } with raw string literals. You specify the
//number of braces that indicate a replaced expression by adding that number of dollar signs to the
//start of the literal.Any fewer braces than that are treated as raw content.

//For example, if we want to define some JSON, single braces will be treated as normal braces, but the
//two dollar symbols tell the compiler that any two curly braces indicate a replaced expression value,
//as shown in the following code:

var person = new { FirstName = "Alice", Age = 56 };
string json = $$"""
                  {
                    "first_name": "{{person.FirstName}}",
                    "age": {{person.Age}},
                    "calculation", "{{{1 + 2}}}"
                  }
                  """;

Console.WriteLine(json);

//output the count of types and their methods
Console.WriteLine(
  "{0:N0} types with {1:N0} methods in {2} assembly.",
    arg0: a.DefinedTypes.Count(),
    arg1: methodCount,
    arg2: name.Name);