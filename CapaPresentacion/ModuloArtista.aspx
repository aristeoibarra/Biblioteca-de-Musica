﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ModuloArtista.aspx.cs" Inherits="CapaPresentacion.ModuloArtista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App/Styles/Main.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div id="fila1" class="row mt-2 ">
            <%--9697a2--%> <%--#3c7a83--%>
            <div class="mb-1 rounded col-12 col-sm-12 col-md-5 col-lg-5" style="background-color: #d9d9d9; height: 260px;">
                <div class="mt-2 mt-sm-2 mt-md-2">
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text border border-info">
                                <asp:Label ID="LbBuscar" Style="font-weight: bold;" runat="server" Text="Buscar :" Width="90px" />
                            </span>
                        </div>
                        <asp:TextBox ID="txtBuscarArtista" CssClass="form-control border border-info" runat="server" />
                    </div>


                    <div id="btnTabBuscar" class="d-flex justify-content-end">
                        <asp:Button ID="btnBusarArtista" CssClass="btn btn-info" Height="36px" Width="114px" runat="server" Text="Buscar" OnClick="btnBusarArtista_Click" />
                    </div>
                </div>
            </div>

            <div class="mb-1  rounded col-12 col-sm-12 col-md-7 col-lg-7" style="border-left: 3px solid White; background-color: #d9d9d9; height: 260px;">

                <div id="scroll" class="scrolling-table-container mt-2 mt-sm-2 mt-md-2" style="height: 220px;">
                    <asp:GridView ID="gvDatosArtista" ShowHeader="True" Width="100%" CssClass=" table-hover table-striped" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvDatosArtista_SelectedIndexChanged">
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle CssClass="text-white bg-dark" HorizontalAlign="Center" BorderStyle="Groove" BorderColor="black" />
                        <RowStyle CssClass="table-light" HorizontalAlign="Center" BorderStyle="Groove" BorderColor="black" />
                        <SelectedRowStyle Font-Bold="True" ForeColor="black" />
                    </asp:GridView>
                </div>

                <div id="lbTotalGenero">
                    <asp:Label ID="lbTotalRegistro" Font-Bold="true" CssClass="mb-1 mt-1 d-flex justify-content-center" runat="server"></asp:Label>
                </div>

                <div id="padreLogoData" class="container">
                    <img runat="server" style="margin-top: 27px; width: 330px; height: 200px;"
                        src="App/Images/Cassete.png" />
                </div>

            </div>
        </div>

        <div id="row" class="row mb-3">
            <div id="colum1" class="pl-2 mb-1 rounded col-12 col-sm-12 col-md-5 col-lg-5" style="background-color: #d9d9d9; height: auto;">
                <div class="mt-3 mt-sm-3 mt-md-3">
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text border-info">
                                <asp:Label ID="Label1" runat="server" Style="font-weight: bold;" Text="Artista :" Width="90px" />
                            </span>
                        </div>
                        <asp:TextBox ID="txtArtista" placeholder="INGRESA NOMBRE DEL ARTISTA" CssClass="form-control border-info" runat="server" />
                    </div>
                    <div style="margin-top: 10px; margin-bottom: 10px;" class="d-flex justify-content-center">
                        <asp:Button ID="btnInsertarArtista" CssClass="btn btn-success" runat="server" Text="Insertar" Height="36px" Width="114px" OnClick="btnInsertarArtista_Click" />
                        <asp:Button ID="BtnNuevoArtista" CssClass="btn btn-success border-left" runat="server" Text="Nuevo" Height="36px" Width="114px" OnClick="BtnNuevoArtista_Click" Visible="False" />
                        <asp:Button ID="btnActualizarArtista" CssClass="btn btn-info border-left" runat="server" Text="Actualizar" Height="36px" Width="114px" OnClick="btnActualizarArtista_Click" OnClientClick="return confirm('¿Desea editar este registro?');" Visible="False" />
                        <asp:Button ID="btnEliminarArtista" CssClass="btn btn-danger border-left" runat="server" Text="Eliminar" Height="36px" Width="114px" OnClick="btnEliminarArtista_Click" OnClientClick="return confirm('¿Desea eliminar este registro?');" Visible="False" />
                    </div>

                    <div class="breadcrumb justify-content-center" style="background-color: #d9d9d9;">
                        <asp:LinkButton ID="lnkbtnHome" CssClass="breadcrumb-item" runat="server" OnClick="lnkbtnHome_Click">Home</asp:LinkButton>
                        <asp:LinkButton ID="lnkbtnArtista" CssClass="breadcrumb-item active" runat="server">Artista</asp:LinkButton>
                        <asp:LinkButton ID="lnkbtnGenero" CssClass="breadcrumb-item" runat="server" OnClick="lnkbtnGenero_Click">Genero</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div>

        <%
            CapaNegocio.Negocio.NegocioArtista negocioArtista = new CapaNegocio.Negocio.NegocioArtista();
            double numRegistro = negocioArtista.NumeroRegistros();
            if (numRegistro == 0)
            {
        %>
        <style>
            #colum1 {
                height: 200px;
                width: 100%;
                padding-right: 15px;
                padding-left: 15px;
                margin-top: 20px;
                margin-right: auto;
                margin-left: auto;
            }

            #row {
                background-color: #d9d9d9;
                margin-top: 50px;
                margin-bottom: 100px;
                height: 380px;
            }

            #colum2, #fila1 {
                display: none;
            }

            #footer {
                position: absolute;
                bottom: 0;
                width: 100%;
                height: 70px;
            }
        </style>
        <% }
            else
            {%>
        <style>
            #row {
                height: 230px;
                background-color: #d9d9d9;
            }

            #colum1 {
                height: 200px;
                width: 100%;
                padding-right: 15px;
                padding-left: 15px;
                margin-top: 30px;
                margin-right: auto;
                margin-left: auto;
            }

            #footer {
                position: absolute;
                bottom: 0;
                width: 100%;
                height: 70px;
            }
        </style>
        <% }%>

        <%if (gvDatosArtista.Rows.Count <= 0)
            {%>
        <style>
            #scroll, #lbTotalGenero {
                display: none;
            }

            #padreLogoData {
                display: flex;
                justify-content: center;
                align-items: center;
            }
        </style>
        <% }
            else
            {%>
        <style>
            #padreLogoData {
                display: none;
            }
        </style>
        <% }%>
    </div>
</asp:Content>