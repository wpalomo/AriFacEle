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
using AriGasolModel;

namespace AriGasolModel	
{
	public partial class Schfac
	{
		private string _letraser;
		public virtual string Letraser
		{
			get
			{
				return this._letraser;
			}
			set
			{
				this._letraser = value;
			}
		}
		
		private int _numfactu;
		public virtual int Numfactu
		{
			get
			{
				return this._numfactu;
			}
			set
			{
				this._numfactu = value;
			}
		}
		
		private DateTime _fecfactu;
		public virtual DateTime Fecfactu
		{
			get
			{
				return this._fecfactu;
			}
			set
			{
				this._fecfactu = value;
			}
		}
		
		private int _codsocio;
		public virtual int Codsocio
		{
			get
			{
				return this._codsocio;
			}
			set
			{
				this._codsocio = value;
			}
		}
		
		private short _codcoope;
		public virtual short Codcoope
		{
			get
			{
				return this._codcoope;
			}
			set
			{
				this._codcoope = value;
			}
		}
		
		private short _codforpa;
		public virtual short Codforpa
		{
			get
			{
				return this._codforpa;
			}
			set
			{
				this._codforpa = value;
			}
		}
		
		private decimal _baseimp1;
		public virtual decimal Baseimp1
		{
			get
			{
				return this._baseimp1;
			}
			set
			{
				this._baseimp1 = value;
			}
		}
		
		private decimal? _baseimp2;
		public virtual decimal? Baseimp2
		{
			get
			{
				return this._baseimp2;
			}
			set
			{
				this._baseimp2 = value;
			}
		}
		
		private decimal? _baseimp3;
		public virtual decimal? Baseimp3
		{
			get
			{
				return this._baseimp3;
			}
			set
			{
				this._baseimp3 = value;
			}
		}
		
		private decimal _impoiva1;
		public virtual decimal Impoiva1
		{
			get
			{
				return this._impoiva1;
			}
			set
			{
				this._impoiva1 = value;
			}
		}
		
		private decimal? _impoiva2;
		public virtual decimal? Impoiva2
		{
			get
			{
				return this._impoiva2;
			}
			set
			{
				this._impoiva2 = value;
			}
		}
		
		private decimal? _impoiva3;
		public virtual decimal? Impoiva3
		{
			get
			{
				return this._impoiva3;
			}
			set
			{
				this._impoiva3 = value;
			}
		}
		
		private short _tipoiva1;
		public virtual short Tipoiva1
		{
			get
			{
				return this._tipoiva1;
			}
			set
			{
				this._tipoiva1 = value;
			}
		}
		
		private short? _tipoiva2;
		public virtual short? Tipoiva2
		{
			get
			{
				return this._tipoiva2;
			}
			set
			{
				this._tipoiva2 = value;
			}
		}
		
		private short? _tipoiva3;
		public virtual short? Tipoiva3
		{
			get
			{
				return this._tipoiva3;
			}
			set
			{
				this._tipoiva3 = value;
			}
		}
		
		private decimal _porciva1;
		public virtual decimal Porciva1
		{
			get
			{
				return this._porciva1;
			}
			set
			{
				this._porciva1 = value;
			}
		}
		
		private decimal? _porciva2;
		public virtual decimal? Porciva2
		{
			get
			{
				return this._porciva2;
			}
			set
			{
				this._porciva2 = value;
			}
		}
		
		private decimal? _porciva3;
		public virtual decimal? Porciva3
		{
			get
			{
				return this._porciva3;
			}
			set
			{
				this._porciva3 = value;
			}
		}
		
		private decimal _totalfac;
		public virtual decimal Totalfac
		{
			get
			{
				return this._totalfac;
			}
			set
			{
				this._totalfac = value;
			}
		}
		
		private decimal _impuesto;
		public virtual decimal Impuesto
		{
			get
			{
				return this._impuesto;
			}
			set
			{
				this._impuesto = value;
			}
		}
		
		private short _intconta;
		public virtual short Intconta
		{
			get
			{
				return this._intconta;
			}
			set
			{
				this._intconta = value;
			}
		}
		
		private string _observac;
		public virtual string Observac
		{
			get
			{
				return this._observac;
			}
			set
			{
				this._observac = value;
			}
		}
		
		private decimal? _impuesigaus;
		public virtual decimal? Impuesigaus
		{
			get
			{
				return this._impuesigaus;
			}
			set
			{
				this._impuesigaus = value;
			}
		}
		
		private Ssocio _ssocio;
		public virtual Ssocio Ssocio
		{
			get
			{
				return this._ssocio;
			}
			set
			{
				this._ssocio = value;
			}
		}
		
		private IList<Slhfac> _slhfacs = new List<Slhfac>();
		public virtual IList<Slhfac> Slhfacs
		{
			get
			{
				return this._slhfacs;
			}
		}
		
	}
}
#pragma warning restore 1591