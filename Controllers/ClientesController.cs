using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.Common;
using VideoClubALFA.Models;
using VideoClubALFA.Others.DDLs;

namespace VideoClubALFA.Controllers
{
   
    public class ClientesController : Controller
    {
        readonly string DBConnection = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
        // GET: Clientes
        public ActionResult Index()
        {
            ViewBag.TipoBonosSelectList = new SelectList(FillDDLs.GetBonosInfo(), "idBono", "descripcionBono");
            ViewBag.StatusSelectList = new SelectList(FillDDLs.GetEstatusTypes(), "Activo", "ActivoDescripcion");

            ViewBag.ClientesSelectList = new SelectList(FillDDLs.GetClientesInfo(), "idCliente", "numSocio");
            ViewBag.TipoTransaccionSelectList = new SelectList(FillDDLs.GetTipoTransaccionesInfo(), "idTipoTransaccion", "TipoTransaccion");
            ViewBag.PeliculasSelectList = new SelectList(FillDDLs.GetPeliculasInfo(), "idPelicula", "TituloPelicula");
            return View();
        }


        #region clientes
        public ActionResult ShowGridClientes()
        {
            List<Clientes> oListClientes= new List<Clientes>();
            try
            {
                DataTable dtQueryResult = new DataTable();
                DataTable dtQueryListResult = new DataTable();
                using (SqlConnection con = new SqlConnection(DBConnection))
                {
                    using (SqlCommand cmdlistaconsulta = new SqlCommand("vc_sp_Clientes", con))
                    {
                        cmdlistaconsulta.CommandType = CommandType.StoredProcedure;


                        using (SqlDataAdapter sdalista = new SqlDataAdapter(cmdlistaconsulta))
                        {
                            (sdalista).Fill(dtQueryListResult);
                            if (dtQueryListResult.Rows.Count > 0)
                            {

                                for (int i = 0; i < dtQueryListResult.Rows.Count; i++)
                                {
                                    Clientes clientesList = new Clientes();
                                    clientesList.IdCliente = Convert.ToInt32(dtQueryListResult.Rows[i]["idCliente"]);
                                    clientesList.NumSocio = dtQueryListResult.Rows[i]["numSocio"].ToString().Trim();
                                    clientesList.NombreCliente = dtQueryListResult.Rows[i]["NombreCliente"].ToString().Trim();
                                    clientesList.TelefonoCliente = dtQueryListResult.Rows[i]["telefonoCliente"].ToString().Trim();
                                    clientesList.EmailCliente = dtQueryListResult.Rows[i]["emailCliente"].ToString().Trim();
                                    clientesList.StatusCliente = Convert.ToBoolean(dtQueryListResult.Rows[i]["statusCliente"]);
                                    clientesList.DescripcionBono = dtQueryListResult.Rows[i]["descripcionBono"].ToString().Trim();
                                    clientesList.NumBonos = Convert.ToInt32(dtQueryListResult.Rows[i]["numBonos"]);
                                    clientesList.PorcentajeSancion = (decimal)dtQueryListResult.Rows[i]["porcentajeSancion"];
                                    clientesList.FG = Convert.ToDateTime(dtQueryListResult.Rows[i]["FG"]);

                                    oListClientes.Add(clientesList);
                                }
                                return Json(new { data = oListClientes }, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                return Json(new { data = "" }, JsonRequestBehavior.AllowGet);
                            }
                        }
                    }
                }
            }

            catch (SqlException ex)
            {
                return Json(new { data = "Ocurrio un error: " + ex.Message + ", al consultar los clientes de la empresa." }, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult SaveCliente(Clientes modelCliente)
        {
            try
            {
                DataTable dtQueryResult = new DataTable();
                DataTable dtQueryListResult = new DataTable();

                using (SqlConnection con = new SqlConnection(DBConnection))
                {
                  
                    //Alta
                    SqlCommand cmdclienteregistration = new SqlCommand("vc_sp_ClienteAlta", con);
                    cmdclienteregistration.CommandType = CommandType.StoredProcedure;
                   
                    //Edicion
                    SqlCommand cmdclienteedit = new SqlCommand("vc_sp_ClienteEdicion", con);
                    cmdclienteedit.CommandType = CommandType.StoredProcedure;

                   // Assign value to parameters
                    SqlParameter inputparam01 = new SqlParameter("@idCliente", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = modelCliente.IdCliente
                    };
                    SqlParameter inputparam02 = new SqlParameter("@numSocio", SqlDbType.VarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = modelCliente.NumSocio.Trim()
                    };
                    SqlParameter inputparam03 = new SqlParameter("@nombreCliente", SqlDbType.VarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = modelCliente.NombreCliente.Trim()
                    };
                    SqlParameter inputparam04 = new SqlParameter("@apellidoPaternoCliente", SqlDbType.VarChar)
                    {
                        Direction = ParameterDirection.Input,
                        //Value = model.Logo
                        Value = modelCliente.ApellidoPaternoCliente.Trim()
                    };
                    SqlParameter inputparam05 = new SqlParameter("@apellidoMaternoCliente", SqlDbType.VarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = modelCliente.ApellidoMaternoCliente.ToUpper().Trim()
                    };
                    SqlParameter inputparam06 = new SqlParameter("@telefonoCliente", SqlDbType.VarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = modelCliente.TelefonoCliente.Trim()
                    };
                    SqlParameter inputparam07 = new SqlParameter("@emailCliente", SqlDbType.VarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = modelCliente.EmailCliente.Trim()
                    };
                    SqlParameter inputparam08 = new SqlParameter("@statusCliente", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Input,
                        Value = modelCliente.StatusCliente
                    };
                    SqlParameter inputparam09 = new SqlParameter("@idBonos", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = modelCliente.IdBonos
                    };
                    SqlParameter inputparam10 = new SqlParameter("@numBonos", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = modelCliente.NumBonos
                    };
                    SqlParameter inputparam11 = new SqlParameter("@porcentajeSancion", SqlDbType.Decimal)
                    {
                        Direction = ParameterDirection.Input,
                        Value = modelCliente.PorcentajeSancion
                    };



                    if (modelCliente.IdCliente == null)
                    {
                        //Insert parameters for Registration                        
                        cmdclienteregistration.Parameters.Add(inputparam02);
                        cmdclienteregistration.Parameters.Add(inputparam03);
                        cmdclienteregistration.Parameters.Add(inputparam04);                        
                        cmdclienteregistration.Parameters.Add(inputparam05);
                        cmdclienteregistration.Parameters.Add(inputparam06);
                        cmdclienteregistration.Parameters.Add(inputparam07);
                        cmdclienteregistration.Parameters.Add(inputparam08);
                        cmdclienteregistration.Parameters.Add(inputparam09);
                        cmdclienteregistration.Parameters.Add(inputparam10);
                        cmdclienteregistration.Parameters.Add(inputparam11);

                        con.Open();
                        cmdclienteregistration.ExecuteNonQuery();                      
                        con.Close();                                             
                        ModelState.Clear();
                        return Json(new { }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        //Insert parameters for Update
                        cmdclienteedit.Parameters.Add(inputparam01);
                        cmdclienteedit.Parameters.Add(inputparam02);
                        cmdclienteedit.Parameters.Add(inputparam03);                      
                        cmdclienteedit.Parameters.Add(inputparam04);
                        cmdclienteedit.Parameters.Add(inputparam05);
                        cmdclienteedit.Parameters.Add(inputparam06);
                        cmdclienteedit.Parameters.Add(inputparam07);
                        cmdclienteedit.Parameters.Add(inputparam08);
                        cmdclienteedit.Parameters.Add(inputparam09);
                        cmdclienteedit.Parameters.Add(inputparam10);
                        cmdclienteedit.Parameters.Add(inputparam11);

                        con.Open();
                        cmdclienteedit.ExecuteNonQuery();
                        con.Close();

                        ModelState.Clear();
                        return Json(new { }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (SqlException ex)
            {
                return Json(new {ex }, JsonRequestBehavior.AllowGet);
            }
        }
      


      
        public JsonResult GetCliente(int idCliente)
        {
            try
            {
                DataTable dtQueryResult = new DataTable();
                DataTable dtQueryListResult = new DataTable();

                ModelState.Clear();

                using (SqlConnection con = new SqlConnection(DBConnection))
                {
                    Clientes cliente = new Clientes();
                    using (SqlCommand cmdclienteconsulta = new SqlCommand("vc_sp_ClienteGet", con))
                    {
                        cmdclienteconsulta.CommandType = CommandType.StoredProcedure;
                        SqlParameter inputparam01 = new SqlParameter("@idCliente", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Input,
                            Value = idCliente
                        };
                        cmdclienteconsulta.Parameters.Add(inputparam01);
                        using (SqlDataAdapter sdalista = new SqlDataAdapter(cmdclienteconsulta))
                        {
                            (sdalista).Fill(dtQueryListResult);
                            if (dtQueryListResult.Rows.Count > 0)
                            {
                                cliente.IdCliente = Convert.ToInt32(dtQueryListResult.Rows[0]["idCliente"]);
                                cliente.NumSocio = dtQueryListResult.Rows[0]["numSocio"].ToString().Trim();
                                cliente.NombreCliente = dtQueryListResult.Rows[0]["NombreCliente"].ToString().Trim();
                                cliente.ApellidoPaternoCliente = dtQueryListResult.Rows[0]["apellidoPaternoCliente"].ToString().Trim();
                                cliente.ApellidoMaternoCliente = dtQueryListResult.Rows[0]["apellidoMaternoCliente"].ToString().Trim();
                                cliente.TelefonoCliente = dtQueryListResult.Rows[0]["telefonoCliente"].ToString().Trim();
                                cliente.EmailCliente = dtQueryListResult.Rows[0]["emailCliente"].ToString().Trim();
                                cliente.StatusCliente = Convert.ToBoolean(dtQueryListResult.Rows[0]["statusCliente"]);                             
                               
                                cliente.IdBonos = Convert.ToInt32(dtQueryListResult.Rows[0]["idBonos"]);
                                cliente.DescripcionBono = dtQueryListResult.Rows[0]["descripcionBono"].ToString().Trim();                               
                                cliente.NumBonos = Convert.ToInt32(dtQueryListResult.Rows[0]["numBonos"]);
                                cliente.PorcentajeSancion = (decimal)dtQueryListResult.Rows[0]["porcentajeSancion"];
                                cliente.FG = Convert.ToDateTime(dtQueryListResult.Rows[0]["FG"]);                               
                            }

                            return Json(new { cliente }, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {              
                return Json(new { data = "Ocurrio un error: " + ex.Message + ", al consultar los datos de la empresa." }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult DeleteCliente(int idCliente)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DBConnection))
                {
                    using (SqlCommand cmdclientebaja = new SqlCommand("vc_sp_ClienteDelete", con))
                    {
                        cmdclientebaja.CommandType = CommandType.StoredProcedure;
                        SqlParameter inputparam01 = new SqlParameter("@idCliente", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Input,
                            Value = idCliente
                        };
                        cmdclientebaja.Parameters.Add(inputparam01);
                        con.Open();
                        cmdclientebaja.ExecuteNonQuery();
                        con.Close();
                      
                        ModelState.Clear();
                        return Json(new { }, JsonRequestBehavior.AllowGet);
                    }
                }
            }

            catch (SqlException ex)
            {              
                return Json(new { data = ex }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion CLIENTES


        #region PEDIDOSCLIENTES
        public ActionResult ShowGridPedidosClientes()
        {
            List<PedidosClientes> oListPedidosClientes = new List<PedidosClientes>();
            try
            {
                DataTable dtQueryResult = new DataTable();
                DataTable dtQueryListResult = new DataTable();
                using (SqlConnection con = new SqlConnection(DBConnection))
                {
                    using (SqlCommand cmdlistaconsulta = new SqlCommand("vc_sp_PedidosClientes", con))
                    {
                        cmdlistaconsulta.CommandType = CommandType.StoredProcedure;


                        using (SqlDataAdapter sdalista = new SqlDataAdapter(cmdlistaconsulta))
                        {
                            (sdalista).Fill(dtQueryListResult);
                            if (dtQueryListResult.Rows.Count > 0)
                            {

                                for (int i = 0; i < dtQueryListResult.Rows.Count; i++)
                                {
                                    PedidosClientes pedidosclientesList = new PedidosClientes();
                                    pedidosclientesList.IdPedidoCliente = Convert.ToInt32(dtQueryListResult.Rows[i]["idPedidoCliente"]);
                                    pedidosclientesList.NumSocio = dtQueryListResult.Rows[i]["numSocio"].ToString().Trim();
                                    pedidosclientesList.TituloPelicula = dtQueryListResult.Rows[i]["tituloPelicula"].ToString().Trim();
                                    pedidosclientesList.ClasificacionPelicula = dtQueryListResult.Rows[i]["clasificacionPelicula"].ToString().Trim();
                                    pedidosclientesList.FolioPelicula = dtQueryListResult.Rows[i]["folioPelicula"].ToString().Trim();
                                    pedidosclientesList.TipoTransaccion = dtQueryListResult.Rows[i]["tipoTransaccion"].ToString().Trim();
                                    pedidosclientesList.CantidadPeliculas = Convert.ToInt32(dtQueryListResult.Rows[i]["cantidadPeliculas"]);
                                    pedidosclientesList.FechaInicio = Convert.ToDateTime(dtQueryListResult.Rows[i]["fechaInicio"]);
                                    pedidosclientesList.FechaFinalizacion = Convert.ToDateTime(dtQueryListResult.Rows[i]["fechaFinalizacion"]);
                                    pedidosclientesList.TotalPeliculas = (decimal)dtQueryListResult.Rows[i]["totalPeliculas"];
                                    pedidosclientesList.DescripcionStatusPedido =dtQueryListResult.Rows[i]["descripcionStatusPedido"].ToString().Trim();
                                    pedidosclientesList.FG = Convert.ToDateTime(dtQueryListResult.Rows[i]["FG"]);

                                    oListPedidosClientes.Add(pedidosclientesList);
                                }
                                return Json(new { data = oListPedidosClientes }, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                return Json(new { data = "" }, JsonRequestBehavior.AllowGet);
                            }
                        }
                    }
                }
            }

            catch (SqlException ex)
            {
                return Json(new { data = "Ocurrio un error: " + ex.Message + ", al consultar los pedidos de clientes de la empresa." }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult SavePedidoCliente(PedidosClientes modelPedidoCliente)
        {
            try
            {
                DataTable dtQueryResult = new DataTable();
                DataTable dtQueryListResult = new DataTable();

                DateTime todayDate = DateTime.Today.Date;
                if(modelPedidoCliente.IdTipoTransaccion == 2 && todayDate.Date > modelPedidoCliente.FechaInicio.Date.AddDays(modelPedidoCliente.DiasBono))
                {
                    modelPedidoCliente.IdStatusPedido = 2;
                }
                else if (modelPedidoCliente.IdTipoTransaccion == 2 && todayDate.Date <= modelPedidoCliente.FechaInicio.Date.AddDays(modelPedidoCliente.DiasBono))
                {
                    modelPedidoCliente.IdStatusPedido = 1;
                }
                else
                {
                    modelPedidoCliente.IdStatusPedido = 3;
                }

                    using (SqlConnection con = new SqlConnection(DBConnection))
                {

                    //Alta
                    SqlCommand cmdpedidoclienteregistration = new SqlCommand("vc_sp_PedidoClienteAlta", con);
                    cmdpedidoclienteregistration.CommandType = CommandType.StoredProcedure;

                    //Edicion
                    SqlCommand cmdpedidoclienteedit = new SqlCommand("vc_sp_PedidoClienteEdicion", con);
                    cmdpedidoclienteedit.CommandType = CommandType.StoredProcedure;

                    // Assign value to parameters
                    SqlParameter inputparam01 = new SqlParameter("@idPedidoCliente", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = modelPedidoCliente.IdPedidoCliente
                    };
                    SqlParameter inputparam02 = new SqlParameter("@idCliente", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = modelPedidoCliente.IdCliente_Pedido
                    };
                    SqlParameter inputparam03 = new SqlParameter("@idTipoTransaccion", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = modelPedidoCliente.IdTipoTransaccion
                    };
                    SqlParameter inputparam04 = new SqlParameter("@idPelicula", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,                       
                        Value = modelPedidoCliente.IdPelicula
                    };
                    SqlParameter inputparam05 = new SqlParameter("@cantidadPeliculas", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = modelPedidoCliente.CantidadPeliculas
                    };
                    SqlParameter inputparam06 = new SqlParameter("@fechaInicio", SqlDbType.Date)
                    {
                        Direction = ParameterDirection.Input,
                        Value = modelPedidoCliente.FechaInicio.Date
                    };
                    SqlParameter inputparam07 = new SqlParameter("@fechaFinalizacion", SqlDbType.Date)
                    {
                        Direction = ParameterDirection.Input,
                        Value = modelPedidoCliente.FechaInicio.Date.AddDays(modelPedidoCliente.DiasBono)
                    };
                    SqlParameter inputparam08 = new SqlParameter("@totalPeliculas", SqlDbType.Decimal)
                    {
                        Direction = ParameterDirection.Input,
                        Value = modelPedidoCliente.TotalPeliculas
                    };
                    SqlParameter inputparam09 = new SqlParameter("@idStatusPedido", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = modelPedidoCliente.IdStatusPedido
                    };

                    if (modelPedidoCliente.IdPedidoCliente == null)
                    {
                        //Insert parameters for Registration                        
                        cmdpedidoclienteregistration.Parameters.Add(inputparam02);
                        cmdpedidoclienteregistration.Parameters.Add(inputparam03);
                        cmdpedidoclienteregistration.Parameters.Add(inputparam04);
                        cmdpedidoclienteregistration.Parameters.Add(inputparam05);
                        cmdpedidoclienteregistration.Parameters.Add(inputparam06);
                        cmdpedidoclienteregistration.Parameters.Add(inputparam07);
                        cmdpedidoclienteregistration.Parameters.Add(inputparam08);
                        cmdpedidoclienteregistration.Parameters.Add(inputparam09);

                        con.Open();
                        cmdpedidoclienteregistration.ExecuteNonQuery();
                        con.Close();
                        ModelState.Clear();
                        return Json(new { }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        //Insert parameters for Update
                        cmdpedidoclienteedit.Parameters.Add(inputparam01);
                        cmdpedidoclienteedit.Parameters.Add(inputparam02);
                        cmdpedidoclienteedit.Parameters.Add(inputparam03);
                        cmdpedidoclienteedit.Parameters.Add(inputparam04);
                        cmdpedidoclienteedit.Parameters.Add(inputparam05);
                        cmdpedidoclienteedit.Parameters.Add(inputparam06);
                        cmdpedidoclienteedit.Parameters.Add(inputparam07);
                        cmdpedidoclienteedit.Parameters.Add(inputparam08);
                        cmdpedidoclienteedit.Parameters.Add(inputparam09);

                        con.Open();
                        cmdpedidoclienteedit.ExecuteNonQuery();
                        con.Close();

                        ModelState.Clear();
                        return Json(new { }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (SqlException ex)
            {
                return Json(new { ex }, JsonRequestBehavior.AllowGet);
            }
        }




        public JsonResult GetPedidoCliente(int idPedidoCliente)
        {
            try
            {
                DataTable dtQueryResult = new DataTable();
                DataTable dtQueryListResult = new DataTable();

                ModelState.Clear();

                using (SqlConnection con = new SqlConnection(DBConnection))
                {
                    PedidosClientes pedidoscliente = new PedidosClientes();
                    using (SqlCommand cmdclienteconsulta = new SqlCommand("vc_sp_PedidoClienteGet", con))
                    {
                        cmdclienteconsulta.CommandType = CommandType.StoredProcedure;
                        SqlParameter inputparam01 = new SqlParameter("@idPedidoCliente", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Input,
                            Value = idPedidoCliente
                        };
                        cmdclienteconsulta.Parameters.Add(inputparam01);
                        using (SqlDataAdapter sdalista = new SqlDataAdapter(cmdclienteconsulta))
                        {
                            (sdalista).Fill(dtQueryListResult);
                            if (dtQueryListResult.Rows.Count > 0)
                            {
                                pedidoscliente.IdPedidoCliente = Convert.ToInt32(dtQueryListResult.Rows[0]["idPedidoCliente"]);
                                pedidoscliente.IdCliente = Convert.ToInt32(dtQueryListResult.Rows[0]["IdCliente"]);
                                pedidoscliente.NumSocio = dtQueryListResult.Rows[0]["numSocio"].ToString().Trim();
                                pedidoscliente.TituloPelicula = dtQueryListResult.Rows[0]["tituloPelicula"].ToString().Trim();
                                pedidoscliente.ClasificacionPelicula = dtQueryListResult.Rows[0]["clasificacionPelicula"].ToString().Trim();
                                pedidoscliente.FolioPelicula = dtQueryListResult.Rows[0]["folioPelicula"].ToString().Trim();
                                pedidoscliente.TipoTransaccion = dtQueryListResult.Rows[0]["tipoTransaccion"].ToString().Trim();
                                pedidoscliente.CantidadPeliculas = Convert.ToInt32(dtQueryListResult.Rows[0]["cantidadPeliculas"]);
                                pedidoscliente.FechaInicio = Convert.ToDateTime(dtQueryListResult.Rows[0]["fechaInicio"]);
                                pedidoscliente.FechaFinalizacion = Convert.ToDateTime(dtQueryListResult.Rows[0]["fechaFinalizacion"]);
                                pedidoscliente.TotalPeliculas = (decimal)dtQueryListResult.Rows[0]["totalPeliculas"];
                                pedidoscliente.DescripcionStatusPedido = dtQueryListResult.Rows[0]["descripcionStatusPedido"].ToString().Trim();
                                pedidoscliente.FG = Convert.ToDateTime(dtQueryListResult.Rows[0]["FG"]);
                            }
                            return Json(new { pedidoscliente }, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                return Json(new { data = "Ocurrio un error: " + ex.Message + ", al consultar los datos de la empresa." }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult DeletePedidoCliente(int idPedidoCliente)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DBConnection))
                {
                    using (SqlCommand cmdclientebaja = new SqlCommand("vc_sp_PedidoClienteDelete", con))
                    {
                        cmdclientebaja.CommandType = CommandType.StoredProcedure;
                        SqlParameter inputparam01 = new SqlParameter("@idPedidoCliente", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Input,
                            Value = idPedidoCliente
                        };
                        cmdclientebaja.Parameters.Add(inputparam01);
                        con.Open();
                        cmdclientebaja.ExecuteNonQuery();
                        con.Close();

                        ModelState.Clear();
                        return Json(new { }, JsonRequestBehavior.AllowGet);
                    }
                }
            }

            catch (SqlException ex)
            {
                return Json(new { data = ex }, JsonRequestBehavior.AllowGet);
            }
        }



        public JsonResult GetClienteInfo(int idCliente,DateTime fechaStart)
        {
            List<Clientes> oLstInfoCliente = new List<Clientes>();
            try
            {
                DataTable dtQueryResult = new DataTable();
                DataTable dtQueryListResult = new DataTable();
                using (SqlConnection con = new SqlConnection(DBConnection))
                {
                    using (SqlCommand cmdclientesinfoconsulta = new SqlCommand("vc_sp_ClienteInfoObtener", con))
                    {
                        cmdclientesinfoconsulta.CommandType = CommandType.StoredProcedure;
                        SqlParameter inputparam01 = new SqlParameter("@idCliente", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Input,
                            Value = idCliente
                        };
                        cmdclientesinfoconsulta.Parameters.Add(inputparam01);
                        using (SqlDataAdapter sdalista = new SqlDataAdapter(cmdclientesinfoconsulta))
                        {
                            (sdalista).Fill(dtQueryListResult);
                            if (dtQueryListResult.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtQueryListResult.Rows.Count; i++)
                                {
                                    Clientes infoCliente = new Clientes();
                                    infoCliente.IdCliente = Convert.ToInt32(dtQueryListResult.Rows[i]["idCliente"]);
                                    infoCliente.DiasBono = Convert.ToInt32(dtQueryListResult.Rows[i]["diasBono"].ToString());
                                    oLstInfoCliente.Add(infoCliente);
                                }

                            }
                            return Json(new { oLstInfoCliente }, JsonRequestBehavior.AllowGet);                           
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                return Json(new { }, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult GetPeliculaInfo(int idPelicula)
        {
            List<Peliculas> oLstInfoPelicula = new List<Peliculas>();
            try
            {
                DataTable dtQueryResult = new DataTable();
                DataTable dtQueryListResult = new DataTable();
                using (SqlConnection con = new SqlConnection(DBConnection))
                {
                    using (SqlCommand cmdpeliculainfoconsulta = new SqlCommand("vc_sp_PeliculaInfoObtener", con))
                    {
                        cmdpeliculainfoconsulta.CommandType = CommandType.StoredProcedure;

                        SqlParameter inputparam01 = new SqlParameter("@idPelicula", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Input,
                            Value = idPelicula
                        };
                        cmdpeliculainfoconsulta.Parameters.Add(inputparam01);
                        using (SqlDataAdapter sdalista = new SqlDataAdapter(cmdpeliculainfoconsulta))
                        {
                            (sdalista).Fill(dtQueryListResult);
                            if (dtQueryListResult.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtQueryListResult.Rows.Count; i++)
                                {
                                    Peliculas infoPelicula = new Peliculas();
                                    infoPelicula.IdPelicula = Convert.ToInt32(dtQueryListResult.Rows[i]["idPelicula"]);
                                    infoPelicula.TituloPelicula = dtQueryListResult.Rows[i]["TituloPelicula"].ToString().Trim();
                                    infoPelicula.PrecioXDia = Convert.ToDecimal(dtQueryListResult.Rows[i]["precioXDia"]);
                                    oLstInfoPelicula.Add(infoPelicula);
                                }

                            }
                            return Json(new { oLstInfoPelicula }, JsonRequestBehavior.AllowGet);
                            
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                return Json(new { }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion PEDIDOSCLIENTES

    }
}