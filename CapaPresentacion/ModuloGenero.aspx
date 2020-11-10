<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ModuloGenero.aspx.cs" Inherits="CapaPresentacion.ModuloGenero" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App/Styles/Main.css" rel="stylesheet" />

    <link rel="Stylesheet" href="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.10/themes/redmond/jquery-ui.css" />
    <script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-1.8.0.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.22/jquery-ui.js"></script>
    <script>    
        $(function () {
            $("#<% =txtBuscarGenero.ClientID%>").autocomplete({
                source: function (request, response) {
                    var param = { nombreGenero: $("#<% =txtBuscarGenero.ClientID%>").val() };
                    $.ajax({
                        url: "ModuloGenero.aspx/AutoCompletarNombreGenero",
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
                        <asp:TextBox ID="txtBuscarGenero" CssClass="form-control border border-info" runat="server" />
                    </div>


                    <div id="btnTabBuscar" class="d-flex justify-content-end">
                        <asp:Button ID="btnBusarGenero" CssClass="btn btn-info" Height="36px" Width="114px" runat="server" Text="Buscar" OnClick="btnBusarGenero_Click" />
                    </div>

                    <asp:Label ID="lbNumGenero" runat="server" />
                </div>
            </div>

            <div class="mb-1  rounded col-12 col-sm-12 col-md-7 col-lg-7" style="border-left: 3px solid White; background-color: #d9d9d9; height: 260px;">
                <div id="" class="mt-2 mt-sm-2 mt-md-2">

                    <asp:GridView ID="gvDatosGenero"
                        AutoGenerateColumns="False"
                        PageSize="6"
                        Width="100%" CssClass="table-hover"
                        runat="server" AutoGenerateSelectButton="True"
                        OnSelectedIndexChanged="gvDatosGenero_SelectedIndexChanged"
                        AllowPaging="True"
                        AllowCustomPaging="True" OnPageIndexChanging="gvDatosGenero_PageIndexChanging" OnRowDataBound="gvDatosGenero_RowDataBound">

                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle CssClass="text-white bg-dark" HorizontalAlign="Center" BorderStyle="Groove" BorderColor="black" />
                        <RowStyle CssClass="table-light" HorizontalAlign="Center" BorderStyle="Groove" BorderColor="black" />
                        <SelectedRowStyle Font-Bold="True" ForeColor="black" />

                        <Columns>
                            <asp:BoundField DataField="CveGenero" HeaderText="Cve"></asp:BoundField>
                            <asp:BoundField DataField="NombreGenero" HeaderText="- Nombre Genero -">
                                <ItemStyle Width="100%" />
                            </asp:BoundField>
                        </Columns>
                        <PagerSettings Mode="NumericFirstLast"
                            PageButtonCount="8"
                            FirstPageText="Primero"
                            LastPageText="Ultimo" />
                        <PagerStyle CssClass="pagination-ys" BorderColor="Transparent" Height="30px" HorizontalAlign="Center" />

                    </asp:GridView>
                </div>
                <div id="lbTotalGenero">
                    <asp:Label ID="lbTotalRegistro" Visible="false" Text="Total de Registros: " Font-Bold="true" CssClass="mb-1 mt-1 d-flex justify-content-center" runat="server"></asp:Label>
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
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text border-info">
                                <asp:Label ID="Label1" runat="server" Style="font-weight: bold;" Text="Genero :" Width="90px" />
                            </span>
                        </div>
                        <asp:TextBox ID="txtGenero" placeholder="INGRESA NOMBRE DEL ARTISTA" CssClass="form-control border-info" runat="server" />
                    </div>
                    <div style="margin-top: 10px; margin-bottom: 10px;" class="d-flex justify-content-center">
                        <asp:Button ID="btnInsertarGenero" CssClass="btn btn-success" runat="server" Text="Insertar" Height="36px" Width="114px" OnClick="btnInsertarGenero_Click" />
                        <asp:Button ID="BtnNuevoGenero" CssClass="btn btn-success border-left" runat="server" Text="Nuevo" Height="36px" Width="114px" Visible="False" OnClick="BtnNuevoGenero_Click" />
                        <asp:Button ID="btnActualizarGenero" CssClass="btn btn-info border-left" runat="server" Text="Actualizar" Height="36px" Width="114px" Visible="False" OnClick="btnActualizarGenero_Click" />
                        <asp:Button ID="btnEliminarGenero" CssClass="btn btn-danger border-left" runat="server" Text="Eliminar" Height="36px" Width="114px" Visible="False" OnClick="btnEliminarGenero_Click" />
                    </div>

                    <div class="breadcrumb justify-content-center" style="background-color: #d9d9d9;">
                        <asp:LinkButton ID="lnkbtnHome" CssClass="breadcrumb-item" runat="server" OnClick="lnkbtnHome_Click">Home</asp:LinkButton>
                        <asp:LinkButton ID="lnkbtnArtista" CssClass="breadcrumb-item" runat="server" OnClick="lnkbtnArtista_Click">Artista</asp:LinkButton>
                        <asp:LinkButton ID="lnkbtnGenero" CssClass="breadcrumb-item active" runat="server">Genero</asp:LinkButton>
                    </div>
                </div>
            </div>
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

    <div>
        <%
            CapaNegocio.Negocio.NegocioGenero negocioGenero = new CapaNegocio.Negocio.NegocioGenero();
            double numero = negocioGenero.NumeroRegistros();
            if (numero == 0)
            {%>
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
                position: fixed;
                left: 0;
                bottom: 0;
                width: 100%;
                height: 70px;
            }
        </style>
        <% }%>

        <%if (gvDatosGenero.Rows.Count <= 0)
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
