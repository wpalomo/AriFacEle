#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ClassGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;
using DatosFacturaLib;

namespace DatosFacturaLib	
{
	public partial class Superusuario
	{
		private int id;
		public virtual int Id
		{
			get
			{
				return this.id;
			}
			set
			{
				this.id = value;
			}
		}
		
		private string login;
		public virtual string Login
		{
			get
			{
				return this.login;
			}
			set
			{
				this.login = value;
			}
		}
		
		private string contraseña;
		public virtual string Contraseña
		{
			get
			{
				return this.contraseña;
			}
			set
			{
				this.contraseña = value;
			}
		}
		
		private string email;
		public virtual string Email
		{
			get
			{
				return this.email;
			}
			set
			{
				this.email = value;
			}
		}
		
		private int? idEmpresa;
		public virtual int? Id_empresa
		{
			get
			{
				return this.idEmpresa;
			}
			set
			{
				this.idEmpresa = value;
			}
		}
		
		private Empresa empresa;
		public virtual Empresa Empresa
		{
			get
			{
				return this.empresa;
			}
			set
			{
				this.empresa = value;
			}
		}
		
	}
}
#pragma warning restore 1591
