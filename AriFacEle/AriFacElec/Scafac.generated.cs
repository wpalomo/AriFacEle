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
using AriFacElec;

namespace AriFacElec	
{
	public partial class Scafac
	{
		private string codtipom;
		public virtual string Codtipom
		{
			get
			{
				return this.codtipom;
			}
			set
			{
				this.codtipom = value;
			}
		}
		
		private int numfactu;
		public virtual int Numfactu
		{
			get
			{
				return this.numfactu;
			}
			set
			{
				this.numfactu = value;
			}
		}
		
		private DateTime fecfactu;
		public virtual DateTime Fecfactu
		{
			get
			{
				return this.fecfactu;
			}
			set
			{
				this.fecfactu = value;
			}
		}
		
		private int codclien;
		public virtual int Codclien
		{
			get
			{
				return this.codclien;
			}
			set
			{
				this.codclien = value;
			}
		}
		
		private string nomclien;
		public virtual string Nomclien
		{
			get
			{
				return this.nomclien;
			}
			set
			{
				this.nomclien = value;
			}
		}
		
		private string domclien;
		public virtual string Domclien
		{
			get
			{
				return this.domclien;
			}
			set
			{
				this.domclien = value;
			}
		}
		
		private string codpobla;
		public virtual string Codpobla
		{
			get
			{
				return this.codpobla;
			}
			set
			{
				this.codpobla = value;
			}
		}
		
		private string pobclien;
		public virtual string Pobclien
		{
			get
			{
				return this.pobclien;
			}
			set
			{
				this.pobclien = value;
			}
		}
		
		private string proclien;
		public virtual string Proclien
		{
			get
			{
				return this.proclien;
			}
			set
			{
				this.proclien = value;
			}
		}
		
		private string nifclien;
		public virtual string Nifclien
		{
			get
			{
				return this.nifclien;
			}
			set
			{
				this.nifclien = value;
			}
		}
		
		private string telclien;
		public virtual string Telclien
		{
			get
			{
				return this.telclien;
			}
			set
			{
				this.telclien = value;
			}
		}
		
		private short? coddirec;
		public virtual short? Coddirec
		{
			get
			{
				return this.coddirec;
			}
			set
			{
				this.coddirec = value;
			}
		}
		
		private string nomdirec;
		public virtual string Nomdirec
		{
			get
			{
				return this.nomdirec;
			}
			set
			{
				this.nomdirec = value;
			}
		}
		
		private short codagent;
		public virtual short Codagent
		{
			get
			{
				return this.codagent;
			}
			set
			{
				this.codagent = value;
			}
		}
		
		private short codforpa;
		public virtual short Codforpa
		{
			get
			{
				return this.codforpa;
			}
			set
			{
				this.codforpa = value;
			}
		}
		
		private decimal dtoppago;
		public virtual decimal Dtoppago
		{
			get
			{
				return this.dtoppago;
			}
			set
			{
				this.dtoppago = value;
			}
		}
		
		private decimal dtognral;
		public virtual decimal Dtognral
		{
			get
			{
				return this.dtognral;
			}
			set
			{
				this.dtognral = value;
			}
		}
		
		private short? codbanco;
		public virtual short? Codbanco
		{
			get
			{
				return this.codbanco;
			}
			set
			{
				this.codbanco = value;
			}
		}
		
		private short? codsucur;
		public virtual short? Codsucur
		{
			get
			{
				return this.codsucur;
			}
			set
			{
				this.codsucur = value;
			}
		}
		
		private string digcontr;
		public virtual string Digcontr
		{
			get
			{
				return this.digcontr;
			}
			set
			{
				this.digcontr = value;
			}
		}
		
		private string cuentaba;
		public virtual string Cuentaba
		{
			get
			{
				return this.cuentaba;
			}
			set
			{
				this.cuentaba = value;
			}
		}
		
		private decimal brutofac;
		public virtual decimal Brutofac
		{
			get
			{
				return this.brutofac;
			}
			set
			{
				this.brutofac = value;
			}
		}
		
		private decimal impdtopp;
		public virtual decimal Impdtopp
		{
			get
			{
				return this.impdtopp;
			}
			set
			{
				this.impdtopp = value;
			}
		}
		
		private decimal impdtogr;
		public virtual decimal Impdtogr
		{
			get
			{
				return this.impdtogr;
			}
			set
			{
				this.impdtogr = value;
			}
		}
		
		private decimal baseimp1;
		public virtual decimal Baseimp1
		{
			get
			{
				return this.baseimp1;
			}
			set
			{
				this.baseimp1 = value;
			}
		}
		
		private decimal? baseimp2;
		public virtual decimal? Baseimp2
		{
			get
			{
				return this.baseimp2;
			}
			set
			{
				this.baseimp2 = value;
			}
		}
		
