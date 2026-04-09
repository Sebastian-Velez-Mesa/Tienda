<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Productos.aspx.cs" Inherits="examen_.Productos" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="row g-4">
            <!-- Formulario Lateral -->
            <div class="col-lg-4">
                <div class="glass-card">
                    <h3 style="color: var(--accent); font-weight: 600; margin-bottom: 1.5rem;">
                        <i class="fas fa-edit me-2"></i>Gestión de Producto
                    </h3>
                    <div class="form-group mb-3">
                        <label class="text-secondary small mb-1">Nombre del Producto</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"
                            placeholder="Ej: Procesador i9"></asp:TextBox>
                    </div>
                    <div class="form-group mb-3">
                        <label class="text-secondary small mb-1">Precio Unitario ($)</label>
                        <asp:TextBox ID="txtPrecio" runat="server" TextMode="Number" step="0.01" CssClass="form-control"
                            placeholder="0.00"></asp:TextBox>
                    </div>
                    <div class="form-group mb-3">
                        <label class="text-secondary small mb-1">Existencias (Stock)</label>
                        <asp:TextBox ID="txtStock" runat="server" TextMode="Number" CssClass="form-control"
                            placeholder="0"></asp:TextBox>
                    </div>
                    <div class="form-group mb-3">
                        <label class="text-secondary small mb-1">Categoría</label>
                        <asp:TextBox ID="txtCategoria" runat="server" CssClass="form-control"
                            placeholder="Ej: Hardware"></asp:TextBox>
                    </div>
                    <div class="mt-4">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" OnClick="btnGuardar_Click"
                            CssClass="btn-premium w-100" />
                    </div>
                    <asp:Label ID="lblMensaje" runat="server" CssClass="mt-3 d-block small"></asp:Label>
                </div>
            </div>

            <!-- Tabla de Datos -->
            <div class="col-lg-8">
                <div class="glass-card h-100">
                    <h3 style="color: white; font-weight: 600; margin-bottom: 1.5rem;">
                        <i class="fas fa-list me-2"></i>Inventario Disponible
                    </h3>
                    <div class="table-responsive">
                        <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="false" CssClass="modern-grid"
                            DataKeyNames="Id_Producto" OnRowEditing="gvProductos_RowEditing"
                            OnRowDeleting="gvProductos_RowDeleting">
                            <Columns>
                                <asp:BoundField DataField="Id_Producto" HeaderText="ID" ReadOnly="true" />
                                <asp:BoundField DataField="Nombre" HeaderText="Producto" />
                                <asp:TemplateField HeaderText="Precio">
                                    <ItemTemplate>
                                        <span style="color: var(--accent); font-weight: 600;">$<%# Eval("Precio") %>
                                                </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Stock" HeaderText="Stock" />
                                <asp:BoundField DataField="Categoria" HeaderText="Categoría" />
                                <asp:TemplateField HeaderText="Acciones">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit"
                                            CssClass="btn btn-sm btn-outline-info me-1"><i class="fas fa-pen"></i>
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete"
                                            CssClass="btn btn-sm btn-outline-danger"
                                            OnClientClick="return confirm('¿Eliminar este producto?');"><i
                                                class="fas fa-trash"></i></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </asp:Content>