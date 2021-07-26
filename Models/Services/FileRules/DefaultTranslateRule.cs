using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileManager.Models.Services.FileRules
{
	public class DefaultTranslateRule : FileRule
	{
		public override string Apply(string param)
		{
			Dictionary<string, string> table = GetTranslationTable();
			string res = "";
			for (int i = 0; i < param.Length; i++)
			{
				res += table[param[i].ToString()];
			}
			return res;
		}

		protected virtual Dictionary<string, string> GetTranslationTable() => GetDefaultTable();

		protected virtual Dictionary<string, string> GetDefaultTable()
		{
			Dictionary<string, string> result = new Dictionary<string, string>
			{
				{ "а", "a"},
				{ "б", "b"},
				{ "в", "v"},
				{ "г", "g"},
				{ "д", "d"},
				{ "е", "e"},
				{ "ж", "gh"},
				{ "з", "z"},
				{ "и", "i"},
				{ "й", "y"},
				{ "к", "k"},
				{ "л", "l"},
				{ "м", "m"},
				{ "н", "n"},
				{ "о", "o"},
				{ "п", "p"},
				{ "р", "r"},
				{ "с", "c"},
				{ "т", "t"},
				{ "у", "u"},
				{ "ф", "f"},
				{ "х", "h"},
				{ "ц", "c"},
				{ "ч", "ch"},
				{ "ш", "sh"},
				{ "щ", "sh"},
				{ "ъ", "_"},
				{ "ы", "i"},
				{ "ь", "_"},
				{ "э", "e"},
				{ "ю", "yu"},
				{ "я", "ya"},
				{ "А", "A"},
				{ "Б", "B"},
				{ "В", "V"},
				{ "Г", "G"},
				{ "Д", "D"},
				{ "Е", "E"},
				{ "Ж", "Gh"},
				{ "З", "Z"},
				{ "И", "I"},
				{ "Й", "Y"},
				{ "К", "K"},
				{ "Л", "L"},
				{ "М", "M"},
				{ "Н", "N"},
				{ "О", "O"},
				{ "П", "P"},
				{ "Р", "R"},
				{ "С", "C"},
				{ "Т", "T"},
				{ "У", "U"},
				{ "Ф", "F"},
				{ "Х", "H"},
				{ "Ц", "C"},
				{ "Ч", "Ch"},
				{ "Ш", "Sh"},
				{ "Щ", "Sh"},
				{ "Ъ", "_"},
				{ "Ы", "I"},
				{ "Ь", "_"},
				{ "Э", "E"},
				{ "Ю", "Yu"},
				{ "Я", "Ya"},
				{ "ё", "e"},
				{ "Ё", "E"},
			};
			return result;
		}
	}
}
