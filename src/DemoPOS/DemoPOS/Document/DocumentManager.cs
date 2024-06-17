using DemoPOS.Utilities;
using ESCPOS;
using ESCPOS.Utils;
using RawPrint;
using static ESCPOS.Commands;

namespace DemoPOS.Document;

public class DocumentManager
{
	private byte[] _commands = Array.Empty<byte>();
	private readonly string _printerName;

	private readonly Printer _printer = new();
	
	public DocumentManager(string printerName)
	{
		_printerName = printerName;
		PageSetup();
	}

	public DocumentManager AddTitle(string title, 
				Justification justification = Justification.Center,
				CharSizeWidth width = CharSizeWidth.Double,
				CharSizeHeight height = CharSizeHeight.Double
				)
	{
		Append(SelectJustification(justification));
		Append(SelectCharSize(width, height));
		Append(title.GetBytes());
		ResetFontAndJustification();
		Append(LF);

		return this;
	}

	public DocumentManager AddLine(string lineText, 
		Justification justification = Justification.Left)
	{
		Append(lineText.GetBytes());
		Append(LF);
		ResetJustification();
		return this;
	}

	public DocumentManager AddEmptyLine()
	{
		Append(LF);
		return this;
	}

	public DocumentManager AddEmptyLines(int count = 1)
	{
		for (var i = 0; i < count; i++)
			Append(LF);

		return this;
	}

	public DocumentManager AddQrCode(
		string content, 
		QRCodeModel model = QRCodeModel.Model2, 
		QRCodeSize size = QRCodeSize.Normal)
	{
		Append(SelectJustification(Justification.Center));
		Append(QRCode(content, model, qrCodeSize: size));
		Append(LF);

		return this;
	}

	public DocumentManager Cut()
	{
		Append(LF, 5);
		Append(FullPaperCut);
		return this;
	}

	public DocumentManager PrintAndContinue()
	{
		_commands.Print(_printerName);
		return this;
	}

	public void Print()
	{
		var stream = new MemoryStream();
		stream.Write(_commands);
		_printer.PrintRawStream(_printerName, stream, "esc/output", false);	
		
		_commands = Array.Empty<byte>();
	}

	private void ResetFontAndJustification()
	{
		ResetFont();
		ResetJustification();
	}

	private void ResetFont()
	{
		Append(SelectCharSize(CharSizeWidth.Normal, CharSizeHeight.Normal));
	}

	private void ResetJustification()
	{
		Append(SelectJustification(Justification.Left));
	}

	private void PageSetup()
	{
		Append(SelectCodeTable(CodeTable.Windows1252));
	}

	private void Append(byte[] command, int count = 1)
	{
		for (var i = 0; i < count; i++)
		{
			_commands = _commands.Add(command);
		}
	}

	public void Drawer()
	{
		Append(OpenDrawer);
		Print();
	}
}