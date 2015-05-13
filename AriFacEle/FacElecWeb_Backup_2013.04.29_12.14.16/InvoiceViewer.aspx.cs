﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZipLib;
using Telerik.Web.UI;
using DatosFacturaLib;
using System.IO;
using System.Configuration;

public partial class InvoiceViewer : System.Web.UI.Page
{
    FacturaEntity ctx1;
    int idCliente;
    //int idFactura = 0;
    Cliente cliente;

    protected void Page_Init(object sender, EventArgs e)
    {
        // Crear contexto
        ctx1 = new FacturaEntity("FacturaEntity");

        // Comprobamos si ha hecho un login previo, si no volvemos a la pàgina principal
        if (Session["IdCliente"] == null)
        {
            Response.Redirect("~/Inicio.aspx");
        }
        else
        {
            idCliente = int.Parse(Session["IdCliente"].ToString());
            cliente = (from c in ctx1.Clientes
                       where c.ID == idCliente
                       select c).First<Cliente>();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            grdFacturas.AllowSorting = true;
            GridSortExpression expresion = new GridSortExpression();
            expresion.FieldName = "Fecha";
            expresion.SortOrder = GridSortOrder.Descending;
            grdFacturas.MasterTableView.SortExpressions.Add(expresion);

            cmbAño_Load();
            cmbMes_Load();
            cargaAcumulados();
            loadCuenta();

            if (cliente.TieneFacturaPROV)
            {

                string s=ConfigurationSettings.AppSettings["textosolapaproveedores"];
                if (s != "")
                    RadTabStrip1.Tabs[2].Text = s;
                cmbMesP_Load();
                cmbAnyoP_Load();
                CargaAcumuladosProve();
            }
            else
            {
                this.RadTabStrip1.Tabs[2].Visible = false;
            }


            if (Request["Factura"] != null && int.Parse(Request["Factura"]) > 0)
            {
                int idFactura = int.Parse(Request["Factura"]);
                Factura f = (from fac in ctx1.Facturas
                                 where fac.Id_factura==idFactura
                                 select fac).FirstOrDefault<Factura>();
                if(f.Cliente.ID==idCliente)
                {
                    string command = "openinvoice("+idFactura+");";
                    RadAjaxManager ajax = Master.FindControl("RadAjaxManager1") as RadAjaxManager;
                    ajax.ResponseScripts.Add(command);
                }
            }
        }
        GridTraductor.TraducirFiltrosRadGrid(grdFacturas);
        GridTraductor.TraducirGrupoRadGrid(grdFacturas);
         
        if (cliente.TieneFacturaPROV)
        {
            GridTraductor.TraducirFiltrosRadGrid(grdFacturasProve);
            GridTraductor.TraducirGrupoRadGrid(grdFacturasProve);

        }

    }

