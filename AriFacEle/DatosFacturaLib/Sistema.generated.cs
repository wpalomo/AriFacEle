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
	public partial class Sistema
	{
		private int sistemaId;
		public virtual int SistemaId
		{
			get
			{
				return this.sistemaId;
			}
			set
			{
				this.sistemaId = value;
			}
		}
		
		private string nombre;
		public virtual string Nombre
		{
			get
			{
				return this.nombre;
			}
			set
			{
				this.nombre = value;
			}
		}
		
		private string baseDatos;
		public virtual string BaseDatos
		{
			get
			{
				return this.baseDatos;
			}
			set
			{
				this.baseDatos = value;
			}
		}
		
		private string descripcion;
		public virtual string Descripcion
		{
			get
			{
				return this.descripcion;
			}
			set
			{
				this.descripcion = value;
			}
		}
		
		private IList<Factura> facturas = new List<Factura>();
		public virtual IList<Factura> Facturas
		{
			get
			{
				return this.facturas;
			}
		}
		
	}
}
#pragma warning restore 1591