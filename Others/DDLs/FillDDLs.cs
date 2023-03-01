using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Mvc;
using VideoClubALFA.Models;
using System.Net.NetworkInformation;

namespace VideoClubALFA.Others.DDLs
{
    public class FillDDLs : Controller
    {
        /* Conexion a SQL a travez de la cadena de conexion en WEB.CONFIG*/
        readonly static string DBConnection = ConfigurationManager.ConnectionStrings["Model1"].ConnectionString;

        public static List<Bonos> GetBonosInfo()
        {
            List<Bonos> oLstInfoBonos = new List<Bonos>();
            try
            {
                DataTable dtQueryResult = new DataTable();
                DataTable dtQueryListResult = new DataTable();
                using (SqlConnection con = new SqlConnection(DBConnection))
                {
                    using (SqlCommand cmdbonosinfoconsulta = new SqlCommand("vc_sp_BonosInfoObtener", con))
                    {
                        cmdbonosinfoconsulta.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter sdalista = new SqlDataAdapter(cmdbonosinfoconsulta))
                        {
                            (sdalista).Fill(dtQueryListResult);
                            if (dtQueryListResult.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtQueryListResult.Rows.Count; i++)
                                {
                                    Bonos infoBanco = new Bonos();
                                    infoBanco.IdBono = Convert.ToInt32(dtQueryListResult.Rows[i]["idBono"]);
                                    infoBanco.DescripcionBono = dtQueryListResult.Rows[i]["descripcionBono"].ToString();                                   
                                    oLstInfoBonos.Add(infoBanco);
                                }

                            }
                            return oLstInfoBonos;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                return oLstInfoBonos;
            }
        }

        public static List<Estatus> GetEstatusTypes()
        {
            var Activos = new List<Estatus>();
            Activos.Add(new Estatus() { Activo = true, ActivoDescripcion = "Activo" });
            Activos.Add(new Estatus() { Inactivo = false, InactivoDescripcion = "Inactivo" });
            return Activos;
        }

        public static List<Clientes> GetClientesInfo()
        {
            List<Clientes> oLstInfoClientes = new List<Clientes>();
            try
            {
                DataTable dtQueryResult = new DataTable();
                DataTable dtQueryListResult = new DataTable();
                using (SqlConnection con = new SqlConnection(DBConnection))
                {
                    using (SqlCommand cmdbonosinfoconsulta = new SqlCommand("vc_sp_ClientesInfoObtener", con))
                    {
                        cmdbonosinfoconsulta.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter sdalista = new SqlDataAdapter(cmdbonosinfoconsulta))
                        {
                            (sdalista).Fill(dtQueryListResult);
                            if (dtQueryListResult.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtQueryListResult.Rows.Count; i++)
                                {
                                    Clientes infoClientes = new Clientes();
                                    infoClientes.IdCliente = Convert.ToInt32(dtQueryListResult.Rows[i]["idCliente"]);
                                    infoClientes.NumSocio = dtQueryListResult.Rows[i]["numSocio"].ToString().Trim();
                                    oLstInfoClientes.Add(infoClientes);
                                }

                            }
                            return oLstInfoClientes;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                return oLstInfoClientes;
            }
        }


        public static List<TipoTransacciones> GetTipoTransaccionesInfo()
        {
            List<TipoTransacciones> oLstInfoTipoTransacciones = new List<TipoTransacciones>();
            try
            {
                DataTable dtQueryResult = new DataTable();
                DataTable dtQueryListResult = new DataTable();
                using (SqlConnection con = new SqlConnection(DBConnection))
                {
                    using (SqlCommand cmdbonosinfoconsulta = new SqlCommand("vc_sp_TipoTransaccionesInfoObtener", con))
                    {
                        cmdbonosinfoconsulta.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter sdalista = new SqlDataAdapter(cmdbonosinfoconsulta))
                        {
                            (sdalista).Fill(dtQueryListResult);
                            if (dtQueryListResult.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtQueryListResult.Rows.Count; i++)
                                {
                                    TipoTransacciones infoTipoTransaccion = new TipoTransacciones();
                                    infoTipoTransaccion.IdTipoTransaccion = Convert.ToInt32(dtQueryListResult.Rows[i]["idTipoTransaccion"]);
                                    infoTipoTransaccion.TipoTransaccion = dtQueryListResult.Rows[i]["TipoTransaccion"].ToString().Trim();
                                    oLstInfoTipoTransacciones.Add(infoTipoTransaccion);
                                }

                            }
                            return oLstInfoTipoTransacciones;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                return oLstInfoTipoTransacciones;
            }
        }


        public static List<Peliculas> GetPeliculasInfo()
        {
            List<Peliculas> oLstInfoPeliculas = new List<Peliculas>();
            try
            {
                DataTable dtQueryResult = new DataTable();
                DataTable dtQueryListResult = new DataTable();
                using (SqlConnection con = new SqlConnection(DBConnection))
                {
                    using (SqlCommand cmdbonosinfoconsulta = new SqlCommand("vc_sp_PeliculasInfoObtener", con))
                    {
                        cmdbonosinfoconsulta.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter sdalista = new SqlDataAdapter(cmdbonosinfoconsulta))
                        {
                            (sdalista).Fill(dtQueryListResult);
                            if (dtQueryListResult.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtQueryListResult.Rows.Count; i++)
                                {
                                    Peliculas infoPeliculas = new Peliculas();
                                    infoPeliculas.IdPelicula = Convert.ToInt32(dtQueryListResult.Rows[i]["idPelicula"]);
                                    infoPeliculas.TituloPelicula = dtQueryListResult.Rows[i]["TituloPelicula"].ToString().Trim();
                                    oLstInfoPeliculas.Add(infoPeliculas);
                                }

                            }
                            return oLstInfoPeliculas;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                return oLstInfoPeliculas;
            }
        }


       

    }
}