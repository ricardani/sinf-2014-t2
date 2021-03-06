﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Interop.ErpBS800;
using Interop.StdPlatBS800;
using Interop.StdBE800;
using Interop.GcpBE800;
using ADODB;
using Interop.IGcpBS800;
//using Interop.StdBESql800;
//using Interop.StdBSSql800;

namespace FirstREST.Lib_Primavera
{
    public class Comercial
    {


        # region Cliente

        public static List<Model.Cliente> ListaClientes()
        {
            ErpBS objMotor = new ErpBS();
             
            StdBELista objList;

            Model.Cliente cli = new Model.Cliente();
            List<Model.Cliente> listClientes = new List<Model.Cliente>();


            if (PriEngine.InitializeCompany("BELAFLOR", "", "") == true)
            {

                //objList = PriEngine.Engine.Comercial.Clientes.LstClientes();

                objList = PriEngine.Engine.Consulta("SELECT Cliente, Nome, Moeda, NumContrib as NumContribuinte FROM  CLIENTES");

                while (!objList.NoFim())
                {
                    cli = new Model.Cliente();
                    cli.CodCliente = objList.Valor("Cliente");
                    cli.NomeCliente = objList.Valor("Nome");
                    cli.Moeda = objList.Valor("Moeda");
                    cli.NumContribuinte = objList.Valor("NumContribuinte");

                    listClientes.Add(cli);
                    objList.Seguinte();

                }

                return listClientes;
            }
            else
                return null;
        }

        public static Lib_Primavera.Model.Cliente GetCliente(string codCliente)
        {
            ErpBS objMotor = new ErpBS();

            GcpBECliente objCli = new GcpBECliente();


            Model.Cliente myCli = new Model.Cliente();

            if (PriEngine.InitializeCompany("BELAFLOR", "", "") == true)
            {

                if (PriEngine.Engine.Comercial.Clientes.Existe(codCliente) == true)
                {
                    objCli = PriEngine.Engine.Comercial.Clientes.Edita(codCliente);
                    myCli.CodCliente = objCli.get_Cliente();
                    myCli.NomeCliente = objCli.get_Nome();
                    myCli.Moeda = objCli.get_Moeda();
                    myCli.NumContribuinte = objCli.get_NumContribuinte();
                    return myCli;
                }
                else
                {
                    return null;
                }
            }
            else
                return null;
        }

        public static Lib_Primavera.Model.RespostaErro UpdCliente(Lib_Primavera.Model.Cliente cliente)
        {



            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
            ErpBS objMotor = new ErpBS();

            GcpBECliente objCli = new GcpBECliente();

            try
            {

                if (PriEngine.InitializeCompany("BELAFLOR", "", "") == true)
                {

                    if (PriEngine.Engine.Comercial.Clientes.Existe(cliente.CodCliente) == false)
                    {
                        erro.Erro = 1;
                        erro.Descricao = "O cliente não existe";
                        return erro;
                    }
                    else
                    {

                        objCli = PriEngine.Engine.Comercial.Clientes.Edita(cliente.CodCliente);
                        objCli.set_EmModoEdicao(true);

                        objCli.set_Nome(cliente.NomeCliente);
                        objCli.set_NumContribuinte(cliente.NumContribuinte);
                        objCli.set_Moeda(cliente.Moeda);

                        PriEngine.Engine.Comercial.Clientes.Actualiza(objCli);

                        erro.Erro = 0;
                        erro.Descricao = "Sucesso";
                        return erro;
                    }
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir a empresa";
                    return erro;

                }

            }

            catch (Exception ex)
            {
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }

        }


        public static Lib_Primavera.Model.RespostaErro DelCliente(string codCliente)
        {

            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
            GcpBECliente objCli = new GcpBECliente();


            try
            {

                if (PriEngine.InitializeCompany("BELAFLOR", "", "") == true)
                {
                    if (PriEngine.Engine.Comercial.Clientes.Existe(codCliente) == false)
                    {
                        erro.Erro = 1;
                        erro.Descricao = "O cliente não existe";
                        return erro;
                    }
                    else
                    {

                        PriEngine.Engine.Comercial.Clientes.Remove(codCliente);
                        erro.Erro = 0;
                        erro.Descricao = "Sucesso";
                        return erro;
                    }
                }

                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir a empresa";
                    return erro;
                }
            }

            catch (Exception ex)
            {
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }

        }


