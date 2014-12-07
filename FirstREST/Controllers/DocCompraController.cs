﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstREST.Lib_Primavera.Model;

namespace FirstREST.Controllers
{
    public class DocCompraController : ApiController
    {

        //GET api/docCompra
        public IEnumerable<Lib_Primavera.Model.DocCompra> Get()
        {
            //return Lib_Primavera.Comercial.VGR_List();
            return Lib_Primavera.Comercial.Encomendas_List_Compra();
        }

        public Lib_Primavera.Model.DocCompra Get(string id)
        {
            Lib_Primavera.Model.DocCompra DocCompra = Lib_Primavera.Comercial.Encomenda_Compra_Get(id);
            if (DocCompra == null)
            {
                throw new HttpResponseException(
                        Request.CreateResponse(HttpStatusCode.NotFound));

            }
            else
            {
                return DocCompra;
            }
        }


        public HttpResponseMessage Post(Lib_Primavera.Model.DocCompra dc)
        {
            Lib_Primavera.Model.RespostaErro erro = new Lib_Primavera.Model.RespostaErro();
            erro = Lib_Primavera.Comercial.VGR_New(dc);

            if (erro.Erro == 0)
            {
                var response = Request.CreateResponse(
                   HttpStatusCode.Created, dc.id);
                string uri = Url.Link("DefaultApi", new { DocId = dc.id });
                response.Headers.Location = new Uri(uri);
                return response;
            }

            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

        }

    }
}
