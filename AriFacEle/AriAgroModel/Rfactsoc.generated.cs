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
using AriAgroModel;

namespace AriAgroModel	
{
	public partial class Rfactsoc
	{
		private string _codtipom;
		public virtual string Codtipom
		{
			get
			{
				return this._codtipom;
			}
			set
			{
				this._codtipom = value;
			}
		}
		
		private uint _numfactu;
		public virtual uint Numfactu
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
		
		private uint _codsocio;
		public virtual uint Codsocio
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
		
		private decimal _baseimpo;
		public virtual decimal Baseimpo
		{
			get
			{
				return this._baseimpo;
			}
			set
			{
				this._baseimpo = value;
			}
		}
		
		private short _tipoiva;
		public virtual short Tipoiva
		{
			get
			{
				return this._tipoiva;
			}
			set
			{
				this._tipoiva = value;
			}
		}
		
		private decimal _porc_iva;
		public virtual decimal Porc_iva
		{
			get
			{
				return this._porc_iva;
			}
			set
			{
				this._porc_iva = value;
			}
		}
		
		private decimal _imporiva;
		public virtual decimal Imporiva
		{
			get
			{
				return this._imporiva;
			}
			set
			{
				this._imporiva = value;
			}
		}
		
		private short _tipoirpf;
		public virtual short Tipoirpf
		{
			get
			{
				return this._tipoirpf;
			}
			set
			{
				this._tipoirpf = value;
			}
		}
		
		private decimal? _basereten;
		public virtual decimal? Basereten
		{
			get
			{
				return this._basereten;
			}
			set
			{
				this._basereten = value;
			}
		}
		
		private decimal? _porc_ret;
		public virtual decimal? Porc_ret
		{
			get
			{
				return this._porc_ret;
			}
			set
			{
				this._porc_ret = value;
			}
		}
		
		private decimal? _impreten;
		public virtual decimal? Impreten
		{
			get
			{
				return this._impreten;
			}
			set
			{
				this._impreten = value;
			}
		}
		
		private decimal? _baseaport;
		public virtual decimal? Baseaport
		{
			get
			{
				return this._baseaport;
			}
			set
			{
				this._baseaport = value;
			}
		}
		
		private decimal? _porc_apo;
		public virtual decimal? Porc_apo
		{
			get
			{
				return this._porc_apo;
			}
			set
			{
				this._porc_apo = value;
			}
		}
		
		private decimal? _impapor;
		public virtual decimal? Impapor
		{
			get
			{
				return this._impapor;
			}
			set
			{
				this._impapor = value;
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
		
		private short _impreso;
		public virtual short Impreso
		{
			get
			{
				return this._impreso;
			}
			set
			{
				this._impreso = value;
			}
		}
		
		private short _contabilizado;
		public virtual short Contabilizado
		{
			get
			{
				return this._contabilizado;
			}
			set
			{
				this._contabilizado = value;
			}
		}
		
		private short _pasaridoc;
		public virtual short Pasaridoc
		{
			get
			{
				return this._pasaridoc;
			}
			set
			{
				this._pasaridoc = value;
			}
		}
		
		private short _esanticipogasto;
		public virtual short Esanticipogasto
		{
			get
			{
				return this._esanticipogasto;
			}
			set
			{
				this._esanticipogasto = value;
			}
		}
		
		private string _rectif_codtipom;
		public virtual string Rectif_codtipom
		{
			get
			{
				return this._rectif_codtipom;
			}
			set
			{
				this._rectif_codtipom = value;
			}
		}
		
		private int? _rectif_numfactu;
		public virtual int? Rectif_numfactu
		{
			get
			{
				return this._rectif_numfactu;
			}
			set
			{
				this._rectif_numfactu = value;
			}
		}
		
		private DateTime? _rectif_fecfactu;
		public virtual DateTime? Rectif_fecfactu
		{
			get
			{
				return this._rectif_fecfactu;
			}
			set
			{
				this._rectif_fecfactu = value;
			}
		}
		
		private string _rectif_motivo;
		public virtual string Rectif_motivo
		{
			get
			{
				return this._rectif_motivo;
			}
			set
			{
				this._rectif_motivo = value;
			}
		}
		
		private short _esretirada;
		public virtual short Esretirada
		{
			get
			{
				return this._esretirada;
			}
			set
			{
				this._esretirada = value;
			}
		}
		
		private short _pdtenrofact;
		public virtual short Pdtenrofact
		{
			get
			{
				return this._pdtenrofact;
			}
			set
			{
				this._pdtenrofact = value;
			}
		}
		
		private string _numfacrec;
		public virtual string Numfacrec
		{
			get
			{
				return this._numfacrec;
			}
			set
			{
				this._numfacrec = value;
			}
		}
		
		private short _esliqcomplem;
		public virtual short Esliqcomplem
		{
			get
			{
				return this._esliqcomplem;
			}
			set
			{
				this._esliqcomplem = value;
			}
		}
		
		private Rsocio _rsocio;
		public virtual Rsocio Rsocio
		{
			get
			{
				return this._rsocio;
			}
			set
			{
				this._rsocio = value;
			}
		}
		
	}
}
#pragma warning restore 1591