        public static Lib_Primavera.Model.RespostaErro InsereClienteObj(Model.Cliente cli)
        {

            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
         
            GcpBECliente myCli = new GcpBECliente();

            try
            {
                if (PriEngine.InitializeCompany("BELAFLOR", "", "") == true)
                {

                    myCli.set_Cliente(cli.CodCliente);
                    myCli.set_Nome(cli.NomeCliente);
                    myCli.set_NumContribuinte(cli.NumContribuinte);
                    myCli.set_Moeda(cli.Moeda);

                    PriEngine.Engine.Comercial.Clientes.Actualiza(myCli);

                    erro.Erro = 0;
                    erro.Descricao = "Sucesso";
                    return erro;
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir empresa";
                    return erro;
                }
            }

            catch (Exception ex)
            {
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }


        }

        /*
        public static void InsereCliente(string codCliente, string nomeCliente, string numContribuinte, string moeda)
        {
            ErpBS objMotor = new ErpBS();
            MotorPrimavera mp = new MotorPrimavera();

            GcpBECliente myCli = new GcpBECliente();

            objMotor = mp.AbreEmpresa("DEMO", "", "", "Default");

            myCli.set_Cliente(codCliente);
            myCli.set_Nome(nomeCliente);
            myCli.set_NumContribuinte(numContribuinte);
            myCli.set_Moeda(moeda);

            objMotor.Comercial.Clientes.Actualiza(myCli);

        }


        */


        #endregion Cliente;   // -----------------------------  END   CLIENTE    -----------------------


        public static Lib_Primavera.Model.Artigo GetArtigo(string codArtigo)
        {
            

            GcpBEArtigo objArtigo = new GcpBEArtigo();
            Model.Artigo myArt = new Model.Artigo();

            if (PriEngine.InitializeCompany("BELAFLOR", "", "") == true)
            {

                if (PriEngine.Engine.Comercial.Artigos.Existe(codArtigo) == false)
                {
                    return null;
                }
                else
                {
                    objArtigo = PriEngine.Engine.Comercial.Artigos.Edita(codArtigo);
                    myArt.CodArtigo = objArtigo.get_Artigo();
                    myArt.DescArtigo = objArtigo.get_Descricao();

                    return myArt;
                }
                
            }
            else
            {
                return null;
            }

        }

        public static List<Model.Artigo> ListaArtigos()
        {
            ErpBS objMotor = new ErpBS();
           
            StdBELista objList;

            Model.Artigo art = new Model.Artigo();
            List<Model.Artigo> listArts = new List<Model.Artigo>();

            if (PriEngine.InitializeCompany("BELAFLOR", "", "") == true)
            {

                objList = PriEngine.Engine.Comercial.Artigos.LstArtigos();

                while (!objList.NoFim())
                {
                    art = new Model.Artigo();
                    art.CodArtigo = objList.Valor("artigo");
                    art.DescArtigo = objList.Valor("descricao");

                    listArts.Add(art);
                    objList.Seguinte();
                }

                return listArts;

            }
            else
            {
                return null;

            }

        }



        //------------------------------------ ENCOMENDA ---------------------
       
        public static Model.RespostaErro TransformaDoc(Model.DocCompra dc)
        {

            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
            GcpBEDocumentoCompra objEnc = new GcpBEDocumentoCompra();
            GcpBEDocumentoCompra objGR = new GcpBEDocumentoCompra();
            GcpBELinhasDocumentoCompra objLinEnc = new GcpBELinhasDocumentoCompra();
            PreencheRelacaoCompras rl = new PreencheRelacaoCompras();

            List<Model.LinhaDocCompra> lstlindc = new List<Model.LinhaDocCompra>();

            try
            {
                if (PriEngine.InitializeCompany("BELAFLOR", "", "") == true)
                {
                

                    objEnc = PriEngine.Engine.Comercial.Compras.Edita("000", "ECF", dc.Serie, dc.NumDoc);

                    // --- Criar os cabeçalhos da GR
                    objGR.set_Entidade(objEnc.get_Entidade());
                    objEnc.set_Serie(dc.Serie);
                    objEnc.set_Tipodoc("ECF");
                    objEnc.set_TipoEntidade("F");

                    objGR = PriEngine.Engine.Comercial.Compras.PreencheDadosRelacionados(objGR,rl);
 

                    // façam p.f. o ciclo para percorrer as linhas da encomenda que pretendem copiar

                    for (int i = 0; i < dc.LinhasDoc.Count; i++)
                    {
                        double QdeaCopiar = dc.LinhasDoc[i].QuantidadeRecebida;
                        if (QdeaCopiar > 0)
                            PriEngine.Engine.Comercial.Internos.CopiaLinha("C", objEnc, "C", objGR, dc.LinhasDoc[i].NumLinha, QdeaCopiar);
                    }
                     
                        
                       
                        // precisamos aqui de um metodo que permita actualizar a Qde Satisfeita da linha de encomenda.  Existe em VB mas ainda não sei qual é em c#
                       
                    PriEngine.Engine.IniciaTransaccao();
                    PriEngine.Engine.Comercial.Compras.Actualiza(objEnc, "");
                    PriEngine.Engine.Comercial.Compras.Actualiza(objGR, "");

                    PriEngine.Engine.TerminaTransaccao();

                    erro.Erro = 0;
                    erro.Descricao = "Sucesso";
                    return erro;
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir empresa";
                    return erro;

                }

            }
            catch (Exception ex)
            {
                //PriEngine.Engine.DesfazTransaccao();
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }
        
        
        }




