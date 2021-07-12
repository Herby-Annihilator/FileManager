using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileManager.Models.Services.FileRules
{
	public class ChangeNameRule : FileRule
	{
		private string _fileName;
		public ChangeNameRule(FileRule rule, string fileName = null)
		{
			this.rule = rule;
			_fileName = fileName;
		}
		public override string Apply(string param)
		{
			string result = rule.Apply(param);
			Dictionary<string, string> table = GetTranslationTable();
			string res = "";
			for (int i = 0; i < result.Length; i++)
			{
				res += table[result[i].ToString()];
			}
			return res;
		}

		/// <summary>
		/// Возвращает транслирующую таблицу. Формат файла:
		/// 'ключ=значение' в столбец без кавычек
		/// </summary>
		/// <returns></returns>
		private Dictionary<string, string> GetTranslationTable()
		{
			if (_fileName == null)
			{
				return GetDefaultTable();
			}
			else
			{
				Dictionary<string, string> result = new Dictionary<string, string>();
				StreamReader reader = new StreamReader(_fileName);
				string[] reports = reader.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
				string[] keyValue;
				try
				{
					for (int i = 0; i < reports.Length; i++)
					{
						keyValue = reports[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
						result.Add(keyValue[0], keyValue[1]);
					}
				}
				catch(Exception)
				{
					reader.Close();
					throw new InvalidDataException($"Неверный формат данных в файле {_fileName}");
				}				
				reader.Close();
				return result;
			}
		}

		private Dictionary<string, string> GetDefaultTable()
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
