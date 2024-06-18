# DemoPOS
DemoPOS is a simple and lightweight fluent wrapper around RawPrint and ESCPOS to allow for 
simple and direct printing to a thermal printer installed on a windows machine 
(Such as an Epson TM-T88IV for example).

The usage is quite straightforward: 

To get a list of names of installed printers on the machine, use the RegistryHelper class:

```csharp
var printers = RegistryHelper.GetInstalledPrinterNames();
```

Then, create a new DocumentManager with the desired ESC/POS Printer of your choice: 

```csharp
var manager = new DocumentManager(PrinterName);
```

You can then chain various commands via a fluent style api, such as: 

```csharp
manager.AddTitle("Hello World")
    .AddLine("This is a test print")
    .AddLine("On a thermal printer.")
    .AddQrCode("http://www.example.com")
    .AddEmptyLines(5)
    .Cut();
```

To send the commands to the printer, either use the print command (this will clear the command buffer)

```csharp
manager.Print();
```

or use the PrintAndContinue command, to keep the buffer (for repetitive printing of the same receipt, for example)
```csharp
manager.PrintAndContinue();
```

If you have any issues with this package, or would like more features (commands) added to the DocumentManager, feel free to open a feature or a pull request on this repository!


## Packages Used
- RawPrint
- ESCPOS