        // ------------------------ Documentos de Compra --------------------------//



        public static Model.RespostaErro Encomendas_ComprasNew(Model.DocCompra dv)
        {
            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
            GcpBEDocumentoCompra myEnc = new GcpBEDocumentoCompra();

            GcpBELinhaDocumentoCompra myLin = new GcpBELinhaDocumentoCompra();

            GcpBELinhasDocumentoCompra myLinhas = new GcpBELinhasDocumentoCompra();

            PreencheRelacaoCompras rl = new PreencheRelacaoCompras();
            List<Model.LinhaDocCompra> lstlindv = new List<Model.LinhaDocCompra>();

            try
            {
                if (PriEngine.InitializeCompany("BELAFLOR", "", "") == true)
                {
                    // Atribui valores ao cabecalho do doc
                    //myEnc.set_DataDoc(dv.Data);
                    myEnc.set_Entidade(dv.EntidadeID);
                    myEnc.set_Serie(dv.Serie);
                    myEnc.set_Tipodoc("VFA");
                    myEnc.set_TipoEntidade("F");
                    // Linhas do documento para a lista de linhas
                    lstlindv = dv.LinhasDoc;
                    PriEngine.Engine.Comercial.Compras.PreencheDadosRelacionados(myEnc, rl);
                    foreach (Model.LinhaDocCompra lin in lstlindv)
                    {
                        PriEngine.Engine.Comercial.Compras.AdicionaLinha(myEnc, lin.CodArtigo, -lin.QuantidadeRecebida, "", "", lin.PrecoUnitario, lin.Desconto);
                    }


                    // PriEngine.Engine.Comercial.Compras.TransformaDocumento(

                    PriEngine.Engine.IniciaTransaccao();
                    PriEngine.Engine.Comercial.Compras.Actualiza(myEnc, "Teste");
                    PriEngine.Engine.TerminaTransaccao();
                    erro.Erro = 0;
                    erro.Descricao = "Sucesso";
                    return erro;
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir empresa";
                    return erro;

                }

            }
            catch (Exception ex)
            {
                PriEngine.Engine.DesfazTransaccao();
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }
        }


