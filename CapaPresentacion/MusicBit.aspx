<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MusicBit.aspx.cs" Inherits="CapaPresentacion.MusicBit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div id="fila1" class="row mt-2 ">
            <div class="mb-1 rounded col-12 col-sm-12 col-md-5 col-lg-5" style="background-color: #d9d9d9; height: 260px;">
                <div class="mt-2 mt-sm-2 mt-md-2">
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text border border-info">
                                <asp:Label ID="LbBuscar" Style="font-weight: bold;" runat="server" Text="Buscar :" Width="90px" />
                            </span>
              </div>
                        <asp:TextBox ID="txtBuscar"  placeholder="BUSCAR ARTISTA, CANCION O GENERO" AutoComplete="off" CssClass="form-control border border-info" runat="server" />
                    </div>

                    <div id="rdoBotones">
                        <asp:Panel ID="Panel1" runat="server">
                            <div id="listRdos" runat="server" class="d-flex justify-content-center ml-md-3">
                                <div class="form-check form-check-inline">
                                    <asp:RadioButton ID="rdoTodo" CssClass="form-check-input" Checked="true" runat="server" GroupName="Busqueda" AutoPostBack="True" OnCheckedChanged="rdoTodo_CheckedChanged" />
                                    <asp:Label ID="Label4" CssClass="form-check-label" runat="server">Todo</asp:Label>
                                </div>
                                <div class="form-check form-check-inline">
                                    <asp:RadioButton ID="rdoArtista" CssClass="form-check-input" runat="server" GroupName="Busqueda" AutoPostBack="True" OnCheckedChanged="rdoArtista_CheckedChanged" />
                                    <asp:Label ID="Label5" CssClass="form-check-label" runat="server">Artista</asp:Label>
                                </div>
                                <div class="form-check form-check-inline">
                                    <asp:RadioButton ID="rdoCancion" CssClass="form-check-input" runat="server" GroupName="Busqueda" AutoPostBack="True" OnCheckedChanged="rdoCancion_CheckedChanged" />
                                    <asp:Label ID="Label6" CssClass="form-check-label" runat="server">Canción</asp:Label>
                                </div>
                                <div class="form-check form-check-inline">
                                    <asp:RadioButton ID="rdoGenero" CssClass="form-check-input" runat="server" GroupName="Busqueda" AutoPostBack="True" OnCheckedChanged="rdoGenero_CheckedChanged" />
                                    <asp:Label ID="Label7" CssClass="form-check-label" runat="server">Genero</asp:Label>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                    <div id="btnTabBuscar" style="margin-top: 120px;" class="d-flex justify-content-end">
                        <asp:Button ID="btnBuscar" CssClass="btn btn-info" Height="36px" Width="114px" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                    </div>
                </div>
            </div>

            <div class="mb-1  rounded col-12 col-sm-12 col-md-7 col-lg-7" style="border-left: 3px solid White; background-color: #d9d9d9; height: 260px; overflow: auto;">
                <div class="mt-2 mt-sm-2 mt-md-2">
                    <asp:GridView ID="gvDatos"
                        AutoGenerateColumns="False"
                        PageSize="6"
                        RowStyle-Wrap="false"
                        Width="100%" CssClass="table-hover"
                        runat="server" AutoGenerateSelectButton="True"
                        OnSelectedIndexChanged="gvDatos_SelectedIndexChanged"
                        AllowPaging="true"
                        OnPageIndexChanging="gvDatos_PageIndexChanging"
                        OnRowDataBound="gvDatos_RowDataBound">

                        <RowStyle Height="20px" />
                        <AlternatingRowStyle Height="20px" />
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle CssClass="text-white bg-dark" HorizontalAlign="Center" BorderStyle="Groove" BorderColor="black" />
                        <RowStyle CssClass="table-light" HorizontalAlign="Center" BorderStyle="Groove" BorderColor="black" />
                        <SelectedRowStyle Font-Bold="True" ForeColor="black" />

                        <Columns>
                            <asp:BoundField DataField="ClaveCancion"></asp:BoundField>
                            <asp:BoundField DataField="ClaveArtista"></asp:BoundField>
                            <asp:BoundField DataField="ClaveGenero"></asp:BoundField>

                            <asp:BoundField DataField="Artista" HeaderText="Artista">
                                <ItemStyle Width="33%" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Cancion" HeaderText="Cancion">
                                <ItemStyle Width="33%" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Genero" HeaderText="Genero">
                                <ItemStyle Width="33%" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Letra" HeaderText="letra"></asp:BoundField>

                        </Columns>

                        <PagerSettings Mode="NumericFirstLast"
                            PageButtonCount="8"
                            FirstPageText="Primero"
                            LastPageText="Ultimo" />
                        <PagerStyle CssClass="pagination-ys" BorderColor="Transparent" Height="30px" HorizontalAlign="Center" />




                    </asp:GridView>
                </div>

                <div id="padreLogoData" class="container">
                    <img runat="server" style="margin-top: 20px; width: 330px; height: 200px;"
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
                        <asp:TextBox ID="txtCancion" AutoComplete="off" placeholder="INGRESA NOMBRE DE LA CANCION" CssClass="form-control  border-info" runat="server" />
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
                        <asp:TextBox ID="txtLetra" AutoComplete="off" placeholder="LETRA CANCION" Style="resize: none;" TextMode="multiline" Columns="100" Rows="3" CssClass="form-control  border-info" runat="server"></asp:TextBox>
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
                <asp:TextBox ID="txtMostrarLetra" AutoComplete="off" ReadOnly="true" BackColor="#e8effd" Style="resize: none; text-align: center; margin-top: 15px;" TextMode="multiline" Columns="1000" Rows="11" CssClass="form-control border-info" runat="server"></asp:TextBox>
                <asp:Label ID="lbTotalRegistro" Text="Total de Registros: " Font-Bold="true" CssClass="mb-1 mt-1 d-flex justify-content-end" runat="server"></asp:Label>
            </div>


        </div>


        <style>
            .pagination-ys {
                /*display: inline-block;*/
                padding-left: 0;
                margin: 20px 0;
                border-radius: 4px;
            }

                .pagination-ys table > tbody > tr > td {
                    display: inline;
                }

                    .pagination-ys table > tbody > tr > td > a,
                    .pagination-ys table > tbody > tr > td > span {
                        position: relative;
                        float: left;
                        padding: 8px 12px;
                        line-height: 1.42857143;
                        text-decoration: none;
                        color: #1e90ff;
                        background-color: #ffffff;
                        border: 1px solid #dddddd;
                        margin-left: -1px;
                    }

                    .pagination-ys table > tbody > tr > td > span {
                        position: relative;
                        float: left;
                        padding: 8px 12px;
                        line-height: 1.42857143;
                        text-decoration: none;
                        margin-left: -1px;
                        z-index: 2;
                        color: #1e90ff;
                        background-color: #f5f5f5;
                        border-color: #dddddd;
                        cursor: default;
                    }

                    .pagination-ys table > tbody > tr > td:first-child > a,
                    .pagination-ys table > tbody > tr > td:first-child > span {
                        margin-left: 0;
                        border-bottom-left-radius: 4px;
                        border-top-left-radius: 4px;
                    }

                    .pagination-ys table > tbody > tr > td:last-child > a,
                    .pagination-ys table > tbody > tr > td:last-child > span {
                        border-bottom-right-radius: 4px;
                        border-top-right-radius: 4px;
                    }

                    .pagination-ys table > tbody > tr > td > a:hover,
                    .pagination-ys table > tbody > tr > td > span:hover,
                    .pagination-ys table > tbody > tr > td > a:focus,
                    .pagination-ys table > tbody > tr > td > span:focus {
                        color: #1e90ff;
                        background-color: #eeeeee;
                        border-color: #dddddd;
                    }
        </style>


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
                position: fixed;
                left: 0;
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


        <div>
            <%if (rdoTodo.Checked)
                { %>
            <script>    
                $(function () {
                    $("#<% =txtBuscar.ClientID%>").autocomplete({
                        source: function (request, response) {
                            var param = { nombre: $("#<% =txtBuscar.ClientID%>").val() };
                            $.ajax({
                                url: "MusicBit.aspx/AutoCompletar_Todo",
                                data: JSON.stringify(param),
                                type: "post",
                                contentType: "application/json; charset=utf-8",
                                datafilter: function (data) { return data; },
                                success: function (data) {
                                    response($.map(data.d, function (item) { return { value: item } }))
                                },
                            });
                        },
                        minLength: 1
                    });
                });
            </script>
            <% } %>

            <%if (rdoArtista.Checked)
                {%>
            <script>    
                $(function () {
                    $("#<% =txtBuscar.ClientID%>").autocomplete({
                        source: function (request, response) {
                            var param = { nombre: $("#<% =txtBuscar.ClientID%>").val() };
                            $.ajax({
                                url: "MusicBit.aspx/AutoCompletar_Artista",
                                data: JSON.stringify(param),
                                type: "post",
                                contentType: "application/json; charset=utf-8",
                                datafilter: function (data) { return data; },
                                success: function (data) {
                                    response($.map(data.d, function (item) { return { value: item } }))
                                },
                            });
                        },
                        minLength: 1
                    });
                });
            </script>
            <% } %>

            <%if (rdoCancion.Checked)
                {%>
            <script>    
                $(function () {
                    $("#<% =txtBuscar.ClientID%>").autocomplete({
                        source: function (request, response) {
                            var param = { nombre: $("#<% =txtBuscar.ClientID%>").val() };
                            $.ajax({
                                url: "MusicBit.aspx/AutoCompletar_Cancion",
                                data: JSON.stringify(param),
                                type: "post",
                                contentType: "application/json; charset=utf-8",
                                datafilter: function (data) { return data; },
                                success: function (data) {
                                    response($.map(data.d, function (item) { return { value: item } }))
                                },
                            });
                        },
                        minLength: 1
                    });
                });
            </script>
            <% } %>

            <%if (rdoGenero.Checked)
                {%>
            <script>    
                $(function () {
                    $("#<% =txtBuscar.ClientID%>").autocomplete({
                        source: function (request, response) {
                            var param = { nombre: $("#<% =txtBuscar.ClientID%>").val() };
                            $.ajax({
                                url: "MusicBit.aspx/AutoCompletar_Genero",
                                data: JSON.stringify(param),
                                type: "post",
                                contentType: "application/json; charset=utf-8",
                                datafilter: function (data) { return data; },
                                success: function (data) {
                                    response($.map(data.d, function (item) { return { value: item } }))
                                },
                            });
                        },
                        minLength: 1
                    });
                });
            </script>
            <% } %>
        </div>
    </div>
</asp:Content>