    #region [Facturas]

    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        grdFacturas.DataSource = ObtenerFacturas2(true);
    }

    protected void RadGridProve_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        grdFacturasProve.DataSource = ObtenerFacturas2(false);  
    }



    protected List<Factura> ObtenerFacturas2(bool DeCliente)
    {
        List<Factura> facturas;

        facturas = (from f in ctx1.Facturas
                    where f.Id_cliente == idCliente && f.EsFraCliente == DeCliente 
                    select f).ToList<Factura>();


        string anyo, mes;
        if (DeCliente)
        {
            anyo = cmbAño.SelectedValue;
            mes = cmbMes.SelectedValue;
        }
        else
        {
            anyo = cmbAnyoP.SelectedValue;
            mes = cmbMesP.SelectedValue;
        }

        if (!anyo.Equals("0"))
            facturas = (from f in facturas
                        where f.Fecha.Value.Year.ToString() == anyo
                        select f).ToList<Factura>();

        if (!mes.Equals("0"))
            facturas = (from f in facturas
                        where f.Fecha.Value.Month.ToString() == mes
                        select f).ToList<Factura>();

        return facturas;
    }

    protected void grdFacturas_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            int registroId = int.Parse(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex][e.Item.OwnerTableView.DataKeyNames[0]].ToString());
            
            Factura f = CntLib.getFactura(registroId, ctx1);
            if (f.Nueva != false)
            {
                ImageButton btimg = (ImageButton)e.Item.FindControl("FacturaNueva");
                btimg.ToolTip = "¡Nueva!";
                btimg.Visible = true;
            }
        }
    }

    protected void grdFacturas_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        // Comprobamos que en realidad hay un comando llamante
        if (e.CommandSource == null) return;
        // Vemos el comando que nos ha llamado
        string st = e.CommandSource.GetType().ToString();
        if (st.Equals("System.Web.UI.WebControls.ImageButton"))
        {
            ImageButton imgb = (ImageButton)e.CommandSource;
            //RadWindow rdw;
            string imgbi = imgb.ID;
            string urlaux, url, dirRaiz, path;
            int codi = 0;
            // Vemos el ID asociado a la línea del GRID
            codi = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex][e.Item.OwnerTableView.DataKeyNames[0]];
            Factura fac = CntLib.getFactura(codi, ctx1);

            switch (imgbi)
            {
                case "Verfactura":
                    // MOD
                    fac.Nueva = false;
                    ctx1.SaveChanges();
                    urlaux = String.Format("Documentos\\{0:000000}", fac.Cliente.ID);
                    url = Request.PhysicalApplicationPath + urlaux;

                    dirRaiz = ctx1.Repositorios.FirstOrDefault<Repositorio>().Path;
                    //path = String.Format(dirRaiz + "{0}{1}_{2:00}{3:0000}.pdf", fac.Num_serie, fac.Num_factura, fac.Fecha.Value.Month, fac.Fecha.Value.Year);
                    path = CntLib.DevuelveNombreFichero(dirRaiz, fac);
                    ficherosLib.CopiarFichero(path, url);

                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-disposition", "attachment; filename= " + Path.GetFileName(path));
                    Response.WriteFile(String.Format("Documentos/{0:000000}/" + Path.GetFileName(path), fac.Cliente.ID));
                    Response.Flush();
                    Response.Close();

                    grdFacturas.Rebind();

                    break;

                case "VerfacturaE":
                    // MOD
                    if (fac.Sistema.SistemaId == 3)
                    {
                        RadWindowManager rdw = (RadWindowManager)this.Master.FindControl("RadWindowManager1");
                        //RadWindowManager1.RadConfirm("Existen " + i + " archivo(s) para adjuntar. ¿Continuar?", "");
                        rdw.RadAlert("No existe formato electrónico", 330, 180, "Envio email", null);
                        return;
                    }

                    fac.Nueva = false;
                    ctx1.SaveChanges();
                    urlaux = String.Format("Documentos\\{0:000000}", fac.Cliente.ID);
                    url = Request.PhysicalApplicationPath + urlaux;

                    dirRaiz = ctx1.Repositorios.FirstOrDefault<Repositorio>().Path;
                    path = String.Format(dirRaiz + "{0}{1}_{2:00}{3:0000}.xml", fac.Num_serie, fac.Num_factura, fac.Fecha.Value.Month, fac.Fecha.Value.Year);

                    ficherosLib.CopiarFichero(path, url);

                    Response.Clear();
                    Response.ContentType = "text/xml";
                    Response.AddHeader("Content-disposition", "attachment; filename= " + Path.GetFileName(path));
                    Response.WriteFile(String.Format("Documentos/{0:000000}/" + Path.GetFileName(path), fac.Cliente.ID));
                    Response.Flush();
                    Response.Close();

                    grdFacturas.Rebind();

                    break;

                default:
                    break;
            }
        }
    }


    protected void grdFacturasProve_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            int registroId = int.Parse(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex][e.Item.OwnerTableView.DataKeyNames[0]].ToString());

            Factura f = CntLib.getFactura(registroId, ctx1);
            if (f.Nueva != false)
            {
                ImageButton btimg = (ImageButton)e.Item.FindControl("FacturaNueva");
                btimg.ToolTip = "¡Nueva!";
                btimg.Visible = true;
            }
        }
    }

    protected void grdFacturasProve_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        // Comprobamos que en realidad hay un comando llamante
        if (e.CommandSource == null) return;
        // Vemos el comando que nos ha llamado
        string st = e.CommandSource.GetType().ToString();
        if (st.Equals("System.Web.UI.WebControls.ImageButton"))
        {
            ImageButton imgb = (ImageButton)e.CommandSource;
            //RadWindow rdw;
            string imgbi = imgb.ID;
            string urlaux, url, dirRaiz, path;
            int codi = 0;
            // Vemos el ID asociado a la línea del GRID
            codi = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex][e.Item.OwnerTableView.DataKeyNames[0]];
            Factura fac = CntLib.getFactura(codi, ctx1);

            if (imgbi=="Verfactura")
            {
                    // MOD
                    fac.Nueva = false;
                    ctx1.SaveChanges();
                    urlaux = String.Format("Documentos\\{0:000000}", fac.Cliente.ID);
                    url = Request.PhysicalApplicationPath + urlaux;

                    dirRaiz = ctx1.Repositorios.FirstOrDefault<Repositorio>().Path;
                    //path = String.Format(dirRaiz + "{0}{1}_{2:00}{3:0000}.pdf", fac.Num_serie, fac.Num_factura, fac.Fecha.Value.Month, fac.Fecha.Value.Year);
                    path = CntLib.DevuelveNombreFichero(dirRaiz, fac);
                    ficherosLib.CopiarFichero(path, url);

                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-disposition", "attachment; filename= " + Path.GetFileName(path));
                    Response.WriteFile(String.Format("Documentos/{0:000000}/" + Path.GetFileName(path), fac.Cliente.ID));
                    Response.Flush();
                    Response.Close();

                    grdFacturasProve.Rebind();

                   
               
                
            }
        }
        
    }

   
    protected void cmbAño_Load()
    {
        CargaComboGral(cmbAño, true);
    }


    protected void cmbAnyoP_Load()
    {
        CargaComboGral(cmbAnyoP, false); 
    }
    protected void CargaComboGral(RadComboBox cbo, bool clientes)
    {

        int añoini = AnyoDeIncio(clientes);
     

        int año = DateTime.Now.Year;
        cbo.Items.Add(new RadComboBoxItem("TODOS", "0"));
        if (añoini >0 )
        {
            for (int i = añoini; i <= año; i++)
            {
                cbo.Items.Add(new RadComboBoxItem(i.ToString(), i.ToString()));
            }
        }
        cbo.SelectedValue = año.ToString();
    }


    protected int AnyoDeIncio(bool paraClientes)
    {
        try
        {
            int añoini = (from fac in cliente.Facturas
                            where fac.EsFraCliente == paraClientes
                          select fac.Fecha).Min<DateTime?>().Value.Year;
            return añoini;
        }
        catch (Exception e)
        { return 0; }

    }
  
    protected void actualizaGrid()
    {
        grdFacturas.Rebind();
        cargaAcumulados();
    }
    protected void ActualizaGridProve()
    {
            
        grdFacturasProve.Rebind();
        CargaAcumuladosProve();
    }

    protected void cargaAcumulados()
    {
        List<Factura> listFacturas = (from f in ctx1.Facturas
                                      where f.Id_cliente == idCliente && f.EsFraCliente == true
                                      select f).ToList<Factura>();

        if (!cmbAño.SelectedValue.Equals("0"))
        {
            listFacturas = (from f in listFacturas
                            where f.Fecha.Value.Year.ToString() == cmbAño.SelectedValue && f.EsFraCliente == true
                            select f).ToList<Factura>();
        }

        if (!cmbMes.SelectedValue.Equals("0"))
        {
            listFacturas = (from f in listFacturas
                            where f.Fecha.Value.Month.ToString() == cmbMes.SelectedValue
                            select f).ToList<Factura>();
        }

        txtBase.Text = String.Format("{0:c}", (from f in listFacturas
                                               select f.Base_total).Sum());

        txtCuota.Text = String.Format("{0:c}", (from f in listFacturas
                                                select f.Cuota_total).Sum());

        txtImporte.Text = String.Format("{0:c}", (from f in listFacturas
                                                  select f.Ttal).Sum());
    }
    protected void CargaAcumuladosProve()
    {
        List<Factura> listFacturas = (from f in ctx1.Facturas
                                      where f.Id_cliente == idCliente  && f.EsFraCliente == false   
                                      select f).ToList<Factura>();

        if (!cmbAnyoP.SelectedValue.Equals("0"))
        {
            listFacturas = (from f in listFacturas
                            where f.Fecha.Value.Year.ToString() == cmbAnyoP.SelectedValue
                            select f).ToList<Factura>();
        }

        if (!cmbMesP.SelectedValue.Equals("0"))
        {
            listFacturas = (from f in listFacturas
                            where f.Fecha.Value.Month.ToString() == cmbMesP.SelectedValue
                            select f).ToList<Factura>();
        }



        BaseProv.Text = String.Format("{0:c}", (from f in listFacturas
                                               select f.Base_total).Sum());

        CuotaProv.Text = String.Format("{0:c}", (from f in listFacturas
                                                select f.Cuota_total).Sum());

        RetenProv.Text = String.Format("{0:c}", (from f in listFacturas
                                                 select f.ImpRetencion).Sum());

        TotalProv.Text = String.Format("{0:c}", (from f in listFacturas
                                                  select f.Ttal).Sum());
          
         
    }
    #endregion

    #region [Combos mes-fecha]
    protected void cmbAño_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        actualizaGrid();
    }
  
    protected void cmbMes_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        actualizaGrid();
    }

    protected void cmbMesP_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ActualizaGridProve();
    }
    protected void cmbAnyoP_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ActualizaGridProve();
    }

    protected void cmbMes_Load()
    {
        CargaMesesCombo(cmbMes);
    }
    protected void cmbMesP_Load()
    {
        CargaMesesCombo(cmbMesP);
    }

    protected void CargaMesesCombo(RadComboBox elCombo)
    {
        elCombo.Items.Add(new RadComboBoxItem("TODOS", "0"));
        elCombo.Items.Add(new RadComboBoxItem("Enero", "1"));
        elCombo.Items.Add(new RadComboBoxItem("Febrero", "2"));
        elCombo.Items.Add(new RadComboBoxItem("Marzo", "3"));
        elCombo.Items.Add(new RadComboBoxItem("Abril", "4"));
        elCombo.Items.Add(new RadComboBoxItem("Mayo", "5"));
        elCombo.Items.Add(new RadComboBoxItem("Junio", "6"));
        elCombo.Items.Add(new RadComboBoxItem("Julio", "7"));
        elCombo.Items.Add(new RadComboBoxItem("Agosto", "8"));
        elCombo.Items.Add(new RadComboBoxItem("Septiembre", "9"));
        elCombo.Items.Add(new RadComboBoxItem("Octubre", "10"));
        elCombo.Items.Add(new RadComboBoxItem("Noviembre", "11"));
        elCombo.Items.Add(new RadComboBoxItem("Diciembre", "12"));
        elCombo.SelectedValue = "0";
    }
    #endregion


    #region [Comprimir y xml de facturas como cliente]
    string nameZip;

    protected void imgBtnPDF_Click(object sender, ImageClickEventArgs e)
    {
        nameZip = String.Format("PDF{0:000}{1}_{2:00}{3:00}{4:0000}.zip", cliente.Id_empresa, cliente.Empresa.Nombre, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
        //ZipUtil.CreateZipFile(String.Format("Documentos\\{0:000000}", idCliente), nameZip, new DirectoryInfo(@"D:\ICONOS"));
        copiaComprimir(0, true);
        grdFacturas.Rebind();
    }

    protected void imgBtnXML_Click(object sender, ImageClickEventArgs e)
    {
        nameZip = String.Format("FacturaE{0:000}{1}_{2:00}{3:00}{4:0000}.zip", cliente.Id_empresa, cliente.Empresa.Nombre, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
        copiaComprimir(1,true );
        grdFacturas.Rebind();
    }

    // A las de preoveedores le añado una P
    protected void imgBtnPDFProv_Click(object sender, ImageClickEventArgs e)
    {
        nameZip = String.Format("PDF{0:000}{1}_{2:00}{3:00}{4:0000}.zip", cliente.Id_empresa, cliente.Empresa.Nombre + "P", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
        copiaComprimir(0,false );
        grdFacturasProve.Rebind();
    }

    protected void imgBtnXMLProve_Click(object sender, ImageClickEventArgs e)
    {
        nameZip = String.Format("FacturaE{0:000}{1}_{2:00}{3:00}{4:0000}.zip", cliente.Id_empresa, cliente.Empresa.Nombre + "P", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
        //ZipUtil.CreateZipFile(String.Format("Documentos\\{0:000000}", idCliente), nameZip, new DirectoryInfo(@"D:\ICONOS"));
        copiaComprimir(1,false );
        grdFacturasProve.Rebind();
    }



    private void copiaComprimir(int tipo, bool DeClientes)
    {
        string dirRaiz;
        string path = "";
        List<FileSystemInfo> archivos = new List<FileSystemInfo>();

        bool HayDatos = false ;

        dirRaiz = ctx1.Repositorios.FirstOrDefault<Repositorio>().Path;
        if (tipo == 0)//PDF
        {
            foreach (Factura item in ObtenerFacturas2(DeClientes))
            {
                
                
                path = String.Format(@"" + dirRaiz + "{0}{1}_{2:00}{3:0000}.pdf", item.Num_serie, item.Num_factura, item.Fecha.Value.Month, item.Fecha.Value.Year);

                if (File.Exists(path))
                {
                    archivos.Add(new FileInfo(path));
                    HayDatos = true;
                    item.Nueva = false;
                }
            }
           
        }
        else//FacturaE
        {
            foreach (Factura item in ObtenerFacturas2(DeClientes))
            {
               
              
                path = String.Format(@"" + dirRaiz + "{0}{1}_{2:00}{3:0000}.xml", item.Num_serie, item.Num_factura, item.Fecha.Value.Month, item.Fecha.Value.Year);
                if (File.Exists(path))
                {
                    archivos.Add(new FileInfo(path));
                    HayDatos = true;
                    item.Nueva = false;
                }
            }
        }

        if (HayDatos)
        {
            ctx1.SaveChanges();
            ZipUtil.CreateZipFile(Request.PhysicalApplicationPath + String.Format("Documentos\\{0:000000}\\", idCliente), nameZip, archivos.ToArray(), true);

            Response.Clear();
            Response.ContentType = "application/x-zip-compressed";
            Response.AddHeader("Content-disposition", "attachment; filename= " + nameZip);
            Response.WriteFile(String.Format("Documentos/{0:000000}/" + nameZip, idCliente));
            Response.Flush();
            Response.Close();
        }
    }
    
    #endregion

    #region[mi_cuenta]

    protected void loadCuenta()
    {
        txtNombre.Text = cliente.Nombre;
        txtNombre.Enabled = false;
        txtLogin.Text = cliente.Login;
        txtLogin.Enabled = false;
        txtCif.Text = cliente.Cif;
        txtCif.Enabled = false;
        txtEmail.Text = cliente.Email;
    }
   
    protected void RadButton1_Click(object sender, EventArgs e)
    {
        Image1.Visible = true;
        Image2.Visible = true;
        Image3.Visible = true;
        if (!txtEmail.Text.Equals(""))
        {
            cliente.Email = txtEmail.Text;
            Image3.ImageUrl = "~/img/accept.png";
        }
        else
        {
            Image3.ImageUrl = "~/img/warning.png";
        }
        if (!txtPass1.Text.Equals("") && !txtPass2.Text.Equals("") && txtPass1.Text.Equals(txtPass2.Text))
        {
            Image1.ImageUrl = "~/img/accept.png";
            Image2.ImageUrl = "~/img/accept.png";

            cliente.Contraseña = txtPass1.Text;
            ctx1.SaveChanges();
        }
        else
        {
            Image1.ImageUrl = "~/img/warning.png";
            Image2.ImageUrl = "~/img/warning.png";
        }
    }
    #endregion

}