        public static List<Model.DocCompra> VGR_List()
        {
            ErpBS objMotor = new ErpBS();
            StdBELista objListCab;
            StdBELista objListLin;
            Model.DocCompra dc = new Model.DocCompra();
            List<Model.DocCompra> listdc = new List<Model.DocCompra>();
            Model.LinhaDocCompra lindc = new Model.LinhaDocCompra();
            List<Model.LinhaDocCompra> listlindc = new List<Model.LinhaDocCompra>(); 

            if (PriEngine.InitializeCompany("BELAFLOR", "", "") == true)
            {
                objListCab = PriEngine.Engine.Consulta("SELECT id, NumDocExterno, Entidade, DataDoc, NumDoc, TotalMerc, Serie From CabecCompras where TipoDoc='VGR'");
                while (!objListCab.NoFim())
                {
                    dc = new Model.DocCompra();
                    dc.id = objListCab.Valor("id");
                    dc.NumDocExterno = objListCab.Valor("NumDocExterno");
                    dc.Entidade = objListCab.Valor("Entidade");
                    dc.NumDoc = objListCab.Valor("NumDoc");
                    dc.Data = objListCab.Valor("DataDoc");
                    dc.TotalMerc = objListCab.Valor("TotalMerc");
                    dc.Serie = objListCab.Valor("Serie");
                    objListLin = PriEngine.Engine.Consulta("SELECT idCabecCompras, Artigo, Descricao, Quantidade, Unidade, PrecUnit, Desconto1, TotalILiquido, PrecoLiquido, Armazem, Lote from LinhasCompras where IdCabecCompras='" + dc.id + "' order By NumLinha");
                    listlindc = new List<Model.LinhaDocCompra>();

                    while (!objListLin.NoFim())
                    {
                        lindc = new Model.LinhaDocCompra();
                        lindc.IdCabecDoc = objListLin.Valor("idCabecCompras");
                        lindc.CodArtigo = objListLin.Valor("Artigo");
                        lindc.DescArtigo = objListLin.Valor("Descricao");
                        lindc.Quantidade = objListLin.Valor("Quantidade");
                        lindc.Unidade = objListLin.Valor("Unidade");
                        lindc.Desconto = objListLin.Valor("Desconto1");
                        lindc.PrecoUnitario = objListLin.Valor("PrecUnit");
                        lindc.TotalILiquido = objListLin.Valor("TotalILiquido");
                        lindc.TotalLiquido = objListLin.Valor("PrecoLiquido");
                        lindc.Armazem = objListLin.Valor("Armazem");
                        lindc.Lote = objListLin.Valor("Lote");

                        listlindc.Add(lindc);
                        objListLin.Seguinte();
                    }

                    dc.LinhasDoc = listlindc;
                    
                    listdc.Add(dc);
                    objListCab.Seguinte();
                }
            }
            return listdc;
        }
        
        public static Model.RespostaErro VGR_New(Model.DocCompra dc)
        {
            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
            

            GcpBEDocumentoCompra myGR = new GcpBEDocumentoCompra();
            GcpBELinhaDocumentoCompra myLin = new GcpBELinhaDocumentoCompra();
            GcpBELinhasDocumentoCompra myLinhas = new GcpBELinhasDocumentoCompra();

            PreencheRelacaoCompras rl = new PreencheRelacaoCompras();
            List<Model.LinhaDocCompra> lstlindv = new List<Model.LinhaDocCompra>();

            try
            {
                if (PriEngine.InitializeCompany("BELAFLOR", "", "") == true)
                {
                    // Atribui valores ao cabecalho do doc
                    //myEnc.set_DataDoc(dv.Data);
                    myGR.set_Entidade(dc.EntidadeID);
                    myGR.set_NumDocExterno(dc.NumDocExterno);
                    myGR.set_Serie(dc.Serie);
                    myGR.set_Tipodoc("VGR");
                    myGR.set_TipoEntidade("F");
                    //myGR.set_TipoEntidadeEntrega("F");
                    //myGR.set_ModoExp("01");
                    // Linhas do documento para a lista de linhas
                    lstlindv = dc.LinhasDoc;
                    PriEngine.Engine.Comercial.Compras.PreencheDadosRelacionados(myGR, rl);
                    foreach (Model.LinhaDocCompra lin in lstlindv)
                    {
                        if(lin.QuantidadeRecebida > 0 && lin.QuantidadeRecebida <= lin.Quantidade)
                            PriEngine.Engine.Comercial.Compras.AdicionaLinha(myGR, lin.CodArtigo, lin.QuantidadeRecebida, lin.ArmazemID, "", lin.PrecoUnitario, lin.Desconto);
                    }

                    PriEngine.Engine.IniciaTransaccao();
                    PriEngine.Engine.Comercial.Compras.Actualiza(myGR, "Teste");
                    PriEngine.Engine.TerminaTransaccao();
                    erro.Erro = 0;
                    erro.Descricao = "Sucesso";
                    return erro;
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir empresa";
                    return erro;

                }

            }
            catch (Exception ex)
            {
                PriEngine.Engine.DesfazTransaccao();
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }
        }
        


        // ------ Documentos de venda ----------------------



