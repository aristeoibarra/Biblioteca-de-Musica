<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MusicBit.aspx.cs" Inherits="CapaPresentacion.MusicBit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App/Styles/Main.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row mt-3 ">
            <div class="mb-1 rounded col-12 col-sm-12 col-md-5 col-lg-5" style="background-color: #d9d9d9; height: 260px;">
                <div class="mt-2 mt-sm-2 mt-md-2">
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text">
                                <asp:Label ID="LbBuscar" runat="server" Text="Buscar :" Width="90px" />
                            </span>
                        </div>
                        <asp:TextBox ID="txtBuscar" CssClass="form-control" runat="server" />
                    </div>
                    <asp:Panel ID="Panel1" runat="server">
                        <div>
                            <div class="form-check form-check-inline">
                                <asp:RadioButton ID="RadioButton1" CssClass="form-check-input" runat="server" GroupName="Busqueda" Checked="True"  />
                                <label class="form-check-label"  for="inlineRadio1">Todo</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <asp:RadioButton ID="RadioButton2" CssClass="form-check-input" runat="server" GroupName="Busqueda" />
                                <label class="form-check-label" for="inlineRadio2">Artista</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <asp:RadioButton ID="RadioButton3" CssClass="form-check-input" runat="server" GroupName="Busqueda" />
                                <label class="form-check-label" for="inlineRadio3">Canción</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <asp:RadioButton ID="RadioButton4" CssClass="form-check-input" runat="server" GroupName="Busqueda" />
                                <label class="form-check-label" for="inlineRadio4">Genero</label>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>

            <div class="mb-1  rounded col-12 col-sm-12 col-md-7 col-lg-7" style="border-left: 3px solid white; background-color: #d9d9d9; height: 260px;">
                <div class="scrolling-table-container mt-2 mt-sm-2 mt-md-2">
                    <asp:GridView ID="gvDatos" runat="server" OnSelectedIndexChanged="gvDatos_SelectedIndexChanged" OnRowDataBound="gvDatos_RowDataBound" AutoGenerateSelectButton="True">
                    </asp:GridView>
                </div>
            </div>
        </div>

        <div class="row mb-3">
            <div class="pl-2 mb-1 rounded col-12 col-sm-12 col-md-5 col-lg-5" style="background-color: #d9d9d9; height: auto;">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="Tab1" runat="server">

                        <div class="mt-3 mt-sm-3 mt-md-3">
                            <%-- txtArtista --%>
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">
                                        <asp:Label ID="Label2" runat="server" Text="Artista :" Width="90px" />
                                    </span>
                                </div>
                                <asp:DropDownList ID="ddlArtista" CssClass="form-control " runat="server" />
                                <div class="input-group-append">
                                    <asp:Button ID="BtnArtista" CssClass="btn btn-secondary" runat="server" Text="..." />
                                </div>
                            </div>

                            <%-- txtCancion --%>
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">
                                        <asp:Label ID="LbCancion" runat="server" Text="Canción :" Width="90px" />
                                    </span>
                                </div>
                                <asp:TextBox ID="txtCancion" CssClass="form-control" runat="server" />
                            </div>

                            <%-- txtGenero --%>
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">
                                        <asp:Label ID="LbGenero" runat="server" Text="Genero :" Width="90px" />
                                    </span>
                                </div>
                                <asp:DropDownList ID="ddlGenero" CssClass="form-control" runat="server" />
                                <div class="input-group-append">
                                    <asp:Button ID="BtnGenero" CssClass="btn btn-secondary" runat="server" Text="..." />
                                </div>
                            </div>

                            <%-- txtTexto --%>
                            <div class="input-group mb-3">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">
                                        <asp:Label ID="LbLetra" runat="server" Text="Letra : " Width="90px" />
                                    </span>
                                </div>
                                <asp:TextBox ID="txtLetra" Style="resize: none;" TextMode="multiline" Columns="100" Rows="3" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div style="margin-top: 10px; margin-bottom: 10px;" class="d-flex justify-content-end">
                            <asp:Button ID="btnInsertar" CssClass="btn btn-secondary" runat="server" Text="Insertar" Height="36px" Width="114px" OnClick="btnInsertar_Click" />
                            <asp:Button ID="btnActualizar" CssClass="btn btn-secondary border-left" runat="server" Text="Actualizar" Height="36px" Width="114px" OnClick="btnActualizar_Click" OnClientClick="return confirm('¿Desea editar este registro?');" />
                            <asp:Button ID="btnEliminar" CssClass="btn btn-secondary border-left" runat="server" Text="Eliminar" Height="36px" Width="114px" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Desea eliminar este registro?');" />
                        </div>
                    </asp:View>

                    <asp:View ID="Tab2" runat="server">
                        <div class="mt-4">
                            <asp:TextBox ID="TxtAddArtista" CssClass="form-control" runat="server"></asp:TextBox>
                            <div class="mt-2 d-flex justify-content-end">
                                <asp:Button ID="BtnAddArtista" CssClass="btn btn-secondary mb-2 mt-sm-auto " runat="server" Text="Agregar" Height="36px" Width="114px" />
                            </div>
                        </div>
                    </asp:View>

                    <asp:View ID="Tab3" runat="server">
                    </asp:View>
                </asp:MultiView>
            </div>

            <div class="mb-1 rounded col-12 col-sm-12 col-md-7 col-lg-7" style="border-left: 3px solid white; background-color: #d9d9d9; height: auto;">
                <asp:TextBox ID="TxtMostrarLetra" Style="resize: none; margin-top: 15px;" TextMode="multiline" Columns="1000" Rows="11" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:Label ID="LbTotalRegistro" Text="TOTAL DE REGISTROS: 57" CssClass="mb-1 mt-1 d-flex justify-content-end" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
