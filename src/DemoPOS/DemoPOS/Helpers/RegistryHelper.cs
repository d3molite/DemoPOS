using Microsoft.Win32;

namespace DemoPOS.Helpers;

public static class RegistryHelper
{
	public static string[] GetInstalledPrinterNames() 
		=> Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Print\Printers", false)!.GetSubKeyNames();
}