        public static Model.RespostaErro Encomendas_New(Model.DocVenda dv)
        {
            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
            GcpBEDocumentoVenda myEnc = new GcpBEDocumentoVenda();
             
            GcpBELinhaDocumentoVenda myLin = new GcpBELinhaDocumentoVenda();

            GcpBELinhasDocumentoVenda myLinhas = new GcpBELinhasDocumentoVenda();
             
            PreencheRelacaoVendas rl = new PreencheRelacaoVendas();
            List<Model.LinhaDocVenda> lstlindv = new List<Model.LinhaDocVenda>();
            
            try
            {
                if (PriEngine.InitializeCompany("BELAFLOR", "", "") == true)
                {
                    // Atribui valores ao cabecalho do doc
                    //myEnc.set_DataDoc(dv.Data);
                    myEnc.set_Entidade(dv.Entidade);
                    myEnc.set_Serie(dv.Serie);
                    myEnc.set_Tipodoc("ECL");
                    myEnc.set_TipoEntidade("C");
                    // Linhas do documento para a lista de linhas
                    lstlindv = dv.LinhasDoc;
                    PriEngine.Engine.Comercial.Vendas.PreencheDadosRelacionados(myEnc, rl);
                    foreach (Model.LinhaDocVenda lin in lstlindv)
                    {
                        PriEngine.Engine.Comercial.Vendas.AdicionaLinha(myEnc, lin.CodArtigo, lin.Quantidade, "", "", lin.PrecoUnitario, lin.Desconto);
                    }


                   // PriEngine.Engine.Comercial.Compras.TransformaDocumento(

                    PriEngine.Engine.IniciaTransaccao();
                    PriEngine.Engine.Comercial.Vendas.Actualiza(myEnc, "Teste");
                    PriEngine.Engine.TerminaTransaccao();
                    erro.Erro = 0;
                    erro.Descricao = "Sucesso";
                    return erro;
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir empresa";
                    return erro;

                }

            }
            catch (Exception ex)
            {
                PriEngine.Engine.DesfazTransaccao();
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }
        }


        public static List<Model.DocVenda> Encomendas_List()
        {
            ErpBS objMotor = new ErpBS();
            
            StdBELista objListCab;
            StdBELista objListLin;
            Model.DocVenda dv = new Model.DocVenda();
            List<Model.DocVenda> listdv = new List<Model.DocVenda>();
            Model.LinhaDocVenda lindv = new Model.LinhaDocVenda();
            List<Model.LinhaDocVenda> listlindv = new
            List<Model.LinhaDocVenda>();

            if (PriEngine.InitializeCompany("BELAFLOR", "", "") == true)
            {
                objListCab = PriEngine.Engine.Consulta("SELECT id, Entidade, Data, NumDoc, TotalMerc, Serie From CabecCompra where TipoDoc='ECF'");
                while (!objListCab.NoFim())
                {
                    dv = new Model.DocVenda();
                    dv.id = objListCab.Valor("id");
                    dv.Entidade = objListCab.Valor("Entidade");
                    dv.NumDoc = objListCab.Valor("NumDoc");
                    dv.Data = objListCab.Valor("Data");
                    dv.TotalMerc = objListCab.Valor("TotalMerc");
                    dv.Serie = objListCab.Valor("Serie");
                    objListLin = PriEngine.Engine.Consulta("SELECT idCabecCompras, Artigo, Descricao, Quantidade, Unidade, PrecUnit, Desconto1, TotalILiquido, PrecoLiquido from LinhasCompra where IdCabecDoc='" + dv.id + "' order By NumLinha");
                    listlindv = new List<Model.LinhaDocVenda>();

                    while (!objListLin.NoFim())
                    {
                        lindv = new Model.LinhaDocVenda();
                        lindv.IdCabecDoc = objListLin.Valor("idCabecDoc");
                        lindv.CodArtigo = objListLin.Valor("Artigo");
                        lindv.DescArtigo = objListLin.Valor("Descricao");
                        lindv.Quantidade = objListLin.Valor("Quantidade");
                        lindv.Unidade = objListLin.Valor("Unidade");
                        lindv.Desconto = objListLin.Valor("Desconto1");
                        lindv.PrecoUnitario = objListLin.Valor("PrecUnit");
                        lindv.TotalILiquido = objListLin.Valor("TotalILiquido");
                        lindv.TotalLiquido = objListLin.Valor("PrecoLiquido");

                        listlindv.Add(lindv);
                        objListLin.Seguinte();
                    }

                    dv.LinhasDoc = listlindv;
                    listdv.Add(dv);
                    objListCab.Seguinte();
                }
            }

            return listdv;
        }


