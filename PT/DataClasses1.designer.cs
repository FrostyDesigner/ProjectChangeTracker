﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PT
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ProjectChangeTracker")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertProjectChange(ProjectChange instance);
    partial void UpdateProjectChange(ProjectChange instance);
    partial void DeleteProjectChange(ProjectChange instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::PT.Properties.Settings.Default.ProjectChangeTrackerConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<ProjectChange> ProjectChanges
		{
			get
			{
				return this.GetTable<ProjectChange>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ProjectChange")]
	public partial class ProjectChange : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Id;
		
		private string _ProjectNumber;
		
		private string _ProjectName;
		
		private string _SubProject;
		
		private System.Nullable<System.DateTime> _ProjectDate;
		
		private string _Drafter;
		
		private string _InitiatedBy;
		
		private string _ChangeType;
		
		private string _ChangeDescription;
		
		private string _NewVersion;
		
		private string _OldVersion;
		
		private string _Comments;
		
		private string _CadFile;
		
		private string _Archive;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(string value);
    partial void OnIdChanged();
    partial void OnProjectNumberChanging(string value);
    partial void OnProjectNumberChanged();
    partial void OnProjectNameChanging(string value);
    partial void OnProjectNameChanged();
    partial void OnSubProjectChanging(string value);
    partial void OnSubProjectChanged();
    partial void OnProjectDateChanging(System.Nullable<System.DateTime> value);
    partial void OnProjectDateChanged();
    partial void OnDrafterChanging(string value);
    partial void OnDrafterChanged();
    partial void OnInitiatedByChanging(string value);
    partial void OnInitiatedByChanged();
    partial void OnChangeTypeChanging(string value);
    partial void OnChangeTypeChanged();
    partial void OnChangeDescriptionChanging(string value);
    partial void OnChangeDescriptionChanged();
    partial void OnNewVersionChanging(string value);
    partial void OnNewVersionChanged();
    partial void OnOldVersionChanging(string value);
    partial void OnOldVersionChanged();
    partial void OnCommentsChanging(string value);
    partial void OnCommentsChanged();
    partial void OnCadFileChanging(string value);
    partial void OnCadFileChanged();
    partial void OnArchiveChanging(string value);
    partial void OnArchiveChanged();
    #endregion
		
		public ProjectChange()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="NVarChar(100) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProjectNumber", DbType="NVarChar(50)")]
		public string ProjectNumber
		{
			get
			{
				return this._ProjectNumber;
			}
			set
			{
				if ((this._ProjectNumber != value))
				{
					this.OnProjectNumberChanging(value);
					this.SendPropertyChanging();
					this._ProjectNumber = value;
					this.SendPropertyChanged("ProjectNumber");
					this.OnProjectNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProjectName", DbType="NVarChar(100)")]
		public string ProjectName
		{
			get
			{
				return this._ProjectName;
			}
			set
			{
				if ((this._ProjectName != value))
				{
					this.OnProjectNameChanging(value);
					this.SendPropertyChanging();
					this._ProjectName = value;
					this.SendPropertyChanged("ProjectName");
					this.OnProjectNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubProject", DbType="NVarChar(100)")]
		public string SubProject
		{
			get
			{
				return this._SubProject;
			}
			set
			{
				if ((this._SubProject != value))
				{
					this.OnSubProjectChanging(value);
					this.SendPropertyChanging();
					this._SubProject = value;
					this.SendPropertyChanged("SubProject");
					this.OnSubProjectChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProjectDate", DbType="Date")]
		public System.Nullable<System.DateTime> ProjectDate
		{
			get
			{
				return this._ProjectDate;
			}
			set
			{
				if ((this._ProjectDate != value))
				{
					this.OnProjectDateChanging(value);
					this.SendPropertyChanging();
					this._ProjectDate = value;
					this.SendPropertyChanged("ProjectDate");
					this.OnProjectDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Drafter", DbType="NVarChar(100)")]
		public string Drafter
		{
			get
			{
				return this._Drafter;
			}
			set
			{
				if ((this._Drafter != value))
				{
					this.OnDrafterChanging(value);
					this.SendPropertyChanging();
					this._Drafter = value;
					this.SendPropertyChanged("Drafter");
					this.OnDrafterChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InitiatedBy", DbType="NVarChar(100)")]
		public string InitiatedBy
		{
			get
			{
				return this._InitiatedBy;
			}
			set
			{
				if ((this._InitiatedBy != value))
				{
					this.OnInitiatedByChanging(value);
					this.SendPropertyChanging();
					this._InitiatedBy = value;
					this.SendPropertyChanged("InitiatedBy");
					this.OnInitiatedByChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChangeType", DbType="NVarChar(100)")]
		public string ChangeType
		{
			get
			{
				return this._ChangeType;
			}
			set
			{
				if ((this._ChangeType != value))
				{
					this.OnChangeTypeChanging(value);
					this.SendPropertyChanging();
					this._ChangeType = value;
					this.SendPropertyChanged("ChangeType");
					this.OnChangeTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChangeDescription", DbType="NVarChar(500)")]
		public string ChangeDescription
		{
			get
			{
				return this._ChangeDescription;
			}
			set
			{
				if ((this._ChangeDescription != value))
				{
					this.OnChangeDescriptionChanging(value);
					this.SendPropertyChanging();
					this._ChangeDescription = value;
					this.SendPropertyChanged("ChangeDescription");
					this.OnChangeDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NewVersion", DbType="NVarChar(10)")]
		public string NewVersion
		{
			get
			{
				return this._NewVersion;
			}
			set
			{
				if ((this._NewVersion != value))
				{
					this.OnNewVersionChanging(value);
					this.SendPropertyChanging();
					this._NewVersion = value;
					this.SendPropertyChanged("NewVersion");
					this.OnNewVersionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OldVersion", DbType="NVarChar(10)")]
		public string OldVersion
		{
			get
			{
				return this._OldVersion;
			}
			set
			{
				if ((this._OldVersion != value))
				{
					this.OnOldVersionChanging(value);
					this.SendPropertyChanging();
					this._OldVersion = value;
					this.SendPropertyChanged("OldVersion");
					this.OnOldVersionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Comments", DbType="NVarChar(500)")]
		public string Comments
		{
			get
			{
				return this._Comments;
			}
			set
			{
				if ((this._Comments != value))
				{
					this.OnCommentsChanging(value);
					this.SendPropertyChanging();
					this._Comments = value;
					this.SendPropertyChanged("Comments");
					this.OnCommentsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CadFile", DbType="NVarChar(500)")]
		public string CadFile
		{
			get
			{
				return this._CadFile;
			}
			set
			{
				if ((this._CadFile != value))
				{
					this.OnCadFileChanging(value);
					this.SendPropertyChanging();
					this._CadFile = value;
					this.SendPropertyChanged("CadFile");
					this.OnCadFileChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Archive", DbType="NVarChar(500)")]
		public string Archive
		{
			get
			{
				return this._Archive;
			}
			set
			{
				if ((this._Archive != value))
				{
					this.OnArchiveChanging(value);
					this.SendPropertyChanging();
					this._Archive = value;
					this.SendPropertyChanged("Archive");
					this.OnArchiveChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
