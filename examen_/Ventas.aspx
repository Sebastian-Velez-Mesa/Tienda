<%@ Page Title="Ventas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs"
    Inherits="examen_.Ventas" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container mt-5 fade-in-up">
            <div class="glass-card">
                <h2>Registro de Ventas</h2>
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Cliente:</label>
                            <asp:DropDownList ID="ddlClientes" runat="server" CssClass="form-select"></asp:DropDownList>
                        </div>
                        <div class="form-group mt-3">
                            <label>Producto:</label>
                            <asp:DropDownList ID="ddlProductos" runat="server" CssClass="form-select">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group mt-3">
                            <label>Cantidad:</label>
                            <asp:TextBox ID="txtCantidad" runat="server" TextMode="Number" CssClass="form-control"
                                Text="1"></asp:TextBox>
                        </div>
                        <div class="mt-4">
                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar al Carrito"
                                OnClick="btnAgregar_Click" CssClass="btn-primary-custom w-100" />
                        </div>
                    </div>
                    <div class="col-md-8">
                        <h4 style="color:#00d2ff; font-weight:600;">Carrito</h4>
                        <asp:GridView ID="gvCarrito" runat="server" AutoGenerateColumns="false" CssClass="table-custom">
                            <Columns>
                                <asp:BoundField DataField="Nombre" HeaderText="Producto" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                <asp:BoundField DataField="Precio_Unitario" HeaderText="Precio Unitario" />
                                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" />
                            </Columns>
                        </asp:GridView>
                        <h4 class="text-end mt-3" style="color:#e0e0e0;">Total: <asp:Label ID="lblTotal" runat="server"
                                Text="0.00" style="color:#38ef7d; font-weight:600;"></asp:Label>
                        </h4>

                        <div class="text-end mt-3">
                            <asp:Button ID="btnProcesarVenta" runat="server" Text="Procesar Venta"
                                OnClick="btnProcesarVenta_Click" CssClass="btn-success-custom" />
                        </div>
                        <asp:Label ID="lblMensaje" runat="server" CssClass="mt-2 text-warning d-block text-end">
                        </asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </asp:Content>