        public static Model.DocVenda Encomenda_Get(string numdoc)
        {
            ErpBS objMotor = new ErpBS();
             
            StdBELista objListCab;
            StdBELista objListLin;
            Model.DocVenda dv = new Model.DocVenda();
            Model.LinhaDocVenda lindv = new Model.LinhaDocVenda();
            List<Model.LinhaDocVenda> listlindv = new List<Model.LinhaDocVenda>();

            if (PriEngine.InitializeCompany("BELAFLOR", "", "") == true)
            {
                 
                string st = "SELECT id, Entidade, Data, NumDoc, TotalMerc, Serie From CabecDoc where TipoDoc='ECL' and NumDoc='" + numdoc + "'";
                objListCab = PriEngine.Engine.Consulta(st);
                dv = new Model.DocVenda();
                dv.id = objListCab.Valor("id");
                dv.Entidade = objListCab.Valor("Entidade");
                dv.NumDoc = objListCab.Valor("NumDoc");
                dv.Data = objListCab.Valor("Data");
                dv.TotalMerc = objListCab.Valor("TotalMerc");
                dv.Serie = objListCab.Valor("Serie");
                objListLin = PriEngine.Engine.Consulta("SELECT idCabecDoc, Artigo, Descricao, Quantidade, Unidade, PrecUnit, Desconto1, TotalILiquido, PrecoLiquido from LinhasDoc where IdCabecDoc='" + dv.id + "' order By NumLinha");
                listlindv = new List<Model.LinhaDocVenda>();

                while (!objListLin.NoFim())
                {
                    lindv = new Model.LinhaDocVenda();
                    lindv.IdCabecDoc = objListLin.Valor("idCabecDoc");
                    lindv.CodArtigo = objListLin.Valor("Artigo");
                    lindv.DescArtigo = objListLin.Valor("Descricao");
                    lindv.Quantidade = objListLin.Valor("Quantidade");
                    lindv.Unidade = objListLin.Valor("Unidade");
                    lindv.Desconto = objListLin.Valor("Desconto1");
                    lindv.PrecoUnitario = objListLin.Valor("PrecUnit");
                    lindv.TotalILiquido = objListLin.Valor("TotalILiquido");
                    lindv.TotalLiquido = objListLin.Valor("PrecoLiquido");
                    listlindv.Add(lindv);
                    objListLin.Seguinte();
                }

                dv.LinhasDoc = listlindv;
                return dv;
            }
            return null;
        }

