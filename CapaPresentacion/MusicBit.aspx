<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MusicBit.aspx.cs" Inherits="CapaPresentacion.MusicBit" %>

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
                        <asp:TextBox ID="txtBuscar" CssClass="form-control border border-info" runat="server" />
                    </div>

                    <div id="rdoBotones">
                        <asp:Panel ID="Panel1" runat="server">
                            <div id="listRdos" runat="server" class="d-flex justify-content-center ml-md-3">
                                <div class="form-check form-check-inline">
                                    <asp:RadioButton ID="rdoTodo" CssClass="form-check-input" runat="server" GroupName="Busqueda" Checked="True" />
                                    <asp:Label ID="Label4" CssClass="form-check-label" runat="server">Todo</asp:Label>
                                </div>
                                <div class="form-check form-check-inline">
                                    <asp:RadioButton ID="rdoArtista" CssClass="form-check-input" runat="server" GroupName="Busqueda" />
                                    <asp:Label ID="Label5" CssClass="form-check-label" runat="server">Artista</asp:Label>
                                </div>
                                <div class="form-check form-check-inline">
                                    <asp:RadioButton ID="rdoCancion" CssClass="form-check-input" runat="server" GroupName="Busqueda" />
                                    <asp:Label ID="Label6" CssClass="form-check-label" runat="server">Canción</asp:Label>
                                </div>
                                <div class="form-check form-check-inline">
                                    <asp:RadioButton ID="rdoGenero" CssClass="form-check-input" runat="server" GroupName="Busqueda" />
                                    <asp:Label ID="Label7" CssClass="form-check-label" runat="server">Genero</asp:Label>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                    <div id="btnTabBuscar" style="margin-top:120px;" class="d-flex justify-content-end">
                        <asp:Button ID="btnBuscar" CssClass="btn btn-info" Height="36px" Width="114px" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                    </div>
                </div>
            </div>

            <div class="mb-1  rounded col-12 col-sm-12 col-md-7 col-lg-7" style="border-left: 3px solid White; background-color: #d9d9d9; height: 260px;">
                <div id="scroll" class="scrolling-table-container mt-2 mt-sm-2 mt-md-2">
                    <asp:GridView ID="gvDatos" ShowHeader="True" Width="100%" CssClass="table-hover table-striped" runat="server" OnSelectedIndexChanged="gvDatos_SelectedIndexChanged" OnRowDataBound="gvDatos_RowDataBound" AutoGenerateSelectButton="True">
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle CssClass="text-white bg-dark" HorizontalAlign="Center" BorderStyle="Groove" BorderColor="black" />
                        <RowStyle CssClass="table-light" HorizontalAlign="Center" BorderStyle="Groove" BorderColor="black" />
                        <SelectedRowStyle Font-Bold="True" ForeColor="black" />
                    </asp:GridView>
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
                    <%-- txtArtista --%>
                    <div class="input-group mb-3">
                        <div class="input-group-prepend ">
                            <span class="input-group-text border-info">
                                <asp:Label ID="Label2" Style="font-weight: bold;" runat="server" Text="Artista :" Width="90px" />
                            </span>
                        </div>

                        <asp:DropDownList ID="ddlArtista" ForeColor="Black" Font-Bold="true" BackColor="#e8effd" CssClass="form-control border-info" runat="server" />
                        <div class="input-group-append">
                            <asp:Button ID="btnModuloArtista" CssClass="btn btn-dark" Width="40px" runat="server" Text="..." OnClick="btnModuloArtista_Click" />
                        </div>
                    </div>

                    <%-- txtCancion --%>
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text  border-info">
                                <asp:Label ID="LbCancion" placeholder="Ingresa nombre de la canción" Style="font-weight: bold;" runat="server" Text="Canción :" Width="90px" />
                            </span>
                        </div>
                        <asp:TextBox ID="txtCancion" placeholder="INGRESA NOMBRE DE LA CANCION" CssClass="form-control  border-info" runat="server" />
                    </div>

                    <%-- txtGenero --%>
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text  border-info">
                                <asp:Label ID="LbGenero" Style="font-weight: bold;" runat="server" Text="Genero :" Width="90px" />
                            </span>
                        </div>
                        <asp:DropDownList ID="ddlGenero" ForeColor="Black" Font-Bold="true" BackColor="#e8effd" CssClass="form-control  border-info" runat="server" />
                        <div class="input-group-append">
                            <asp:Button ID="btnModuloGenero" CssClass="btn btn-dark" Width="40px" runat="server" Text="..." OnClick="btnModuloGenero_Click" />
                        </div>
                    </div>

                    <%-- txtTexto --%>
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text border-info">
                                <asp:Label ID="LbLetra" Style="font-weight: bold;" runat="server" Text="Letra : " Width="90px" />
                            </span>
                        </div>
                        <asp:TextBox ID="txtLetra" placeholder="LETRA CANCION" Style="resize: none;" TextMode="multiline" Columns="100" Rows="3" CssClass="form-control  border-info" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div style="margin-top: 10px; margin-bottom: 10px;" class="d-flex justify-content-end">
                    <asp:Button ID="btnInsertar" CssClass="btn btn-success" runat="server" Text="Insertar" Height="36px" Width="114px" OnClick="btnInsertar_Click" />
                    <asp:Button ID="BtnNuevo" CssClass="btn btn-success border-left" runat="server" Text="Nuevo" Visible="false" Height="36px" Width="114px" OnClick="BtnNuevo_Click" />
                    <asp:Button ID="btnActualizar" CssClass="btn btn-info border-left" runat="server" Text="Actualizar" Visible="false" Height="36px" Width="114px" OnClick="btnActualizar_Click" OnClientClick="return confirm('¿Desea editar este registro?');" />
                    <asp:Button ID="btnEliminar" CssClass="btn btn-danger border-left" runat="server" Text="Eliminar" Visible="false" Height="36px" Width="114px" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Desea eliminar este registro?');" />
                </div>
            </div>

            <div id="colum2" class="mb-1 rounded col-12 col-sm-12 col-md-7 col-lg-7" style="border-left: 3px solid white; background-color: #d9d9d9; height: auto;">
                <asp:TextBox ID="txtMostrarLetra" ReadOnly="true" BackColor="#e8effd" Style="resize: none; margin-top: 15px;" TextMode="multiline" Columns="1000" Rows="11" CssClass="form-control border-info" runat="server"></asp:TextBox>
                <asp:Label ID="lbTotalRegistro" Text="Total de Registros: " Font-Bold="true" CssClass="mb-1 mt-1 d-flex justify-content-end" runat="server"></asp:Label>
            </div>


        </div>




        <%
            CapaNegocio.Negocio.NegocioCancion_Artista_Genero negocioCancion_Artista_Genero = new CapaNegocio.Negocio.NegocioCancion_Artista_Genero();
            double numRegistro = negocioCancion_Artista_Genero.NumeroRegistros();

            if (numRegistro == 0)
            {  %>
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
        <% } %>

          <%if (gvDatos.Rows.Count <= 0)
            {%>
        <style>
            #scroll {
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
