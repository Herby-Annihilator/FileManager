using FileManager.Infrastructure.Commands;
using FileManager.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows.Markup;
using FileManager.Models.Services.Dialogs;
using FileManager.Models.Services.Interfaces;
using System.Collections.ObjectModel;
using FileManager.Models.Data;
using System.IO;

namespace FileManager.ViewModels
{
	[MarkupExtensionReturnType(typeof(MainWindowViewModel))]
	public class MainWindowViewModel : ViewModel
	{
		public MainWindowViewModel()
		{
			ChooseFolderCommand = new LambdaCommand(OnChooseFolderCommandExecuted, CanChooseFolderCommandExecute);
			LoadDataCommand = new LambdaCommand(OnLoadDataCommandExecuted, CanLoadDataCommandExecute);
			ClearTableCommand = new LambdaCommand(OnClearTableCommandExecuted, CanClearTableCommandExecute);
		}
		#region Properties
		private string _title = "Title";
		public string Title { get => _title; set => Set(ref _title, value); }

		private string _status = "Status";
		public string Status { get => _status; set => Set(ref _status, value); }

		private string _selectedFolder = "";
		public string SelectedFolder { get => _selectedFolder; set => Set(ref _selectedFolder, value); }

		public ObservableCollection<FileNames> FilesTable { get; private set; } = new ObservableCollection<FileNames>();
		private FileNames _selectedFile;
		public FileNames SelectedFile
		{
			get => _selectedFile;
			set
			{
				Set(ref _selectedFile, value);
				if (_selectedFile == null)
				{
					ClearAttributes();
				}
				else
				{
					SetAttributes();
				}				
			}
		}

		#region FileAttributesCheckboxes
		private bool _archived = false;
		public bool Archived 
		{ 
			get => _archived;
			set
			{
				Set(ref _archived, value);
			}
		}

		private bool _system = false;
		public bool System { get => _system; set => Set(ref _system, value); }

		private bool _hidden = false;
		public bool Hidden { get => _hidden; set => Set(ref _hidden, value); }

		private bool _normal = false;
		public bool Normal { get => _normal; set => Set(ref _normal, value); }

		private bool _temporary = false;
		public bool Temporary { get => _temporary; set => Set(ref _temporary, value); }

		private bool _compressed = false;
		public bool Compressed { get => _compressed; set => Set(ref _compressed, value); }

		private bool _encrypted = false;
		public bool Encrypted { get => _encrypted; set => Set(ref _encrypted, value); }

		private bool _readOnly = false;
		public bool ReadOnly { get => _readOnly; set => Set(ref _readOnly, value); }

		private bool _integrityStream = false;
		public bool IntegrityStream { get => _integrityStream; set => Set(ref _integrityStream, value); }

		private bool _noScrubData = false;
		public bool NoScrubData { get => _noScrubData; set => Set(ref _noScrubData, value); }

		private bool _offline = false;
		public bool Offline { get => _offline; set => Set(ref _offline, value); }

		private bool _sparseFile = false;
		public bool SparseFile { get => _sparseFile; set => Set(ref _sparseFile, value); }
		#endregion
		#endregion

		#region Commands

		#region ChooseFolderCommand
		public ICommand ChooseFolderCommand { get; }
		private void OnChooseFolderCommandExecuted(object p)
		{
			IDialog dialog = new FolderBrowserDialog();
			if (dialog.ShowDialog() == true)
			{
				SelectedFolder = dialog.SelectedPath;
			}
		}
		private bool CanChooseFolderCommandExecute(object p) => true;
		#endregion

		#region LoadDataCommand
		public ICommand LoadDataCommand { get; }
		private void OnLoadDataCommandExecuted(object p)
		{
			if (string.IsNullOrWhiteSpace(SelectedFolder))
			{
				FileBrowserDialog dialog = new FileBrowserDialog();
				if (dialog.ShowDialog() == true)
				{
					FilesTable.Clear();
					for (int i = 0; i < dialog.SelectedFiles.Length; i++)
					{
						FilesTable.Add(new FileNames(dialog.SelectedFiles[i], dialog.SelectedPath));
					}
				}
			}
			else
			{
				if (Directory.Exists(SelectedFolder))
				{
					string[] files = Directory.GetFiles(SelectedFolder);
					FilesTable.Clear();
					if (files != null)
					{
						string path = files[0].Substring(0, files[0].LastIndexOf("\\") + 1);
						for (int i = 0; i < files.Length; i++)
						{
							FilesTable.Add(new FileNames(files[i].Substring(files[i].LastIndexOf("\\") + 1), path));
						}
					}
				}
				else
				{
					Status = "Директория не существует";
				}
			}
		}
		private bool CanLoadDataCommandExecute(object p) => true;
		#endregion

		#region ClearTableCommand
		public ICommand ClearTableCommand { get; }
		private void OnClearTableCommandExecuted(object p)
		{
			FilesTable.Clear();
		}
		private bool CanClearTableCommandExecute(object p) => FilesTable.Count > 0;
		#endregion
		#endregion

		private void SetAttributes()
		{
			string path = GetFullName(SelectedFile);
			if (path != null)
			{
				Archived = (File.GetAttributes(path) & FileAttributes.Archive) == FileAttributes.Archive;
				System = (File.GetAttributes(path) & FileAttributes.System) == FileAttributes.System;
				Hidden = (File.GetAttributes(path) & FileAttributes.Hidden) == FileAttributes.Hidden;
				Compressed = (File.GetAttributes(path) & FileAttributes.Compressed) == FileAttributes.Compressed;
				Normal = (File.GetAttributes(path) & FileAttributes.Normal) == FileAttributes.Normal;
				Temporary = (File.GetAttributes(path) & FileAttributes.Temporary) == FileAttributes.Temporary;
				ReadOnly = (File.GetAttributes(path) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly;
				Encrypted = (File.GetAttributes(path) & FileAttributes.Encrypted) == FileAttributes.Encrypted;
				IntegrityStream = (File.GetAttributes(path) & FileAttributes.IntegrityStream) == FileAttributes.IntegrityStream;
				NoScrubData = (File.GetAttributes(path) & FileAttributes.NoScrubData) == FileAttributes.NoScrubData;
				Offline = (File.GetAttributes(path) & FileAttributes.Offline) == FileAttributes.Offline;
				SparseFile = (File.GetAttributes(path) & FileAttributes.SparseFile) == FileAttributes.SparseFile;
			}
		}

		private string GetFullName(FileNames file)
		{
			if (file != null)
				return file.Location + file.Name;
			return null;
		}

		private void ClearAttributes()
		{
			Archived = false;
			System = false;
			Hidden = false;
			Compressed = false;
			Normal = false;
			Temporary = false;
			ReadOnly = false;
			Encrypted = false;
			IntegrityStream = false;
			NoScrubData = false;
			Offline = false;
			SparseFile = false;
		}
	}
}