        public static List<Model.DocCompra> Encomendas_List_Compra()
        {
            ErpBS objMotor = new ErpBS();

            StdBELista objListCab;
            StdBELista objListLin;
            Model.DocCompra dv = new Model.DocCompra();
            List<Model.DocCompra> listdv = new List<Model.DocCompra>();
            Model.LinhaDocCompra lindv = new Model.LinhaDocCompra();
            List<Model.LinhaDocCompra> listlindv = new
            List<Model.LinhaDocCompra>();

            if (PriEngine.InitializeCompany("BELAFLOR", "", "") == true)
            {
                objListCab = PriEngine.Engine.Consulta("SELECT id, Fornecedores.Nome, DataDoc, NumDoc, TotalMerc, Serie FROM CabecCompras, Fornecedores WHERE TipoDoc='ECF' AND CabecCompras.Entidade = Fornecedores.Fornecedor");
                while (!objListCab.NoFim())
                {
                    dv = new Model.DocCompra();
                    dv.id = objListCab.Valor("id");
                    dv.Entidade = objListCab.Valor("Nome");
                    dv.NumDoc = objListCab.Valor("NumDoc");
                    dv.Data = objListCab.Valor("DataDoc");
                    dv.TotalMerc = objListCab.Valor("TotalMerc");
                    dv.Serie = objListCab.Valor("Serie");
                    //objListLin = PriEngine.Engine.Consulta("SELECT idCabecCompras, LinhasCompras.Artigo, LinhasCompras.Descricao, LinhasCompras.Quantidade, LinhasCompras.Unidade, LinhasCompras.PrecUnit, LinhasCompras.Desconto1, LinhasCompras.TotalILiquido, LinhasCompras.PrecoLiquido, CodBarras FROM LinhasCompras, Artigo WHERE idCabecCompras='" + dv.id + "' AND Artigo.Artigo = LinhasCompras.Artigo ORDER BY NumLinha");
                    /*objListLin = PriEngine.Engine.Consulta("SELECT idCabecCompras, LinhasCompras.Descricao, CodBarras, dbo.CabecCompras.NumDoc, dbo.LinhasCompras.NumLinha, dbo.LinhasCompras.Artigo, dbo.LinhasCompras.Quantidade, dbo.LinhasComprasStatus.EstadoTrans, dbo.LinhasComprasStatus.QuantTrans, dbo.LinhasCompras.Quantidade - dbo.LinhasComprasStatus.QuantTrans AS QtdPendente " +
                        "FROM Artigo, dbo.CabecCompras INNER JOIN dbo.LinhasCompras ON dbo.CabecCompras.Id = dbo.LinhasCompras.IdCabecCompras INNER JOIN " +
                        "dbo.LinhasComprasStatus ON dbo.LinhasCompras.Id = dbo.LinhasComprasStatus.IdLinhasCompras WHERE idCabecCompras='" + dv.id + "' AND (dbo.CabecCompras.TipoDoc = N'ECF') AND Artigo.Artigo = LinhasCompras.Artigo AND dbo.LinhasCompras.Quantidade > dbo.LinhasComprasStatus.QuantTrans  ORDER BY NumLinha");
                    */
                    objListLin = PriEngine.Engine.Consulta("WITH QtdReal AS (SELECT Artigo, NumDocExterno, SUM(Quantidade) AS QtdTotal FROM dbo.LinhasCompras GROUP BY NumDocExterno, Artigo) " +
                        "SELECT QtdReal.QtdTotal, idCabecCompras, Desconto1, PrecUnit, LinhasCompras.Descricao AS itemDesc, Armazens.Descricao,  Armazens.Armazem AS ArmazemID, CodBarras, dbo.CabecCompras.NumDoc, dbo.LinhasCompras.NumLinha, dbo.LinhasCompras.Artigo, dbo.LinhasCompras.Quantidade, dbo.LinhasComprasStatus.EstadoTrans, dbo.LinhasComprasStatus.QuantTrans, dbo.LinhasCompras.Quantidade - dbo.LinhasComprasStatus.QuantTrans AS QtdPendente  " +
                        "FROM QtdReal, " +
                        "Artigo, Armazens, dbo.CabecCompras INNER JOIN dbo.LinhasCompras ON dbo.CabecCompras.Id = dbo.LinhasCompras.IdCabecCompras INNER JOIN " +
                        "dbo.LinhasComprasStatus ON dbo.LinhasCompras.Id = dbo.LinhasComprasStatus.IdLinhasCompras WHERE " + "QtdReal.NumDocExterno = LinhasCompras.NumDocExterno AND QtdReal.Artigo = LinhasCompras.Artigo AND " +
                        "Armazens.Armazem = LinhasCompras.Armazem AND idCabecCompras='" + dv.id + "' AND (dbo.CabecCompras.TipoDoc = N'ECF') AND Artigo.Artigo = LinhasCompras.Artigo AND dbo.LinhasCompras.Quantidade > dbo.LinhasComprasStatus.QuantTrans AND QtdReal.QtdTotal > 0 ORDER BY NumLinha");
                
                    listlindv = new List<Model.LinhaDocCompra>();

                    while (!objListLin.NoFim())
                    {
                        lindv = new Model.LinhaDocCompra();
                        lindv.IdCabecDoc = objListLin.Valor("idCabecCompras");
                        lindv.CodArtigo = objListLin.Valor("Artigo");
                        lindv.DescArtigo = objListLin.Valor("itemDesc");
                        lindv.Quantidade = objListLin.Valor("QtdPendente");
                        lindv.CodBarras = objListLin.Valor("CodBarras");
                        lindv.QuantidadeAux = objListLin.Valor("QtdTotal");
                        lindv.Armazem = objListLin.Valor("Descricao");

                        listlindv.Add(lindv);
                        objListLin.Seguinte();
                    }

                    dv.LinhasDoc = listlindv;
                    listdv.Add(dv);
                    objListCab.Seguinte();
                }
            }

            return listdv;
        }

