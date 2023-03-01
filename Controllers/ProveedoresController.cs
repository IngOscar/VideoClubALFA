using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoClubALFA.Models;

namespace VideoClubALFA.Controllers
{
    public class ProveedoresController : Controller
    {
        readonly string DBConnection = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;
        // GET: Proveedores
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ShowGridTransacciones()
        {
            List<Transacciones> oListTransaccionesEmpresa = new List<Transacciones>();
            try
            {
                DataTable dtQueryResult = new DataTable();
                DataTable dtQueryListResult = new DataTable();
                using (SqlConnection con = new SqlConnection(DBConnection))
                {
                    using (SqlCommand cmdlistaconsulta = new SqlCommand("vc_sp_Transacciones", con))
                    {
                        cmdlistaconsulta.CommandType = CommandType.StoredProcedure;


                        using (SqlDataAdapter sdalista = new SqlDataAdapter(cmdlistaconsulta))
                        {
                            (sdalista).Fill(dtQueryListResult);
                            if (dtQueryListResult.Rows.Count > 0)
                            {

                                for (int i = 0; i < dtQueryListResult.Rows.Count; i++)
                                {
                                    Transacciones transaccionesList = new Transacciones();
                                    transaccionesList.IdTransaccion = Convert.ToInt32(dtQueryListResult.Rows[i]["idTransaccion"]);
                                    transaccionesList.IdPedidoCliente = Convert.ToInt32(dtQueryListResult.Rows[i]["idPedidoCliente"]);
                                    transaccionesList.IdPedidoProveedor = Convert.ToInt32(dtQueryListResult.Rows[i]["idPedidoProveedor"]);
                                    transaccionesList.TipoTransaccionCliente = dtQueryListResult.Rows[i]["tipoTransaccionCliente"].ToString().Trim();
                                    transaccionesList.TipoTransaccionProveedor = dtQueryListResult.Rows[i]["tipoTransaccionProveedor"].ToString().Trim();
                                    transaccionesList.NombreCliente = dtQueryListResult.Rows[i]["NombreCliente"].ToString().Trim();
                                    transaccionesList.NombreProveedor = dtQueryListResult.Rows[i]["tombreProveedor"].ToString().Trim();
                                    transaccionesList.TotalTransaccion = (decimal)dtQueryListResult.Rows[i]["totalTransaccion"];

                                    oListTransaccionesEmpresa.Add(transaccionesList);
                                }
                                return Json(new { data = oListTransaccionesEmpresa }, JsonRequestBehavior.AllowGet);
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
                return Json(new { data = "Ocurrio un error: " + ex.Message + ", al consultar las transacciones de la empresa." }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}