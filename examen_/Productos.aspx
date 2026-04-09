<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Productos.aspx.cs" Inherits="examen_.Productos" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container mt-5 fade-in-up">
            <div class="glass-card">
                <h2>Catalogo de Productos</h2>
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Nombre:</label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group mt-3">
                            <label>Precio:</label>
                            <asp:TextBox ID="txtPrecio" runat="server" TextMode="Number" step="0.01"
                                CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group mt-3">
                            <label>Stock:</label>
                            <asp:TextBox ID="txtStock" runat="server" TextMode="Number" CssClass="form-control">
                            </asp:TextBox>
                        </div>
                        <div class="form-group mt-3">
                            <label>Categoria:</label>
                            <asp:TextBox ID="txtCategoria" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mt-4">
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Producto"
                                OnClick="btnGuardar_Click" CssClass="btn-primary-custom w-100" />
                        </div>
                        <asp:Label ID="lblMensaje" runat="server" CssClass="mt-3 d-block"></asp:Label>
                    </div>
                    <div class="col-md-8">
                        <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="false"
                            CssClass="table-custom mt-3" DataKeyNames="Id_Producto"
                            OnRowEditing="gvProductos_RowEditing" OnRowDeleting="gvProductos_RowDeleting">
                            <Columns>
                                <asp:BoundField DataField="Id_Producto" HeaderText="ID" ReadOnly="true" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                                <asp:BoundField DataField="Stock" HeaderText="Stock" />
                                <asp:BoundField DataField="Categoria" HeaderText="Categoria" />
                                <asp:CommandField ShowEditButton="true" ShowDeleteButton="true"
                                    ControlStyle-CssClass="btn btn-sm btn-outline-info" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </asp:Content>