        public static Model.DocCompra Encomenda_Compra_Get(string numdoc)
        {
            ErpBS objMotor = new ErpBS();

            StdBELista objListCab;
            StdBELista objListLin;
            Model.DocCompra dv = new Model.DocCompra();
            Model.LinhaDocCompra lindv = new Model.LinhaDocCompra();
            List<Model.LinhaDocCompra> listlindv = new List<Model.LinhaDocCompra>();

            if (PriEngine.InitializeCompany("BELAFLOR", "", "") == true)
            {

                string st = "SELECT id, Fornecedores.Nome, DataDoc, NumDoc, NumDocExterno, TotalMerc, Serie, Entidade FROM CabecCompras, Fornecedores WHERE TipoDoc='ECF' AND CabecCompras.Entidade = Fornecedores.Fornecedor AND NumDoc='" + numdoc + "'";
                objListCab = PriEngine.Engine.Consulta(st);
                dv = new Model.DocCompra();
                dv.id = objListCab.Valor("id");
                dv.Entidade = objListCab.Valor("Nome");
                dv.EntidadeID = objListCab.Valor("Entidade");
                dv.NumDoc = objListCab.Valor("NumDoc");
                dv.NumDocExterno = objListCab.Valor("NumDocExterno");
                dv.Data = objListCab.Valor("DataDoc");
                dv.TotalMerc = objListCab.Valor("TotalMerc");
                dv.Serie = objListCab.Valor("Serie");
                //objListLin = PriEngine.Engine.Consulta("SELECT idCabecCompras, Artigo, NumLinha, LinhasCompras.Descricao AS itemDesc, Quantidade, Unidade, PrecUnit, Desconto1, TotalILiquido, PrecoLiquido, Armazens.Descricao FROM LinhasCompras, Armazens WHERE idCabecCompras='" + dv.id + "' AND Armazens.Armazem = LinhasCompras.Armazem ORDER BY NumLinha");
                objListLin = PriEngine.Engine.Consulta("WITH QtdReal AS (SELECT Artigo, NumDocExterno, SUM(Quantidade) AS QtdTotal FROM dbo.LinhasCompras GROUP BY NumDocExterno, Artigo) " +
                        "SELECT QtdReal.QtdTotal, idCabecCompras, Desconto1, PrecUnit, LinhasCompras.Descricao AS itemDesc, Armazens.Descricao,  Armazens.Armazem AS ArmazemID, CodBarras, dbo.CabecCompras.NumDoc, dbo.LinhasCompras.NumLinha, dbo.LinhasCompras.Artigo, dbo.LinhasCompras.Quantidade, dbo.LinhasComprasStatus.EstadoTrans, dbo.LinhasComprasStatus.QuantTrans, dbo.LinhasCompras.Quantidade - dbo.LinhasComprasStatus.QuantTrans AS QtdPendente  " +
                        "FROM QtdReal, " +
                        "Artigo, Armazens, dbo.CabecCompras INNER JOIN dbo.LinhasCompras ON dbo.CabecCompras.Id = dbo.LinhasCompras.IdCabecCompras INNER JOIN " +
                        "dbo.LinhasComprasStatus ON dbo.LinhasCompras.Id = dbo.LinhasComprasStatus.IdLinhasCompras WHERE " + "QtdReal.NumDocExterno = LinhasCompras.NumDocExterno AND QtdReal.Artigo = LinhasCompras.Artigo AND " +
                        "Armazens.Armazem = LinhasCompras.Armazem AND idCabecCompras='" + dv.id + "' AND (dbo.CabecCompras.TipoDoc = N'ECF') AND Artigo.Artigo = LinhasCompras.Artigo AND dbo.LinhasCompras.Quantidade > dbo.LinhasComprasStatus.QuantTrans AND QtdReal.QtdTotal > 0 ORDER BY NumLinha");
                listlindv = new List<Model.LinhaDocCompra>();

                while (!objListLin.NoFim())
                {
                    lindv = new Model.LinhaDocCompra();
                    lindv.IdCabecDoc = objListLin.Valor("idCabecCompras");
                    lindv.CodArtigo = objListLin.Valor("Artigo");
                    lindv.DescArtigo = objListLin.Valor("itemDesc");
                    lindv.Quantidade = objListLin.Valor("QtdPendente");
                    lindv.NumLinha = objListLin.Valor("NumLinha");
                    lindv.Armazem = objListLin.Valor("Descricao");
                    lindv.ArmazemID = objListLin.Valor("ArmazemID");
                    lindv.Desconto = objListLin.Valor("Desconto1");
                    lindv.PrecoUnitario = objListLin.Valor("PrecUnit");
                    lindv.QuantidadeAux = objListLin.Valor("QtdTotal");
                    listlindv.Add(lindv);
                    objListLin.Seguinte();
                }

                dv.LinhasDoc = listlindv;
                return dv;
            }
            return null;
        }

    }


}