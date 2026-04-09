<%@ Page Title="Ventas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs"
    Inherits="examen_.Ventas" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="row g-4">
            <!-- Panel de Selección -->
            <div class="col-lg-4">
                <div class="glass-card">
                    <h3 style="color: var(--accent); font-weight: 600; margin-bottom: 1.5rem;">
                        <i class="fas fa-cart-plus me-2"></i>Nueva Transacción
                    </h3>
                    <div class="form-group mb-3">
                        <label class="text-secondary small mb-1">Seleccionar Cliente</label>
                        <asp:DropDownList ID="ddlClientes" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group mb-3">
                        <label class="text-secondary small mb-1">Seleccionar Producto</label>
                        <asp:DropDownList ID="ddlProductos" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group mb-3">
                        <label class="text-secondary small mb-1">Cantidad</label>
                        <asp:TextBox ID="txtCantidad" runat="server" TextMode="Number" CssClass="form-control" Text="1">
                        </asp:TextBox>
                    </div>
                    <div class="mt-4">
                        <asp:Button ID="btnAgregar" runat="server" Text="Añadir al Carrito" OnClick="btnAgregar_Click"
                            CssClass="btn-premium w-100" />
                    </div>
                </div>
            </div>

            <!-- Panel de Carrito -->
            <div class="col-lg-8">
                <div class="glass-card h-100">
                    <div class="d-flex justify-content-between align-items-center mb-4">
                        <h3 style="color: white; font-weight: 600; margin-bottom: 0;">
                            <i class="fas fa-shopping-basket me-2"></i>Resumen de Compra
                        </h3>
                        <div class="text-end">
                            <span class="text-secondary small">Monto Total</span><br />
                            <asp:Label ID="lblTotal" runat="server" Text="0.00"
                                style="color: #38ef7d; font-size: 1.5rem; font-weight: 700;"></asp:Label>
                            <span style="color: #38ef7d; font-weight: 700;">USD</span>
                        </div>
                    </div>

                    <div class="table-responsive">
                        <asp:GridView ID="gvCarrito" runat="server" AutoGenerateColumns="false" CssClass="modern-grid">
                            <Columns>
                                <asp:BoundField DataField="Nombre" HeaderText="Producto" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                <asp:BoundField DataField="Precio_Unitario" HeaderText="Precio"
                                    DataFormatString="{0:C}" />
                                <asp:TemplateField HeaderText="Subtotal">
                                    <ItemTemplate>
                                        <span style="color: var(--accent); font-weight: 600;">$<%# Eval("Subtotal") %>
                                                </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>

                    <div class="text-end mt-4">
                        <asp:Button ID="btnProcesarVenta" runat="server" Text="Confirmar Venta"
                            OnClick="btnProcesarVenta_Click" CssClass="btn-premium"
                            style="background: linear-gradient(45deg, #38ef7d, #11998e); min-width: 200px;" />
                    </div>
                    <asp:Label ID="lblMensaje" runat="server" CssClass="mt-2 text-warning d-block text-end small">
                    </asp:Label>
                </div>
            </div>
        </div>
    </asp:Content>