		private decimal? baseimp3;
		public virtual decimal? Baseimp3
		{
			get
			{
				return this.baseimp3;
			}
			set
			{
				this.baseimp3 = value;
			}
		}
		
		private byte? codigiv1;
		public virtual byte? Codigiv1
		{
			get
			{
				return this.codigiv1;
			}
			set
			{
				this.codigiv1 = value;
			}
		}
		
		private byte? codigiv2;
		public virtual byte? Codigiv2
		{
			get
			{
				return this.codigiv2;
			}
			set
			{
				this.codigiv2 = value;
			}
		}
		
		private byte? codigiv3;
		public virtual byte? Codigiv3
		{
			get
			{
				return this.codigiv3;
			}
			set
			{
				this.codigiv3 = value;
			}
		}
		
		private decimal? porciva1;
		public virtual decimal? Porciva1
		{
			get
			{
				return this.porciva1;
			}
			set
			{
				this.porciva1 = value;
			}
		}
		
		private decimal? porciva2;
		public virtual decimal? Porciva2
		{
			get
			{
				return this.porciva2;
			}
			set
			{
				this.porciva2 = value;
			}
		}
		
		private decimal? porciva3;
		public virtual decimal? Porciva3
		{
			get
			{
				return this.porciva3;
			}
			set
			{
				this.porciva3 = value;
			}
		}
		
		private decimal imporiv1;
		public virtual decimal Imporiv1
		{
			get
			{
				return this.imporiv1;
			}
			set
			{
				this.imporiv1 = value;
			}
		}
		
		private decimal? imporiv2;
		public virtual decimal? Imporiv2
		{
			get
			{
				return this.imporiv2;
			}
			set
			{
				this.imporiv2 = value;
			}
		}
		
		private decimal? imporiv3;
		public virtual decimal? Imporiv3
		{
			get
			{
				return this.imporiv3;
			}
			set
			{
				this.imporiv3 = value;
			}
		}
		
		private decimal totalfac;
		public virtual decimal Totalfac
		{
			get
			{
				return this.totalfac;
			}
			set
			{
				this.totalfac = value;
			}
		}
		
		private byte? intconta;
		public virtual byte? Intconta
		{
			get
			{
				return this.intconta;
			}
			set
			{
				this.intconta = value;
			}
		}
		
		private decimal? porciva1re;
		public virtual decimal? Porciva1re
		{
			get
			{
				return this.porciva1re;
			}
			set
			{
				this.porciva1re = value;
			}
		}
		
		private decimal? porciva2re;
		public virtual decimal? Porciva2re
		{
			get
			{
				return this.porciva2re;
			}
			set
			{
				this.porciva2re = value;
			}
		}
		
		private decimal? porciva3re;
		public virtual decimal? Porciva3re
		{
			get
			{
				return this.porciva3re;
			}
			set
			{
				this.porciva3re = value;
			}
		}
		
		private decimal? imporiv1re;
		public virtual decimal? Imporiv1re
		{
			get
			{
				return this.imporiv1re;
			}
			set
			{
				this.imporiv1re = value;
			}
		}
		
		private decimal? imporiv2re;
		public virtual decimal? Imporiv2re
		{
			get
			{
				return this.imporiv2re;
			}
			set
			{
				this.imporiv2re = value;
			}
		}
		
		private decimal? imporiv3re;
		public virtual decimal? Imporiv3re
		{
			get
			{
				return this.imporiv3re;
			}
			set
			{
				this.imporiv3re = value;
			}
		}
		
		private int? aridoc;
		public virtual int? Aridoc
		{
			get
			{
				return this.aridoc;
			}
			set
			{
				this.aridoc = value;
			}
		}
		
		private decimal? aportacion;
		public virtual decimal? Aportacion
		{
			get
			{
				return this.aportacion;
			}
			set
			{
				this.aportacion = value;
			}
		}
		
		private decimal? pesoalba;
		public virtual decimal? Pesoalba
		{
			get
			{
				return this.pesoalba;
			}
			set
			{
				this.pesoalba = value;
			}
		}
		
		private decimal? portes;
		public virtual decimal? Portes
		{
			get
			{
				return this.portes;
			}
			set
			{
				this.portes = value;
			}
		}
		
		private Sclien sclien;
		public virtual Sclien Sclien
		{
			get
			{
				return this.sclien;
			}
			set
			{
				this.sclien = value;
			}
		}
		
		private Stipom stipom;
		public virtual Stipom Stipom
		{
			get
			{
				return this.stipom;
			}
			set
			{
				this.stipom = value;
			}
		}
		
		private IList<Slifac> slifacs = new List<Slifac>();
		public virtual IList<Slifac> Slifacs
		{
			get
			{
				return this.slifacs;
			}
		}
		
		private IList<Svenci> svencis = new List<Svenci>();
		public virtual IList<Svenci> Svencis
		{
			get
			{
				return this.svencis;
			}
		}
		
	}
}
#pragma warning restore 1591
