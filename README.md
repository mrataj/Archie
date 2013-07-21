Luna
====

Luna is Asp.NET MVC 4 template for a web project. It comes with jQuery 1.7.1, modernizr and knockout. Classes are documented to pass StyleCop and FxCop validation.

IMPORTANT!

1. To build this project, you have to enable "Allow NuGet to download missing packages during build" in Visual Studio. This setting lives under Options -> Package Manager -> General.
To enable package restore for build servers without Visual Studio installed, you can also set the environment variable EnableNuGetPackageRestore to "true"

ref: http://docs.nuget.org/docs/reference/..%5CWorkflows%5CUsing-NuGet-without-committing-packages

2. This project requires you have StyleCop installed on your machine. StyleCop analyzes C# source code to enforce a set of style and consistency rules. You can get StyleCop here: http://stylecop.codeplex.com/