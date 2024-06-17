// See https://aka.ms/new-console-template for more information

using DemoPOS.Document;
using DemoPOS.Helpers;


var printer = RegistryHelper.GetInstalledPrinterNames()[1];

var manager = new DocumentManager(printer);

manager.AddTitle("Hello World")
		.AddLine("This is a test print")
		.AddLine("On a thermal printer.")
		.AddQrCode("http://www.example.com")
		.AddEmptyLines(5)
		.Cut();

manager.Print();