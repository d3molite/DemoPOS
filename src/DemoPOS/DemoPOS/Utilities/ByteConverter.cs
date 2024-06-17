namespace DemoPOS.Utilities;

public static class ByteConverter
{
	private static readonly Dictionary<char, byte> LookupTable = new()
	{
		{
			'{', 0x7b
		},
		{
			'|', 0x7c
		},
		{
			'}', 0x7d
		},
		{
			'~', 0x7e
		},
		{
			'¡', 0xa1
		},
		{
			'¢', 0xa2
		},
		{
			'£', 0xa3
		},
		{
			'¤', 0xa4
		},
		{
			'¥', 0xa5
		},
		{
			'¦', 0xa6
		},
		{
			'§', 0xa7
		},
		{
			'¨', 0xa8
		},
		{
			'©', 0xa9
		},
		{
			'ª', 0xaa
		},
		{
			'«', 0xab
		},
		{
			'¬', 0xac
		},
		{
			'­', 0xad
		},
		{
			'®', 0xae
		},
		{
			'¯', 0xaf
		},
		{
			'°', 0xb0
		},
		{
			'±', 0xb1
		},
		{
			'²', 0xb2
		},
		{
			'³', 0xb3
		},
		{
			'´', 0xb4
		},
		{
			'µ', 0xb5
		},
		{
			'¶', 0xb6
		},
		{
			'·', 0xb7
		},
		{
			'¸', 0xb8
		},
		{
			'¹', 0xb9
		},
		{
			'º', 0xba
		},
		{
			'»', 0xbb
		},
		{
			'¼', 0xbc
		},
		{
			'½', 0xbd
		},
		{
			'¾', 0xbe
		},
		{
			'¿', 0xbf
		},
		{
			'À', 0xc0
		},
		{
			'Á', 0xc1
		},
		{
			'Â', 0xc2
		},
		{
			'Ã', 0xc3
		},
		{
			'Ä', 0xc4
		},
		{
			'Å', 0xc5
		},
		{
			'Æ', 0xc6
		},
		{
			'Ç', 0xc7
		},
		{
			'È', 0xc8
		},
		{
			'É', 0xc9
		},
		{
			'Ê', 0xca
		},
		{
			'Ë', 0xcb
		},
		{
			'Ì', 0xcc
		},
		{
			'Í', 0xcd
		},
		{
			'Î', 0xce
		},
		{
			'Ï', 0xcf
		},
		{
			'Ð', 0xd0
		},
		{
			'Ñ', 0xd1
		},
		{
			'Ò', 0xd2
		},
		{
			'Ó', 0xd3
		},
		{
			'Ô', 0xd4
		},
		{
			'Õ', 0xd5
		},
		{
			'Ö', 0xd6
		},
		{
			'×', 0xd7
		},
		{
			'Ø', 0xd8
		},
		{
			'Ù', 0xd9
		},
		{
			'Ú', 0xda
		},
		{
			'Û', 0xdb
		},
		{
			'Ü', 0xdc
		},
		{
			'Ý', 0xdd
		},
		{
			'Þ', 0xde
		},
		{
			'ß', 0xdf
		},
		{
			'à', 0xe0
		},
		{
			'á', 0xe1
		},
		{
			'â', 0xe2
		},
		{
			'ã', 0xe3
		},
		{
			'ä', 0xe4
		},
		{
			'å', 0xe5
		},
		{
			'æ', 0xe6
		},
		{
			'ç', 0xe7
		},
		{
			'è', 0xe8
		},
		{
			'é', 0xe9
		},
		{
			'ê', 0xea
		},
		{
			'ë', 0xeb
		},
		{
			'ì', 0xec
		},
		{
			'í', 0xed
		},
		{
			'î', 0xee
		},
		{
			'ï', 0xef
		},
		{
			'ð', 0xf0
		},
		{
			'ñ', 0xf1
		},
		{
			'ò', 0xf2
		},
		{
			'ó', 0xf3
		},
		{
			'ô', 0xf4
		},
		{
			'õ', 0xf5
		},
		{
			'ö', 0xf6
		},
		{
			'÷', 0xf7
		},
		{
			'ø', 0xf8
		},
		{
			'ù', 0xf9
		},
		{
			'ú', 0xfa
		},
		{
			'û', 0xfb
		},
		{
			'ü', 0xfc
		},
		{
			'ý', 0xfd
		},
		{
			'þ', 0xfe
		},
		{
			'ÿ', 0xff
		},
		{
			'Œ', 0x8c
		},
		{
			'œ', 0x9c
		},
		{
			'Š', 0x8a
		},
		{
			'š', 0x9a
		},
		{
			'Ÿ', 0x9f
		},
		{
			'Ž', 0x8e
		},
		{
			'ž', 0x9e
		},
		{
			'ƒ', 0x83
		},
		{
			'ˆ', 0x88
		},
		{
			'˜', 0x98
		},
		{
			'–', 0x96
		},
		{
			'—', 0x97
		},
		{
			'‘', 0x91
		},
		{
			'’', 0x92
		},
		{
			'‚', 0x82
		},
		{
			'“', 0x93
		},
		{
			'”', 0x94
		},
		{
			'„', 0x84
		},
		{
			'†', 0x86
		},
		{
			'‡', 0x87
		},
		{
			'•', 0x95
		},
		{
			'…', 0x85
		},
		{
			'‰', 0x89
		},
		{
			'‹', 0x8b
		},
		{
			'›', 0x9b
		},
		{
			'€', 0x80
		},
		{
			'™', 0x99
		}
	};

	public static byte[] GetBytes(this string input)
	{
		var bytes = new List<byte>();

		var characters = input.ToArray();

		foreach (var character in characters)
		{
			if (LookupTable.TryGetValue(character, out var byteCode))
			{
				bytes.Add(byteCode);
				continue;
			}

			bytes.Add((byte)character);
		}

		return bytes.ToArray();
	}
}