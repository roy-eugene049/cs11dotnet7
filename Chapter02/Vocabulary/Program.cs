using System.Reflection;

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


  //output the count of types and their methods
  Console.WriteLine(
      "{0:N0} types with {1:N0} methods in {2} assembly.",
        arg0: a.DefinedTypes.Count(),
        arg1: methodCount,
        arg2: name.Name);
}