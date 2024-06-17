using Microsoft.Win32;

namespace DemoPOS.Helpers;

public static class RegistryHelper
{
	public static IEnumerable<string> GetInstalledPrinterNames() 
		=> Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Print\Printers", false)!.GetSubKeyNames();
}