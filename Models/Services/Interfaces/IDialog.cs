using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.Models.Services.Interfaces
{
	public interface IDialog
	{
		bool ShowDialog();
		string ParentDirectory { get; set; }
		string SelectedPath { get; set; }
	}
}
